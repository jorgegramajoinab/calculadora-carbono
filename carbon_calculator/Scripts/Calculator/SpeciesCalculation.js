function SpeciesCalculation() {
    let carbonExpression = "(pi/4)(d^2)n*h*ff*ms*pc*feb";
    let projectedCarbonPExpression = "vol*ms*pc*feb";
    let utilities = new Utilities();

    let parameters = {
        /**Indice de sitio.*/
        s: 0,
        /**Año.*/
        t: 0,
        /**Número de plantas. */
        n: 0,
        /**Coeficiente de forma. */
        ff: 0,
        /**Porcentaje de materia seca. */
        ms: 0,
        /**Altura. */
        h: 0,
        /**Diametro a la altura del pecho (DAP). */
        d: 0,
        /**Porcentaje de carbono. */
        pc: .5,
        /**Factor de extención de biomasa. */
        feb: 1.6,
        /**Volumen */
        vol: 0
    };

    function Result() {
        this.carbono = [];
        this.altura = [];
        this.area = [];
        this.dap = [];
        this.volumen = [];
    }

    const getMathExpressions =
        specie => {
            let heightExpression =
                specie.MathExpressions
                    .find(mathExp => mathExp.Key == "height")
                    .Expression;
            let dapExpression =
                specie.MathExpressions
                    .find(mathExp => mathExp.Key == "dap")
                    .Expression;
            let areaExpression =
                specie.MathExpressions
                    .find(mathExp => mathExp.Key == "area")
                    .Expression;
            let volumeExpression =
                specie.MathExpressions
                    .find(mathExp => mathExp.Key == "volume")
                    .Expression;

            return {
                heightExpression: heightExpression,
                dapExpression: dapExpression,
                areaExpression: areaExpression,
                volumeExpression: volumeExpression
            }
        }

    const createProjection =
        (year, number, expression, array) => {
            /**variable that stores the result of the operation.*/
            let result = 0;

            /**Establishment of parameters.*/
            parameters.t = year;
            parameters.n = number;

            /**the mathematical expression is evaluated. */
            result = math.eval(expression, parameters);

            /**the result is approaching.*/
            result = utilities.approximate(result);

            /**the result is added to the array.*/
            array.push([year, result]);

            return result;
        }

    const setSpecieParameters =
        specie => {
            parameters.s = specie.currentSpeciesGroundIndex.value;
            parameters.ff = specie.shapeCoefficient;
            parameters.ms = specie.dryMaterial;
        }

    this.createProjectionsWhitRaleos =
        (specie, raleos, years, number = 1) => {
            let result = new Result();

            raleos.forEach(raleo => console.log("AR: ", raleo));

            setSpecieParameters(specie);

            let mathExpressions =
                getMathExpressions(specie);

            for (var year = 0; year < years; year++) {
                createProjection(year, number, mathExpressions.heightExpression, result.altura);
                createProjection(year, number, mathExpressions.areaExpression, result.area);
                createProjection(year, number, mathExpressions.dapExpression, result.dap);
                parameters.vol = createProjection(year, number, mathExpressions.volumeExpression, result.volumen);
                createProjection(year, number, projectedCarbonPExpression, result.carbono);

                if (utilities.elementsInArray(raleos)) {
                    let index = raleos.findIndex(raleo => raleo.year == year);
                    let raleo = raleos[index];

                    if (raleo != null) {
                        raleos.splice(index, 1);
                        number *= raleo.percent;
                        year--;
                    }
                }
            }

            return result;
        }

    this.createProjections =
        (specie, years, number = 1) => {
            let result = new Result();
            
            setSpecieParameters(specie);

            let mathExpressions =
                getMathExpressions(specie);

            for (var year = 1; year < years + 1; year++) {
                createProjection(year, number, mathExpressions.heightExpression, result.altura);
                createProjection(year, number, mathExpressions.areaExpression, result.area);
                createProjection(year, number, mathExpressions.dapExpression, result.dap);
                parameters.vol = createProjection(year, number, mathExpressions.volumeExpression, result.volumen);
                createProjection(year, number, projectedCarbonPExpression, result.carbono);
            }

            return result;
        }

    /**
     * Function to calculate the current carbon.
     * @param {any} specie Plant type
     * @param {number} dap Diameter at breast height.
     * @param {number} height Average height.
     * @param {number} number (Density) Number of trees per hectare.
     */
    this.calculateCarbon =
        (specie, dap, height, number = 1) => {
            parameters.d = dap;
            parameters.n = number;
            parameters.h = height
            parameters.ff = specie.shapeCoefficient;
            parameters.ms = specie.dryMaterial;

            return utilities.approximate(math.eval(carbonExpression, parameters));
        }

}