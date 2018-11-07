namespace model.Migrations
{
    using model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<model.CarbonCalculatorModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(model.CarbonCalculatorModel context)
        {
            if (!context.Species.Any())
            {
                addSpecies(context);
                context.SaveChanges();
            }
        }

        private void addCoefficient(Species species, string coefficientKey, double value) =>
            species.Coefficients
                .Add(new Coefficient(coefficientKey, value));

        private void addHeights(Species species, double[] heights) =>
            Array.ForEach(heights,
                height => addCoefficient(species, Coefficient.Height, height));

        private void addDAP(Species species, double[] daps) =>
            Array.ForEach(daps,
                dap => addCoefficient(species, Coefficient.DAP, dap));

        private void addAreas(Species species, double[] areas) =>
            Array.ForEach(areas,
                area => addCoefficient(species, Coefficient.Area, area));

        private void addVolumes(Species species, double[] volumes) =>
            Array.ForEach(volumes,
                volume => addCoefficient(species, Coefficient.Volume, volume));


        private void addSpecies(CarbonCalculatorModel context)
        {
            var giUnico = new GroundIndex()
            {
                name = "Único",
                defaultValue = 0
            };
            var giPesimo = new GroundIndex()
            {
                name = "Pésimo",
                defaultValue = 0
            };
            var giMalo = new GroundIndex()
            {
                name = "Malo",
                defaultValue = 0
            };
            var giMedio = new GroundIndex()
            {
                name = "Medio",
                defaultValue = 0
            };
            var giBueno = new GroundIndex()
            {
                name = "Bueno",
                defaultValue = 0
            };
            var giExcelente = new GroundIndex()
            {
                name = "Excelente",
                defaultValue = 0
            };

            var Pinabete = new Species
            {
                commonName = "Pinabete (Pashaque, Abeto)",
                scientificName = "Abies guatemalensis Rehder",
                shapeCoefficient = 0.5,
                limitYear = 18,
                dryMaterial = 0.5
            };

            addHeights(Pinabete, new double[] { -20.378291 });
            addDAP(Pinabete, new double[] { 4.627246, -11.360686, -0.006167, -0.00133 });
            addAreas(Pinabete, new double[] { 5.447094, -21.576918, -0.015678, -0.001387 });
            addVolumes(Pinabete,  new double[] { 8.352033, -41.928436, 0.014195, -0.00184 });

            Pinabete.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 8.58));

            context.Species.Add(Pinabete);

            var CedroRosado = new Species
            {
                commonName = "Cedro Rosado (Cedro roso, Mundani)",
                scientificName = "Acrocarpus fraxinifolius Wight &Arn",
                shapeCoefficient = 0.5,
                limitYear = 18,
                dryMaterial = 0.5
            };

            addHeights(CedroRosado, new double[] { -3.638221 });
            addDAP(CedroRosado, new double[] { 2.805506, -2.624873, 0.029507, -0.000251 });
            addAreas(CedroRosado, new double[] { 1.649195, -5.046975, 0.054066, 0.001012 });
            addVolumes(CedroRosado,  new double[] { 3.117363, -8.840466, 0.107077, 0.000951 });

            CedroRosado.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 16.7));
            CedroRosado.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 21.9));
            CedroRosado.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 27.9));

            context.Species.Add(CedroRosado);

            var aliso = new Species
            {
                commonName = "Aliso",
                scientificName = "Alnus jorullensis Kunth",
                shapeCoefficient = 0.5,
                limitYear = 20,
                dryMaterial = 0.5
            };

            addHeights(aliso, new double[] { -5.183772 });
            addDAP(aliso, new double[] { 3.479904, -5.100774, 0.005329, -0.000192 });
            addAreas(aliso, new double[] { 2.046634, -13.359966, 0.071346, 0.001672 });
            addVolumes(aliso,  new double[] { 5.002828, -19.579749, 0.028559, 0.001735 });

            aliso.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 13.91));

            context.Species.Add(aliso);

            var nim = new Species
            {
                commonName = "Nim (Neem)",
                scientificName = "Azadirachta indica A. Juss",
                shapeCoefficient = 0.5,
                limitYear = 9,
                dryMaterial = 0.5
            };

            addHeights(nim, new double[] { -1.725435 });
            addDAP(nim, new double[] { 1.567832, -2.675935, 0.100498, 0.000284 });
            addAreas(nim, new double[] { -0.421023, -5.328057, 0.199157, 0.001581 });
            addVolumes(nim,  new double[] { -0.96776, -7.358693, 0.307991, 0.002469 });

            nim.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 6.51));
            nim.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 10.09));

            context.Species.Add(nim);

            var Aripin = new Species
            {
                commonName = "Aripin",
                scientificName = "Caesalpinia velutina",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(Aripin, new double[] { -1.872405 });
            addDAP(Aripin, new double[] { 1.983661, -2.330208, 0.095564, -0.000385 });
            addAreas(Aripin, new double[] { 0.83226, -4.71375, 0.189626, -0.000097 });
            addVolumes(Aripin,  new double[] { 1.278762, -7.15454, 0.35243, -0.000352 });

            Aripin.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 8.03));

            context.Species.Add(Aripin);

            var SantaMaria = new Species
            {
                commonName = "Santa María (Marío, leche)",
                scientificName = "Calophyllum brasiliense Cambess",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5
            };

            addHeights(SantaMaria, new double[] { -7.657288 });
            addDAP(SantaMaria, new double[] { 3.861522, -7.008542, 0.027548, -0.001144 });
            addAreas(SantaMaria, new double[] { 4.181024, -13.83883, 0.051651, -0.001286 });
            addVolumes(SantaMaria,  new double[] { 6.72825, -21.067206, 0.087027, -0.002144 });

            SantaMaria.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 11.72));

            context.Species.Add(SantaMaria);

            var Casuarina = new Species
            {
                commonName = "Casuarina",
                scientificName = "Casuarina equisetifolia L.",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(Casuarina, new double[] { -5.886381 });
            addDAP(Casuarina, new double[] { 3.041145, -8.076789, -0.014162, -0.000069 });
            addAreas(Casuarina, new double[] { 2.462079, -17.066455, -0.019585, 0.00093 });
            addVolumes(Casuarina,  new double[] { 4.147779, -16.451739, -0.039504, 0.000229 });

            Casuarina.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 7.1));

            context.Species.Add(Casuarina);

            var Cedro = new Species
            {
                commonName = "Cedro (Cedro rojo)",
                scientificName = "Cedrela odorata L.",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5
            };

            addHeights(Cedro, new double[] { -4.034014 });
            addDAP(Cedro, new double[] { 2.334384, -4.530798, 0.145447, -0.001743 });
            addAreas(Cedro, new double[] { -0.173934, -9.532625, 0.302835, -0.000013 });
            addVolumes(Cedro,  new double[] { 0.988436, -11.063187, 0.417214, -0.002467 });

            Cedro.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 7));

            context.Species.Add(Cedro);

            var CipresComun = new Species
            {
                commonName = "Cipres Común (Ciprés)",
                scientificName = "Cupressus lusitanica Mill.",
                shapeCoefficient = 0.5,
                limitYear = 19,
                dryMaterial = 0.5
            };

            addHeights(CipresComun, new double[] { -6.731967 });
            addDAP(CipresComun, new double[] { 2.707584, -5.677218, 0.067381, -0.000247 });
            addAreas(CipresComun, new double[] { 2.045355, -10.794574, 0.118218, 0.00037 });
            addVolumes(CipresComun,  new double[] { 3.118363, -17.429548, 0.215077, 0.000309 });

            CipresComun.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 6));
            CipresComun.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 9.25));
            CipresComun.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 12.50));
            CipresComun.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 14.75));
            CipresComun.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 17));

            context.Species.Add(CipresComun);

            var Conacaste = new Species
            {
                commonName = "Conacaste",
                scientificName = "Enterolobium cyclocarpum",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5
            };

            addHeights(Conacaste, new double[] { -4.624413 });
            addDAP(Conacaste, new double[] { 2.274322, -6.302477, 0.086746, 0.000159 });
            addAreas(Conacaste, new double[] { 1.102299, -12.647657, 0.170789, 0.001247 });
            addVolumes(Conacaste,  new double[] { 2.049391, -18.839421, 0.264324, 0.001348 });

            Conacaste.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 9));

            context.Species.Add(Conacaste);

            var Melina = new Species
            {
                commonName = "Melina",
                scientificName = "Gmelina arbórea Roxb. ex. Sm",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5
            };

            addHeights(Melina, new double[] { -4.589766 });
            addDAP(Melina, new double[] { 2.476769, -3.669808, 0.048356, -0.000258 });
            addAreas(Melina, new double[] { 0.780617, -7.094758, 0.092946, 0.001186 });
            addVolumes(Melina,  new double[] { 1.918322, -11.678936, 0.160806, 0.001068 });

            Melina.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 8.62));
            Melina.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 14.31));
            Melina.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 20.01));
            Melina.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 24.18));
            Melina.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 28.35));

            context.Species.Add(Melina);

            var Caulote = new Species
            {
                commonName = "Caulote",
                scientificName = "Guazuma ulmifolia Lam",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5
            };

            addHeights(Caulote, new double[] { -0.684405 });
            addDAP(Caulote, new double[] { 2.762289, -2.32964, 0.014772, -0.000567 });
            addAreas(Caulote, new double[] { 2.143734, -4.666703, 0.028075, -0.000276 });
            addVolumes(Caulote,  new double[] { 1.966696, -6.206873, 0.119088, 0.000292 });

            Caulote.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 6.54));

            context.Species.Add(Caulote);

            var Canoj = new Species
            {
                commonName = "Canoj",
                scientificName = "Guazuma ulmifolia Lam",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5
            };

            addHeights(Canoj, new double[] { -8.798094 });
            addDAP(Canoj, new double[] { 3.112788, -6.202454, 0.078664, -0.001055 });
            addAreas(Canoj, new double[] { 2.642654, -12.355272, 0.1598, -0.00112 });
            addVolumes(Canoj,  new double[] { 4.313634, -21.102053, 0.245205, -0.001508 });

            Canoj.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 13.33));

            context.Species.Add(Canoj);

            var PinoCaribe = new Species
            {
                commonName = "Pino Caribe (Pino de Petén)",
                code = "PINUCH",
                scientificName = "Pinus Caribaea var. hondurensis (Sénécl.) W. H. Barret & Golfari",
                shapeCoefficient = 0.5,
                limitYear = 25,
                dryMaterial = 0.5
            };

            /* Asignacion de coeficientes de altura dominante */
            addHeights(PinoCaribe, new double[] { -7.458911 });
            /* Asignacion de coeficientes de DAP */
            addDAP(PinoCaribe, new double[] { 2.673197, -5.545766, 0.056028, -0.000142 });
            /* Asignacion de coeficientes de Area basal */
            addAreas(PinoCaribe, new double[] { 1.325956, -11.038033, 0.091341, 0.001634 });
            /* Asignacion de coeficientes de volumen */
            addVolumes(PinoCaribe, new double[] { 2.671109, -18.578108, 0.171615, 0.001541 });

            PinoCaribe.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 9.43));
            PinoCaribe.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 12.46));
            PinoCaribe.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 15.49));
            PinoCaribe.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 17.36));
            PinoCaribe.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 19.23));

            context.Species.Add(PinoCaribe);

            var PinoCandelillo = new Species
            {
                commonName = "Pino Candelillo",
                code = "PINUMI",
                scientificName = "Pinus Maximinoi H. E. Moore",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            /* Asignacion de coeficientes de altura dominante */
            addHeights(PinoCandelillo, new double[] { -6.96328 });
            /* Asignacion de coeficientes de DAP */
            addDAP(PinoCandelillo, new double[] { 2.853221, -5.94932, 0.055943, -0.000218 });
            /* Asignacion de coeficientes de Area basal */
            addAreas(PinoCandelillo, new double[] { 1.91575, -11.592777, 0.100823, 0.000843 });
            /* Asignacion de coeficientes de volumen */
            addVolumes(PinoCandelillo, new double[] { 3.160695, -18.203956, 0.182736, 0.000775 });

            PinoCandelillo.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 8.18));
            PinoCandelillo.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 11.65));
            PinoCandelillo.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 15.12));
            PinoCandelillo.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 18.26));
            PinoCandelillo.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 21.40));

            context.Species.Add(PinoCandelillo);

            var PinoOcote = new Species
            {
                commonName = "Pino Ocote (Pino colorado)",
                code = "PINUOO",
                scientificName = "Pinus sp Schiede",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            /* Asignacion de coeficientes de altura dominante */
            addHeights(PinoOcote, new double[] { -6.498108 });
            /* Asignacion de coeficientes de DAP */
            addDAP(PinoOcote, new double[] { 2.426552, -6.706013, 0.075921, 0.00004 });
            /* Asignacion de coeficientes de Area basal */
            addAreas(PinoOcote, new double[] { 1.060976, -13.35596, 0.15187, 0.001278 });
            /* Asignacion de coeficientes de volumen */
            addVolumes(PinoOcote, new double[] { 2.246512, -20.855741, 0.242321, 0.001267 });

            PinoOcote.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 5.92));
            PinoOcote.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 9.67));
            PinoOcote.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 13.42));
            PinoOcote.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 15.64));
            PinoOcote.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 17.86));

            context.Species.Add(PinoOcote);

            var PinoPatula = new Species
            {
                commonName = "Pino Pátula",
                scientificName = "Pinus patula Schltdl. & Cham.",
                shapeCoefficient = 0.5,
                limitYear = 10,
                dryMaterial = 0.5
            };

            addHeights(PinoPatula, new double[] { -6.921948 });
            addDAP(PinoPatula, new double[] { 1.842624, -7.912709, 0.204784, -0.000193 });
            addAreas(PinoPatula,  new double[] { 0.592964, -16.050104, 0.399771, 0.000318 });
            addVolumes(PinoPatula,  new double[] { 1.57958, -21.303008, 0.507162, 0.000117 });

            PinoPatula.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 8.53));

            context.Species.Add(PinoPatula);

            var PinoTriste = new Species
            {
                commonName = "Pino Triste (Pino blanco)",
                scientificName = "Pinus pseudostrobus Lindl",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(PinoTriste, new double[] { -11.729867 });
            addDAP(PinoTriste, new double[] { 3.298035, -10.936875, 0.065073, -0.000083 });
            addAreas(PinoTriste,  new double[] { 2.367995, -21.373573, 0.153433, 0.001055 });
            addVolumes(PinoTriste,  new double[] { 4.039077, -32.749693, 0.242141, 0.000967 });

            PinoTriste.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 8.32));
            PinoTriste.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 10.77));
            PinoTriste.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 13.21));
            PinoTriste.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 14.16));
            PinoTriste.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 16.01));

            context.Species.Add(PinoTriste);

            var PaloDeSangre = new Species
            {
                commonName = "Palo de Sangre (Sangre y cahué)",
                scientificName = "Pinus pseudostrobus Lindl",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5
            };

            addHeights(PaloDeSangre, new double[] { -8.864079 });
            addDAP(PaloDeSangre, new double[] { 2.533776, -6.885158, 0.065936, -0.000115 });
            addAreas(PaloDeSangre,  new double[] { 1.129202, -14.091632, 0.126178, 0.001344 });
            addVolumes(PaloDeSangre,  new double[] { 2.56331, -23.018699, 0.214254, 0.001243 });

            PaloDeSangre.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 11.21));
            PaloDeSangre.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 13.32));
            PaloDeSangre.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 16.05));

            context.Species.Add(PaloDeSangre);

            var Casia = new Species
            {
                commonName = "Casia",
                scientificName = "Pinus pseudostrobus Lindl",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(Casia, new double[] { -6.116833 });
            addDAP(Casia, new double [] { 1.49521, -1.851407, 0.116224, -0.000438 });
            addAreas(Casia,  new double[] { -0.306671, -4.378177, 0.225725, -0.000003 });
            addVolumes(Casia,  new double[] { 0.584018, -9.960148, 0.294692, 0.000274 });

            Casia.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 10.17));

            context.Species.Add(Casia);

            var PaloVolador = new Species
            {
                commonName = "Palo Volador",
                scientificName = "Simira salvadorensis",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(PaloVolador, new double[] { -7.563575 });
            addDAP(PaloVolador, new double [] { 2.624014, -10.108301, 0.030276, 0.000414 });
            addAreas(PaloVolador,  new double[] { 1.609769, -20.178575, 0.060325, 0.001922 });
            addVolumes(PaloVolador,  new double[] { 5.394304, -23.23099, 0.128387, -0.001331 });

            PaloVolador.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 14.47));

            context.Species.Add(PaloVolador);

            var Caoba = new Species
            {
                commonName = "Caoba (Caoba del norte)",
                scientificName = "Swietenia macrophylla",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(Caoba, new double[] { -10.900122 });
            addDAP(Caoba, new double [] { 2.630349, -10.089983, 0.075246, 0.000075 });
            addAreas(Caoba,  new double[] { 0.830452, -20.722084, 0.164495, 0.001994 });
            addVolumes(Caoba,  new double[] { 2.239672, -32.894188, 0.260104, 0.002181 });

            Caoba.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 5.40));
            Caoba.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 9.32));
            Caoba.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 13.24));
            Caoba.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 15.60));
            Caoba.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 17.96));

            context.Species.Add(Caoba);

            var PaloBlanco = new Species
            {
                commonName = "Palo Blanco",
                code = "TABEDO",
                scientificName = "Tabebuia donnel-smithii Rose",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5
            };

            /* Asignacion de coeficientes de altura dominante */
            addHeights(PaloBlanco, new double[] { -3.617786 });
            /* Asignacion de coeficientes de DAP */
            addDAP(PaloBlanco, new double[] { 1.663888, -2.480653, 0.089199, -0.000146 });
            /* Asignacion de coeficientes de Area basal */
            addAreas(PaloBlanco, new double[] { -0.668643, -4.714003, 0.181244, 0.00101 });
            /* Asignacion de coeficientes de volumen */
            addVolumes(PaloBlanco, new double[] { 0.117821, -8.184507, 0.271737, 0.000896 });

            PaloBlanco.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 6.15));
            PaloBlanco.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 9.55));
            PaloBlanco.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 12.95));
            PaloBlanco.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 15.74));
            PaloBlanco.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 18.53));


            context.Species.Add(PaloBlanco);

            var Matilisguate = new Species
            {
                commonName = "Matilisguate",
                scientificName = "Swietenia macrophylla",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(Matilisguate, new double[] { -3.662898 });
            addDAP(Matilisguate, new double [] { 1.320543, -4.009256, 0.158326, -0.000237 });
            addAreas(Matilisguate,  new double[] { -1.422144, -8.124784, 0.299527, 0.001255 });
            addVolumes(Matilisguate,  new double[] { -1.137584, -12.265933, 0.4431, 0.001109 });

            Matilisguate.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 3.83));
            Matilisguate.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 5.90));
            Matilisguate.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 7.97));
            Matilisguate.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 10.85));
            Matilisguate.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 13.73));

            context.Species.Add(Matilisguate);

            var Teca = new Species
            {
                commonName = "Teca",
                code = "TECTGR",
                scientificName = "Tectona GrandisL. f.",
                shapeCoefficient = 0.5,
                limitYear = 17,
                dryMaterial = 0.5
            };

            /* Asignacion de coeficientes de altura dominante */
            addHeights(Teca, new double[] { -3.891677 });
            /* Asignacion de coeficientes de DAP */
            addDAP(Teca, new double[] { 2.293225, -4.118555, 0.052407, -0.000131 });
            /* Asignacion de coeficientes de Area basal */
            addAreas(Teca, new double[] { 0.613447, -7.899548, 0.09739, 0.001207 });
            /* Asignacion de coeficientes de volumen */
            addVolumes(Teca, new double[] { 1.605596, -12.336335, 0.166684, 0.001142 });

            Teca.GroundIndexes.Add(new SpeciesGroundIndex(giPesimo, 7.60));
            Teca.GroundIndexes.Add(new SpeciesGroundIndex(giMalo, 13.34));
            Teca.GroundIndexes.Add(new SpeciesGroundIndex(giMedio, 19.07));
            Teca.GroundIndexes.Add(new SpeciesGroundIndex(giBueno, 24.36));
            Teca.GroundIndexes.Add(new SpeciesGroundIndex(giExcelente, 29.65));

            context.Species.Add(Teca);

            var Pukte = new Species
            {
                commonName = "Pukté",
                scientificName = "Terminalia buceras",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(Pukte, new double[] { -1.741207 });
            addDAP(Pukte, new double [] { 3.257189, -3.956527, 0.009321, 0 });
            addAreas(Pukte,  new double[] { 3.695791, -7.913055, -0.018641, 0 });
            addVolumes(Pukte,  new double[] { 4.588308, -10.377622, 0.049617, 0 });

            Pukte.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 9.92));

            context.Species.Add(Pukte);

            var Guayabon = new Species
            {
                commonName = "Guayabon",
                scientificName = "Terminalia buceras",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(Guayabon, new double[] { -7.206822 });
            addDAP(Guayabon, new double [] { 2.537212, -5.780087, 0.00923, 0.00057 });
            addAreas(Guayabon,  new double[] { 1.203433, -11.513972, 0.018414, 0.00251 });
            addVolumes(Guayabon,  new double[] { 3.066308, -19.106921, 0.07381, 0.002185 });

            Guayabon.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 14.47));

            context.Species.Add(Guayabon);

            var SanJuan = new Species
            {
                commonName = "San Juan",
                scientificName = "Vochysia guatemalensis Donn. Sm.",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5
            };

            addHeights(SanJuan, new double[] { -8.904588 });
            addDAP(SanJuan, new double [] { 2.769514, -7.431654, 0.050203, -0.000043 });
            addAreas(SanJuan,  new double[] { 1.651327, -15.314681, 0.099127, 0.001388 });
            addVolumes(SanJuan,  new double[] { 1.140516, -32.901795, 0.275811, 0.003415 });

            SanJuan.GroundIndexes.Add(new SpeciesGroundIndex(giUnico, 13.8));

            context.Species.Add(SanJuan);
        }
    }
}
