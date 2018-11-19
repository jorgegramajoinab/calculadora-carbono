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

    this.createProjections =
        (specie, years, number = 1) => {
            let result = {
                carbono: [],
                altura: [],
                area: [],
                dap: [],
                volumen: [],
            };

            console.log(specie);

            parameters.t = years;
            parameters.n = number;
            parameters.s = specie.currentSpeciesGroundIndex.value;
            parameters.ff = specie.shapeCoefficient;
            parameters.ms = specie.dryMaterial;

            let heightExpression = specie.MathExpressions.find(mathExpression => mathExpression.Key == "height");
            let dapExpression = specie.MathExpressions.find(mathExpression => mathExpression.Key == "dap");
            let areaExpression = specie.MathExpressions.find(mathExpression => mathExpression.Key == "area");
            let volumeExpression = specie.MathExpressions.find(mathExpression => mathExpression.Key == "volume");

            for (var i = 1; i < years + 1; i++) {
                parameters.t = i;
                result.altura.push(utilities.approximate(parameters.h = math.eval(heightExpression.Expression, parameters)));
                result.area.push(utilities.approximate(math.eval(areaExpression.Expression, parameters)));
                result.dap.push(utilities.approximate(parameters.d = math.eval(dapExpression.Expression, parameters)));
                result.volumen.push(utilities.approximate(parameters.vol = math.eval(volumeExpression.Expression, parameters)));
                result.carbono.push(utilities.approximate(math.eval(projectedCarbonPExpression, parameters)));
            }

            return result;
        }

    const createProjection =
        (specie, year, number, expression, array) => {
            /**variable that stores the result of the operation.*/
            let result = 0;

            /**Establishment of parameters.*/
            parameters.t = year;

            /**the mathematical expression is evaluated. */
            result = math.eval(expression, parameters);

            /**the result is approaching.*/
            result = utilities.approximate(result);

            /**the result is added to the array.*/
            array.push(result);

            return result;
        }

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