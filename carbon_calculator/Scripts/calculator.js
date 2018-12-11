
$(document).ready(function () {
    $(function () {
        let speciesFactory = new SpeciesFactory();
        let speciesCalculation = new SpeciesCalculation();
        let currentSpecies = null;
        let raleosControl = {
            /** number of raleos.*/
            number: 0,
            /** Years of raleos.*/
            years: 0
        };

        const SUMA_RALEOS = 100;
        const GRAPH_CARBON = 1;
        const GRAPH_AREA = 2;
        const GRAPH_DAP = 3;
        const GRAPH_HEIGHT = 4;
        const GRAPH_VOL = 5;
        const GRAPH_CO2 = 6;

        var datos_co2,
            datos_carbono,
            datos_area,
            datos_dap,
            datos_volumen,
            datos_altura;

        var chart;

        String.prototype.format = function () {
            var formatted = this;
            for (var i = 0; i < arguments.length; i++) {
                var regexp = new RegExp('\\{' + i + '\\}', 'gi');
                formatted = formatted.replace(regexp, arguments[i]);
            }
            return formatted;
        };

        /**
            * Función que convierte un serializedArray ({{name: key_1, value: x} ... , {name: key_n, value: y}}) a un
            * object key:Value ({key_1: value, ... key_n: value});
            * return {object} objeto key:value
            */
        function convertSerializedArray(serializedArray) {
            var newObject = {};
            var actObj;
            for (var i = 0; i < serializedArray.length; i++) {
                actObj = serializedArray[i];
                newObject[actObj.name] = actObj.value;
            }
            return newObject;
        }

        /**
            * Método que crea el highchart basado en el vector y ID que se le manda
            * param {array} values : vector con datos calculados
            * param {int} graph: ID de gráfica a mostrar
            */
        function showGraph(values, graph) {
            // Si ya existe la gráfica, solo modifica datos, color y titulo
            if (typeof chart != "undefined") {
                chart.series[0].setData(values);
                chart.series[0].options.color = getGraphColor(graph);
                chart.series[0].update(chart.series[0].options);
                chart.setTitle({ text: getGraphMeasure(graph) });
            } else {
                chart = new Highcharts.Chart('graph-result', {

                    title: {
                        text: getGraphMeasure(graph)
                    },
                    subTitle: {
                        text: ''
                    },
                    chart: {
                        zoomType: 'x'
                    },
                    yAxis: {
                        title: {
                            text: null
                        }
                    },
                    xAxis: {
                        title: {
                            text: 'Año'
                        }
                    },
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    },
                    plotOptions: {
                        series: {
                            label: {
                                connectorAllowed: true
                            },

                            marker: {
                                enabled: true,
                                fillColor: '#FFFFFF',
                                lineWidth: 2,
                                lineColor: null // inherit from series
                            },

                            color: getGraphColor(graph)
                        },

                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: false
                        }
                    },

                    series: [{
                        showInLegend: false,
                        data: values
                    }],

                    responsive: {
                        rules: [{
                            condition: {
                                maxWidth: 1000
                            },
                            chartOptions: {
                                legend: {
                                    layout: 'horizontal',
                                    align: 'center',
                                    verticalAlign: 'bottom'
                                }
                            }
                        }]
                    }

                });
            }
        }

        /**
            * Función que retorna el título la gráfica, basándose en su ID
            * param {int} graph ID de la gráfica
            */
        function getGraphMeasure(graph) {
            switch (graph) {
                case GRAPH_CARBON: return "Unidades de carbono";
                case GRAPH_CO2: return "Unidades de co2";
                case GRAPH_AREA: return "Área Basal (m²/ha)";
                case GRAPH_DAP: return "DAP (cm)";
                case GRAPH_HEIGHT: return "Altura dominante (m)";
                case GRAPH_VOL: return "Volumen total (m³/ha)";
                default: return "";
            }
        }

        /**
            * Función que retorna el color la gráfica, basándose en su ID
            * param {int} graph ID de la gráfica
            */
        function getGraphColor(graph) {
            switch (graph) {
                case GRAPH_CARBON: return "#90CAF9";
                case GRAPH_AREA: return "#F48FB1";
                case GRAPH_DAP: return "#EF9A9A";
                case GRAPH_HEIGHT: return "#80CBC4";
                case GRAPH_VOL: return "#BDBDBD";
                case GRAPH_CO2: return "#BDF8BD";
                default: return "#546E7A";
            }
        }

        /**
            * Función que, dependiendo el vector de parámetro, creará dinámicamente el contenido
            * de la tabla. Creará header, el cual contendrá el # de año proyectado y el body,
            * el cual tendrá el valor calculado
            * param {array} data : vector con datos calculados
            * return {html} html que contendrá la tabla
            */
        function generateTable(data) {
            var header = '';
            var content = '';
            var actTh = '';
            var actTd = '';
            var finalTable = '<thead><tr>{0}</tr></thead><tbody><tr>{1}</tr></tbody>';
            for (var i = 0; i < data.length; i++) {
                header += '<th style="text-align: center" nowrap>Año ' + i + '</th>';
                content += '<td style="text-align: center">' + data[i][1] + '</td>';
            }

            return finalTable.format(header, content);
        }

        /**
            * Función que, dependiendo el vector de parámetro, creará dinámicamente el contenido
            * de la tabla proyectada. Creará header, el cual contendrá el # de año proyectado y el body,
            * el cual tendrá el valor calculado
            * param {array} data : vector con datos calculados
            * return {html} html que contendrá la tabla
            */
        function generateTableProjected(data) {
            var header = '';
            var content = '';
            var actTh = '';
            var actTd = '';
            var actData = [];
            var actYear;
            var finalTable = '<thead><tr>{0}</tr></thead><tbody><tr>{1}</tr></tbody>';
            // Recorre resultados y crea un array con #año como key y value la proyección de carbono
            for (var i = 0; i < data.length; i++) {
                actYear = data[i][0];
                if (actData[actYear] == null) {
                    actData[actYear] = [];
                }
                actData[actYear].push(data[i][1]);
            }
            actData.forEach((element, index) => {
                header += '<th style="text-align: center" nowrap>Año ' + index + '</th>';
                content += '<td style="text-align: center">' + element.join(' | ') + '</td>';
            });

            return finalTable.format(header, content);
        }

        /**
            * Función que agrega <option> a Select de años de raleo, según la cantidad ingresada en input
            * @param {int} years cantidad de años
            */
        function addYearsSelects(years) {
            for (var i = 0; i < raleosControl.number; i++) {
                addYearsSelect(years, '#selRaleo' + i);
            }
        }

        function addYearsSelect(years, component) {
            let firstYear = (new Date()).getFullYear();
            let lastYear = firstYear + years;
            let count_years = 0;

            $(component).find('option').remove();
            for (var i = firstYear; i < lastYear; i++) {
                // Agrega <option> según cantidad de años
                $(component).append($('<option>', {
                    value: count_years,
                    text: i.toString()
                }));
                count_years++;
            }
        }

        /**
            * Función que pone como obligatorio o no obligatorio los campos de raleo
            * param {boolean} required: true requeridos, false no requeridos
            */
        function updateRaleoRequired(required) {
            $('#pct1').prop('required', required);
            $('#pct2').prop('required', required);
        }

        /**
            * Metodo que asigna datos de el cálculo a cada una de las variables globales.
            * Se hace una copia de los datos, para que al modificar la gráfica no se modifiquen los mismos
            * param {array} values: array con resultados
            */
        function setNavValues(values) {
            datos_co2 = values.co2.slice(0);
            datos_carbono = values.carbono.slice(0);
            datos_altura = values.altura.slice(0);
            datos_area = values.area.slice(0);
            datos_dap = values.dap.slice(0);
            datos_volumen = values.volumen.slice(0);
        }

        /**
            * Método que reinicia el estado de las tabs, dejando únicamente como activa la de "Carbono"
            */
        function resetTabs() {
            $('#nav-carbono').parent().addClass('active');
            $('#nav-co2').parent().removeClass('active');
            $('#nav-area').parent().removeClass('active');
            $('#nav-altura').parent().removeClass('active');
            $('#nav-dap').parent().removeClass('active');
            $('#nav-volumen').parent().removeClass('active');
        }

        /**
         * Function to add inputs to projections that use raleos.
         */
        const addInputsRaleo = e => {
            if (raleosControl.number >= raleosControl.years) {
                return;
            }

            let currentYear = (new Date()).getFullYear();

            //Creación de nodos a insertar.
            let firstDivNode = document.createElement('div');
            let firstLavelNode = document.createElement('label');
            let selectNode = document.createElement('select');
            let secondDivNode = document.createElement('div');
            let secondLavelNode = document.createElement('label');
            let inputNode = document.createElement('input');
            let options = [];
            for (var i = 0; i < raleosControl.years; i++) {
                options.push(document.createElement('option'));
            }

            //Establecimiento de atributos de los nodos a insertar.
            firstDivNode.setAttribute('id', 'div1Raleo' + raleosControl.number);
            firstDivNode.setAttribute('class', 'col-md-3');
            selectNode.setAttribute('id', 'selRaleo' + raleosControl.number);
            selectNode.setAttribute('name', 'selRaleo' + raleosControl.number);
            selectNode.setAttribute('class', 'form-control big-input-size');
            secondDivNode.setAttribute('id', 'div2Raleo' + raleosControl.number);
            secondDivNode.setAttribute('class', 'col-md-3');
            inputNode.setAttribute('id', 'inpRaleo' + raleosControl.number);
            inputNode.setAttribute('name', 'inpRaleo' + raleosControl.number);
            inputNode.setAttribute('type', 'number');
            inputNode.setAttribute('class', 'form-control big-input-size');
            inputNode.setAttribute('placeholder', '15');
            inputNode.setAttribute('min', '0');
            inputNode.setAttribute('max', '50');
            inputNode.setAttribute('step', 'any');
            inputNode.setAttribute('autocomplete', 'off');
            inputNode.setAttribute('oninvalid', 'this.setCustomValidity(\'Ingresar un % válido\')"');
            inputNode.setAttribute('oninput', 'setCustomValidity(\'\')');
            options.forEach((option, index) => option.setAttribute('value', index));

            //Inserción del texto a mostran en los nodos lavel
            firstLavelNode.innerHTML = 'Año raleo ' + (raleosControl.number + 1);
            secondLavelNode.innerHTML = 'Porcentaje raleo ' + (raleosControl.number + 1);
            options.forEach((option, index) => option.innerHTML = currentYear + index);


            //Armado de la estructura de nodos.
            firstDivNode.appendChild(firstLavelNode);
            firstDivNode.appendChild(selectNode);
            secondDivNode.appendChild(secondLavelNode);
            secondDivNode.appendChild(inputNode);
            options.forEach(option => selectNode.appendChild(option));

            //Agregados los nodos al DOM.
            document.getElementById("tblRaleos").appendChild(firstDivNode);
            document.getElementById("tblRaleos").appendChild(secondDivNode);

            //Aumento de la variable encargada de controlar el conteo de raleos.
            raleosControl.number++;
        }

        /**
         * Function to remove inputs to projections that use raleos.
         */
        const removeInputsRaleo = e => {
            if (raleosControl.number <= 0) {
                return;
            }

            //Busqueda del parde y los hijos a eliminar.
            var parent = document.getElementById("tblRaleos");
            var child1 = document.getElementById("div1Raleo" + (raleosControl.number - 1));
            var child2 = document.getElementById("div2Raleo" + (raleosControl.number - 1));

            //Eliminación de los hijos.
            parent.removeChild(child1);
            parent.removeChild(child2);

            //Disminución de la variable encargada de controlar el conteo de raleos.
            raleosControl.number--;
        }

        const init = () => {
            $('[data-toggle="tooltip"]').tooltip();

            // Reinicia form y oculta resultado (cálculo actual)
            $('#btnResetFormActual').click(function () {
                $('#formCalculoActual')[0].reset();
                $('#panelResultadoActual').css('display', 'none');
            });

            // Reinicia form y oculta resultado (cálculo proyectado)
            $('#btnResetFormProyectada').click(function () {
                if ($('#checkRaleo').prop('checked')) {
                    $(".panel-raleo").slideToggle("slow");
                    updateRaleoRequired(false);
                    $('#pct2').prop('required', false);
                }
                // Reinicia form y oculta resultado
                $('#formCalculoProyectado')[0].reset();
                $('#panelResultadoProyectado').hide();
                $('#checkRaleo').prop('disabled', true);
                $('#lblCheckRaleo').css('color', "#dddddd");
                $('#btnExportar').hide();
                resetTabs();
            });

            // Cada vez que se escribe en campo de años (proyectado), se verifica su valor
            $('#txtYearsP').keyup(function () {
                var newVal = $('#txtYearsP').val();
                // Si valor de years tiene data, habilita checkbox
                if (newVal !== "") {
                    $('#checkRaleo').prop('disabled', false);
                    $('#lblCheckRaleo').css('color', "black");
                    // Llena Select con años
                    addYearsSelects(raleosControl.years = parseInt(newVal));
                } else {
                    // Si lo deja Empty y el checkbox esta seleccionado, le hace uncheck y oculta panel
                    if ($('#checkRaleo').prop('checked')) {
                        $('#checkRaleo').prop('checked', false);
                        $(".panel-raleo").slideToggle("slow");
                        updateRaleoRequired(false);
                    }
                    $('#checkRaleo').prop('disabled', true);
                    $('#lblCheckRaleo').css('color', "#dddddd");
                }

            });

            // Cada vez que cambia checkbox, mostrará/ocultará panel de raleo
            $("#checkRaleo").change(function () {
                $(".panel-raleo").slideToggle("slow");
                updateRaleoRequired(this.checked);

                // Inicialmente este año no es obligatorio
                $('#pct2').prop('required', false);
            });

            // Muestra gráfica y tabla de carbono al volver esta Tab como Actual
            $('#nav-carbono').on('click', function () {
                if (!$(this).parent().hasClass('active')) {
                    if ($('#checkRaleo').prop('checked')) {
                        $('#tablaProyectada').html(generateTableProjected(datos_carbono));
                    } else {
                        $('#tablaProyectada').html(generateTable(datos_carbono));
                        $('#dataType').html("<strong>Cantidades expresadas en toneladas de carbono por hectarea (t C/ha)</strong>");
                    }
                    showGraph(datos_carbono, GRAPH_CARBON);
                }
            });

            // Muestra gráfica y tabla de co2 al volver esta Tab como Actual
            $('#nav-co2').on('click', function () {
                if (!$(this).parent().hasClass('active')) {
                    if ($('#checkRaleo').prop('checked')) {
                        $('#tablaProyectada').html(generateTableProjected(datos_co2));
                    } else {
                        $('#tablaProyectada').html(generateTable(datos_co2));
                        $('#dataType').html("<strong>Cantidades expresadas en toneladas de CO2 por hectarea (t CO<sub>2</sub>/ha)</strong>");
                    }
                    showGraph(datos_co2, GRAPH_CO2);
                }
            });

            // Muestra gráfica y tabla de altura al volver esta Tab como Actual
            $('#nav-altura').on('click', function () {
                if (!$(this).parent().hasClass('active')) {
                    if ($('#checkRaleo').prop('checked')) {
                        $('#tablaProyectada').html(generateTableProjected(datos_altura));
                    } else {
                        $('#tablaProyectada').html(generateTable(datos_altura));
                        $('#dataType').html("<strong>Cantidades expresadas en metros</strong>");
                    }
                    showGraph(datos_altura, GRAPH_HEIGHT);
                }
            });

            // Muestra gráfica y tabla de área al volver esta Tab como Actual
            $('#nav-area').on('click', function () {
                if (!$(this).parent().hasClass('active')) {
                    if ($('#checkRaleo').prop('checked')) {
                        $('#tablaProyectada').html(generateTableProjected(datos_area));
                    } else {
                        $('#tablaProyectada').html(generateTable(datos_area));
                        $('#dataType').html("<strong>Cantidades expresadas en m<sup>2</sup>/ha</strong>");
                    }
                    showGraph(datos_area, GRAPH_AREA);
                }
            });

            // Muestra gráfica y tabla de DAP al volver esta Tab como Actual
            $('#nav-dap').on('click', function () {
                if (!$(this).parent().hasClass('active')) {
                    if ($('#checkRaleo').prop('checked')) {
                        $('#tablaProyectada').html(generateTableProjected(datos_dap));
                    } else {
                        $('#tablaProyectada').html(generateTable(datos_dap));
                        $('#dataType').html("<strong>Cantidades expresadas en centimetros</strong>");
                    }
                    showGraph(datos_dap, GRAPH_DAP);
                }
            });

            // Muestra gráfica y tabla de volumen al volver esta Tab como Actual
            $('#nav-volumen').on('click', function () {
                if (!$(this).parent().hasClass('active')) {
                    if ($('#checkRaleo').prop('checked')) {
                        $('#tablaProyectada').html(generateTableProjected(datos_volumen));
                    } else {
                        $('#tablaProyectada').html(generateTable(datos_volumen));
                        $('#dataType').html("<strong>Cantidades expresadas en m<sup>3</sup>/ha</strong>");
                    }
                    showGraph(datos_volumen, GRAPH_VOL);
                }
            });

            /**
                * Submit del form de cálculo actual.
                * Se hace Submit de la form via AJAX, y así obtener el resultado y luego
                * mostrarlo en el panel de resultado
                */
            $('#formCalculoActual').submit(function (event) {
                event.preventDefault();

                var formData = convertSerializedArray($(this).serializeArray());

                var result =
                    speciesCalculation
                        .calculateCarbon(speciesFactory.currentSpecies, formData.dap / 100, formData.altura, formData.numArboles);

                $('#panelResultadoActual').css('display', 'block');
                $('#lblResultado').html(result.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') +
                    " Toneladas de carbono por hectarea (tC/ha)");
                //Toneladas de CO2 por hectarea fijados del ambiente.
            });

            /**
                * Submit del form de cálculo proyectado.
                * Se hace Submit de la form via AJAX, y así obtener el resultado y luego
                * mostrarlo en el panel de resultado
                */
            $('#btnSubmitProyectado').click(event => {
                event.preventDefault();

                let years = parseInt($('#txtYearsP').val());
                let number = parseInt($('#txtNum').val());
                let values = [];

                // Si la opción de raleos está seleccionada, obtiene sus valores
                if ($('#checkRaleo').prop('checked')) {
                    let raleos = [];

                    for (var i = 0; i < raleosControl.number; i++) {
                        let year = parseInt($('#selRaleo' + i).val());
                        let percent = parseInt($('#inpRaleo' + i).val());
                        raleos.push({ year: year, percent: 1 - (percent / 100) });
                    }

                    raleos.sort(a => a.year);

                    values =
                        speciesCalculation
                            .createProjectionsWhitRaleos(speciesFactory.currentSpecies, raleos, years, number);
                } else {
                    values =
                        speciesCalculation
                            .createProjections(speciesFactory.currentSpecies, years, number);
                }

                setNavValues(values);

                resetTabs();

                $('#graph-result').data('values', values);
                $('#panelResultadoProyectado').css('display', 'block');
                $('#btnExportar').show();
                showGraph(values.carbono, GRAPH_CARBON);

                // Si se usan raleos, utiliza diferente función para mostrar data
                if ($('#checkRaleo').prop('checked')) {
                    // Genera tabla HTML
                    $('#tablaProyectada').html(generateTableProjected(values.carbono));
                } else {
                    $('#tablaProyectada').html(generateTable(values.carbono));
                }
            });

            //Se obtiene el listado de especies del "speciesFactory" y 
            // establece ese listado en los dropdowns de la vista.
            speciesFactory.getSimpleNamesToDropdown().then(species => {

                let option = document.createElement('option');
                option.setAttribute('value', 0);
                option.innerHTML = 'Seleccione una opción.';
                document.getElementById("sel_especieP").appendChild(option);

                $('#sel_especieP')
                    .select2({
                        data: species
                    })
                    .on('select2:select', function (e) {

                        let id = $(this).val();

                        if (id == 0) {
                            return;
                        }

                        speciesFactory.getById(id).then(species => {

                            speciesFactory.currentSpecies = species;

                            $('#sel_sitio').html('');
                            $('#sel_sitio')
                                .select2({ data: speciesFactory.currentSpecies.GroundIndexes })
                                .on('select2:select', function (e) {
                                    selectSpeciesSiteIndex($(this).val());
                                });
                        }).then(() =>
                            $('#sel_sitio')
                                .val(speciesFactory.currentSpecies.currentSpeciesGroundIndex.value + '')
                                .prop('selected', true)
                        );
                    });

                $('#sel_especie').select2({
                    data: species
                });

            });

            document.getElementById("btnAgregarRaleo").onclick = addInputsRaleo;

            document.getElementById("btnEliminarRaleo").onclick = removeInputsRaleo;
        }

        const selectSpeciesSiteIndex = siteIndexId => {

            var speciesGroundIndex =
                speciesFactory.currentSpecies.GroundIndexes.find(sgi => sgi.id == siteIndexId);

            speciesFactory.currentSpecies.currentSpeciesGroundIndex =
                speciesGroundIndex;
        }

        init();

    });
});