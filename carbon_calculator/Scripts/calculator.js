﻿
$(document).ready(function () {
    $(function () {

        const SUMA_RALEOS = 100;
        const GRAPH_CARBON = 1;
        const GRAPH_AREA = 2;
        const GRAPH_DAP = 3;
        const GRAPH_HEIGHT = 4;
        const GRAPH_VOL = 5;

        var datos_carbono,
            datos_area,
            datos_dap,
            datos_volumen,
            datos_altura;

        var chart;

        let urlProyectado = $("#btnSubmitProyectado").data('postUrl');
        let urlIndices = $('#calc_proyeccion').data('url');

        let species = [
            "Pinabete", "Cedro Rosado", "Aliso", "Nim", "Aripin", "Santa María", "Casuarina",
            "Cedro", "Cipres Común", "Conacaste", "Melina", "Caulote", "Canoj", "Pino Caribe",
            "Pino Candelillo", "Pino Ocote", "Pino Pátula", "Pino Triste", "Palo de Sangre",
            "Casia", "Palo Volador", "Caoba", "Palo Blanco", "Matilisguate", "Teca", "Pukté",
            "Guayabon", "San Juan"
        ];

        $('[data-toggle="tooltip"]').tooltip();

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
                content += '<td style="text-align: center">' + data[i] + '</td>';
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
            actData.forEach(function (element, index, array) {
                header += '<th style="text-align: center" nowrap>Año ' + index + '</th>';
                content += '<td style="text-align: center">' + element.toString() + '</td>';
            });

            return finalTable.format(header, content);
        }

        /**
            * Función que agrega <option> a Select de años de raleo, según la cantidad ingresada en input
            * param {int} years: cantidad de años
            */
        function addYearsSelects(years) {

            $('#sel_raleo1').find('option').remove();
            $('#sel_raleo2').find('option').remove();

            var firstYear = (new Date()).getFullYear();
            var lastYear = firstYear + years;

            $('#sel_raleo2').append($('<option>', {
                value: 0,
                text: "Sin Raleo"
            }));

            var count_years = 1;
            // Agrega <option> según cantidad de años
            for (var i = firstYear; i < lastYear; i++) {
                $('#sel_raleo1').append($('<option>', {
                    value: count_years,
                    text: i.toString()
                }));
                $('#sel_raleo2').append($('<option>', {
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
            $('#nav-area').parent().removeClass('active');
            $('#nav-altura').parent().removeClass('active');
            $('#nav-dap').parent().removeClass('active');
            $('#nav-volumen').parent().removeClass('active');
        }

        /**
         * Función que hace llamada al controlador para obtener los índices de sitio de una especie específica
         * @param {string} especie nombre de la especie
         */
        function getIndicesDeSitio(especie) {
            var url = $('#calc_proyeccion').data('url');
            
            $.ajax({
                url: urlIndices,
                method: "POST",
                data: {
                    especie: especie
                },
                success: function (data) {
                    var status = data.status;
                    // Llamada correcta, muestra resultado
                    if (status == 200) {
                        $('#sel_sitio').html('');
                        $('#sel_sitio').select2({ data: data.response });
                    }
                },
                error: function (requestObject, error, errorThrown) {
                    alert('Error al obtener índices de sitio');
                }
            });
        }

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
                addYearsSelects(parseInt(newVal));
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

        // Cambio del Combobox de Año raleo 2
        $("#sel_raleo2").change(function () {
            // Si selecciona "Sin Raleo", limpia campo del %
            if ($("#sel_raleo2").val() === "0") {
                $('#pct2').val('');
                $('#pct2').prop('required', false);
            } else {
                $('#pct2').prop('required', true);
            }
        });

        // Muestra gráfica y tabla de carbono al volver esta Tab como Actual
        $('#nav-carbono').on('click', function () {
            if (!$(this).parent().hasClass('active')) {
                if ($('#checkRaleo').prop('checked')) {
                    $('#tablaProyectada').html(generateTableProjected(datos_carbono));
                } else {
                    $('#tablaProyectada').html(generateTable(datos_carbono));
                }
                showGraph(datos_carbono, GRAPH_CARBON);
            }
        });

        // Muestra gráfica y tabla de altura al volver esta Tab como Actual
        $('#nav-altura').on('click', function () {
            if (!$(this).parent().hasClass('active')) {
                if ($('#checkRaleo').prop('checked')) {
                    $('#tablaProyectada').html(generateTableProjected(datos_altura));
                } else {
                    $('#tablaProyectada').html(generateTable(datos_altura));
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
            let urlActual = $("#btnSubmitActual").data('postUrl');

            $.ajax({
                url: urlActual,
                method: "POST",
                data: formData,
                success: function (data) {
                    var status = data.status;
                    // Llamada correcta, muestra resultado
                    if (status == 200) {
                        $('#panelResultadoActual').css('display', 'block');
                        $('#lblResultado').html(data.response + " Unidades de Carbono");
                    }
                },
                error: function (requestObject, error, errorThrown) {
                    alert('Error en cálculo');
                }
            });
        });

        /**
            * Submit del form de cálculo proyectado.
            * Se hace Submit de la form via AJAX, y así obtener el resultado y luego
            * mostrarlo en el panel de resultado
            */
        $('#formCalculoProyectado').submit(function (event) {
            event.preventDefault();
            var formData = convertSerializedArray($(this).serializeArray());
            var sumaRaleo = 0;

            // Si el año de los raleos es distinto, sí lo toma en cuenta.
            if (formData.sel_raleo1 !== formData.sel_raleo2) {

                var raleo = {};
                // Si la opción de raleos está seleccionada, obtiene sus valores
                if ($('#checkRaleo').prop('checked')) {

                    if (formData.pct1 > 0 && formData.pct1 <= 50) {

                        raleo[formData.sel_raleo1] = formData.pct1;
                        // Si sí hay raleo, agrega propiedad a objeto
                        if (formData.sel_raleo2 !== "0") {

                            if (formData.pct2 > 0 && formData.pct2 <= 50) {

                                raleo[formData.sel_raleo2] = formData.pct2;
                                sumaRaleo = parseInt(raleo[formData.sel_raleo1]) + parseInt(raleo[formData.sel_raleo2]);
                            }
                            else {
                                alert("Raleos deben ser menor o igual a 50%");
                            }

                        } else
                            sumaRaleo = parseInt(raleo[formData.sel_raleo1]);
                    }
                    else {
                        alert("Raleos deben ser menor o igual a 50%");
                    }
                }

                // Elimina campos de raleo del Form
                delete formData['pct1'];
                delete formData['pct2'];
                delete formData['sel_raleo1'];
                delete formData['sel_raleo2'];

                // Agrega objeto de raleo a campos del Form
                formData['raleo'] = JSON.stringify(raleo);
            } else {
                alert('Debe seleccionar años diferentes');
            }

            // Verifica que la suma de raleos esté correcta
            if (sumaRaleo <= SUMA_RALEOS) {

                // Cantidad de árboles será igual a # árboles por hectarea * cantidad de hectareas
                let contHectarea = formData['contHectarea'];
                formData['numArboles'] = parseFloat(formData['numArboles']) * (contHectarea == '' ? 1 : contHectarea);

                $.ajax({
                    url: urlProyectado,
                    method: "POST",
                    data: formData,
                    success: function (data) {
                        var status = data.status;
                        var values = data.response;
                        // Llamada correcta, muestra resultado
                        if (status == 200) {
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
                        }
                    },
                    error: function (requestObject, error, errorThrown) {
                        alert('Error en cálculo');
                    }
                });
            } else {
                alert("La suma de los raleos debe ser menor o igual al 100%");
            }
        });

        // Inicialisamos select2 de Especies para cálculo actual
        $('#sel_especie').select2({
            data: species
        });

        // Inicializamos select2 de Especies para cálculo proyectado. Cuando cambie un elemento, traerá especies
        $('#sel_especieP').select2({
            data: species
        }).on('select2:select', function (e) {
            getIndicesDeSitio($(this).val());
        });

     

        // Obtenemos indices de primer elemento
        getIndicesDeSitio(species[0]);

    });
});