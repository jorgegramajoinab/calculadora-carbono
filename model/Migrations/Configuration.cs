namespace model.Migrations
{
    using model.Models;
    using model.Models.DataContracts;
    using System;
    using System.Collections.Generic;
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
                var species = addSpecies();
                context.Species.AddRange(species);
                context.SaveChanges();
            }
        }

        private List<Species> addSpecies()
        {
            var species = new List<Species>();

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

            #region Abies guatemalensis Rehder
            var Pinabete = new Species
            {
                simpleName = "Pinabete",
                commonName = "Pinabete (Pashaque, Abeto)",
                code = "ABIEGU",
                scientificName = "Abies guatemalensis Rehder",
                shapeCoefficient = 0.5,
                limitYear = 18,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 8.58)
                }
            };

            species.Add(Pinabete);
            #endregion
            #region Acrocarpus fraxinifolius Wight &Arn
            var CedroRosado = new Species
            {
                simpleName = "Cedro Rosado",
                commonName = "Cedro Rosado (Cedro roso, Mundani)",
                code = "ACROFR",
                scientificName = "Acrocarpus fraxinifolius Wight &Arn",
                shapeCoefficient = 0.5,
                limitYear = 18,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 16.7),
                    new SpeciesGroundIndex(giMedio, 21.9),
                    new SpeciesGroundIndex(giExcelente, 27.9),
                }
            };

            species.Add(CedroRosado);
            #endregion
            #region Alnus jorullensis Kunth
            var aliso = new Species
            {
                simpleName = "Aliso",
                commonName = "Aliso",
                code = "ALNUJO",
                scientificName = "Alnus jorullensis Kunth",
                shapeCoefficient = 0.5,
                limitYear = 20,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 13.91),
                }
            };

            species.Add(aliso);
            #endregion
            #region Azadirachta indica A. Juss
            var nim = new Species
            {
                simpleName = "Nim",
                commonName = "Nim (Neem)",
                code = "AZADIN",
                scientificName = "Azadirachta indica A. Juss",
                shapeCoefficient = 0.5,
                limitYear = 9,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giMalo, 6.51),
                    new SpeciesGroundIndex(giBueno, 10.09),
                }
            };

            species.Add(nim);
            #endregion
            #region Caesalpinia velutina
            var Aripin = new Species
            {
                simpleName = "Aripin",
                commonName = "Aripin",
                code = "CAESVE",
                scientificName = "Caesalpinia velutina",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 8.03),
                }
            };

            species.Add(Aripin);
            #endregion
            #region Calophyllum brasiliense Cambess
            var SantaMaria = new Species
            {
                simpleName = "Santa María",
                commonName = "Santa María (Marío, leche)",
                code = "CALOBR",
                scientificName = "Calophyllum brasiliense Cambess",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 11.72),
                }
            };

            species.Add(SantaMaria);
            #endregion
            #region Casuarina equisetifolia L.
            var Casuarina = new Species
            {
                simpleName = "Casuarina",
                commonName = "Casuarina",
                code = "CASUEQ",
                scientificName = "Casuarina equisetifolia L.",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 7.1),
                }
            };

            species.Add(Casuarina);
            #endregion
            #region Cedrela odorata L.
            var Cedro = new Species
            {
                simpleName = "Cedro",
                commonName = "Cedro (Cedro rojo)",
                code = "CEDROD",
                scientificName = "Cedrela odorata L.",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 7),
                }
            };

            species.Add(Cedro);
            #endregion
            #region Cupressus lusitanica Mill.
            var CipresComun = new Species
            {
                simpleName = "Cipres Común",
                commonName = "Cipres Común (Ciprés)",
                code = "CUPRLU",
                scientificName = "Cupressus lusitanica Mill.",
                shapeCoefficient = 0.5,
                limitYear = 19,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 6),
                    new SpeciesGroundIndex(giMalo, 9.25),
                    new SpeciesGroundIndex(giMedio, 12.50),
                    new SpeciesGroundIndex(giBueno, 14.75),
                    new SpeciesGroundIndex(giExcelente, 17),
                }
            };

            species.Add(CipresComun);
            #endregion
            #region Enterolobium cyclocarpum
            var Conacaste = new Species
            {
                simpleName = "Conacaste",
                commonName = "Conacaste",
                code = "ENTECY",
                scientificName = "Enterolobium cyclocarpum",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 9),
                }
            };

            species.Add(Conacaste);
            #endregion
            #region Gmelina arbórea Roxb. ex. Sm
            var Melina = new Species
            {
                simpleName = "Melina",
                commonName = "Melina",
                code = "GMELAR",
                scientificName = "Gmelina arbórea Roxb. ex. Sm",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 8.62),
                    new SpeciesGroundIndex(giMalo, 14.31),
                    new SpeciesGroundIndex(giMedio, 20.01),
                    new SpeciesGroundIndex(giBueno, 24.18),
                    new SpeciesGroundIndex(giExcelente, 28.35),
                }
            };

            species.Add(Melina);
            #endregion
            #region Guazuma ulmifolia Lam
            var Caulote = new Species
            {
                simpleName = "Caulote",
                commonName = "Caulote",
                code = "GUAZUL",
                scientificName = "Guazuma ulmifolia Lam",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 6.54),
                }
            };

            species.Add(Caulote);
            #endregion
            #region Guazuma ulmifolia Lam
            var Canoj = new Species
            {
                simpleName = "Canoj",
                commonName = "Canoj",
                code = "TECTGR",
                scientificName = "Guazuma ulmifolia Lam",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 13.33),
                }
            };

            species.Add(Canoj);
            #endregion
            #region Pinus Caribaea var. hondurensis (Sénécl.) W. H. Barret & Golfari
            var PinoCaribe = new Species
            {
                simpleName = "Pino Caribe",
                commonName = "Pino Caribe (Pino de Petén)",
                code = "PINUCH",
                scientificName = "Pinus Caribaea var. hondurensis (Sénécl.) W. H. Barret & Golfari",
                shapeCoefficient = 0.5,
                limitYear = 25,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 9.43),
                    new SpeciesGroundIndex(giMalo, 12.46),
                    new SpeciesGroundIndex(giMedio, 15.49),
                    new SpeciesGroundIndex(giBueno, 17.36),
                    new SpeciesGroundIndex(giExcelente, 19.23),
                }
            };

            species.Add(PinoCaribe);
            #endregion
            #region Pinus Maximinoi H. E. Moore
            var PinoCandelillo = new Species
            {
                simpleName = "Pino Candelillo",
                commonName = "Pino Candelillo",
                code = "PINUMI",
                scientificName = "Pinus Maximinoi H. E. Moore",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 8.18),
                    new SpeciesGroundIndex(giMalo, 11.65),
                    new SpeciesGroundIndex(giMedio, 15.12),
                    new SpeciesGroundIndex(giBueno, 18.26),
                    new SpeciesGroundIndex(giExcelente, 21.40),
                }
            };

            species.Add(PinoCandelillo);
            #endregion
            #region Pinus sp Schiede
            var PinoOcote = new Species
            {
                simpleName = "Pino Ocote",
                commonName = "Pino Ocote (Pino colorado)",
                code = "PINUOO",
                scientificName = "Pinus sp Schiede",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 5.92),
                    new SpeciesGroundIndex(giMalo, 9.67),
                    new SpeciesGroundIndex(giMedio, 13.42),
                    new SpeciesGroundIndex(giBueno, 15.64),
                    new SpeciesGroundIndex(giExcelente, 17.86),
                }
            };

            species.Add(PinoOcote);
            #endregion
            #region Pinus patula Schltdl. & Cham.
            var PinoPatula = new Species
            {
                simpleName = "Pino Pátula",
                commonName = "Pino Pátula",
                code = "PINUPA",
                scientificName = "Pinus patula Schltdl. & Cham.",
                shapeCoefficient = 0.5,
                limitYear = 10,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 8.53),
                }
            };


            species.Add(PinoPatula);
            #endregion
            #region Pinus pseudostrobus Lindl
            var PinoTriste = new Species
            {
                simpleName = "Pino Triste",
                commonName = "Pino Triste (Pino blanco)",
                code = "PINUSP",
                scientificName = "Pinus pseudostrobus Lindl",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 8.32),
                    new SpeciesGroundIndex(giMalo, 10.77),
                    new SpeciesGroundIndex(giMedio, 13.21),
                    new SpeciesGroundIndex(giBueno, 14.16),
                    new SpeciesGroundIndex(giExcelente, 16.01),
                }
            };

            species.Add(PinoTriste);
            #endregion
            #region Pinus pseudostrobus Lindl
            var PaloDeSangre = new Species
            {
                simpleName = "Pino de Sangre",
                commonName = "Palo de Sangre (Sangre y cahué)",
                code = "PTEROF",
                scientificName = "Pinus pseudostrobus Lindl",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 11.21),
                    new SpeciesGroundIndex(giMedio, 13.32),
                    new SpeciesGroundIndex(giExcelente, 16.05),
                }
            };

            species.Add(PaloDeSangre);
            #endregion
            #region Pinus pseudostrobus Lindl
            var Casia = new Species
            {
                simpleName = "Casia",
                commonName = "Casia",
                code = "SENNGU",
                scientificName = "Pinus pseudostrobus Lindl",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 10.17),
                }
            };

            species.Add(Casia);
            #endregion
            #region Simira salvadorensis
            var PaloVolador = new Species
            {
                simpleName = "Palo Volador",
                commonName = "Palo Volador",
                code = "SIMISA",
                scientificName = "Simira salvadorensis",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 14.47),
                }
            };

            species.Add(PaloVolador);
            #endregion
            #region Swietenia macrophylla
            var Caoba = new Species
            {
                simpleName = "Caoba",
                commonName = "Caoba (Caoba del norte)",
                code = "SWIEMA",
                scientificName = "Swietenia macrophylla",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 5.40),
                    new SpeciesGroundIndex(giMalo, 9.32),
                    new SpeciesGroundIndex(giMedio, 13.24),
                    new SpeciesGroundIndex(giBueno, 15.60),
                    new SpeciesGroundIndex(giExcelente, 17.96),
                }
            };

            species.Add(Caoba);
            #endregion
            #region Tabebuia donnel-smithii Rose
            var PaloBlanco = new Species
            {
                simpleName = "Palo Blanco",
                commonName = "Palo Blanco",
                code = "TABEDO",
                scientificName = "Tabebuia donnel-smithii Rose",
                shapeCoefficient = 0.5,
                limitYear = 15,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 6.15),
                    new SpeciesGroundIndex(giMalo, 9.55),
                    new SpeciesGroundIndex(giMedio, 12.95),
                    new SpeciesGroundIndex(giBueno, 15.74),
                    new SpeciesGroundIndex(giExcelente, 18.53),
                }
            };

            species.Add(PaloBlanco);
            #endregion
            #region Swietenia macrophylla
            var Matilisguate = new Species
            {
                simpleName = "Matilisguate",
                commonName = "Matilisguate",
                code = "SWIEMA",
                scientificName = "Swietenia macrophylla",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 3.83),
                    new SpeciesGroundIndex(giMalo, 5.90),
                    new SpeciesGroundIndex(giMedio, 7.97),
                    new SpeciesGroundIndex(giBueno, 10.85),
                    new SpeciesGroundIndex(giExcelente, 13.73),
                }
            };

            species.Add(Matilisguate);
            #endregion
            #region Tectona GrandisL. f.
            var Teca = new Species
            {
                simpleName = "Teca",
                commonName = "Teca",
                code = "TECTGR",
                scientificName = "Tectona GrandisL. f.",
                shapeCoefficient = 0.5,
                limitYear = 17,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giPesimo, 7.60),
                    new SpeciesGroundIndex(giMalo, 13.34),
                    new SpeciesGroundIndex(giMedio, 19.07),
                    new SpeciesGroundIndex(giBueno, 24.36),
                    new SpeciesGroundIndex(giExcelente, 29.65),
                }
            };

            species.Add(Teca);
            #endregion
            #region Terminalia buceras
            var Pukte = new Species
            {
                simpleName = "Pukté",
                commonName = "Pukté",
                code = "TERMBU",
                scientificName = "Terminalia buceras",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 9.92),
                }
            };

            species.Add(Pukte);
            #endregion
            #region Terminalia oblonga
            var Guayabon = new Species
            {
                simpleName = "Guayabon",
                commonName = "Guayabon",
                code = "TECTGR",
                scientificName = "Terminalia oblonga",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 14.47),
                }
            };

            species.Add(Guayabon);
            #endregion
            #region Vochysia guatemalensis Donn. Sm.
            var SanJuan = new Species
            {
                simpleName = "San Juan",
                commonName = "San Juan",
                code = "VOCHGU",
                scientificName = "Vochysia guatemalensis Donn. Sm.",
                shapeCoefficient = 0.5,
                limitYear = 16,
                dryMaterial = 0.5,
                GroundIndexes = new SpeciesGroundIndex[]
                {
                    new SpeciesGroundIndex(giUnico, 13.8),
                }
            };

            species.Add(SanJuan);
            #endregion


            var mathExpressions = this.MathExpressions;

            mathExpressions.ForEach(
                item =>
                {
                    var wantedSpecies = 
                        species
                            .FirstOrDefault(
                                specie => 
                                specie.simpleName
                                    .ToLower()
                                    .Trim()
                                    .Equals(item.Key.ToLower().Trim())
                            );

                    if(wantedSpecies != null)
                    {
                        wantedSpecies.MathExpressions.Add(item.Value);
                    }
                });

            return species;
        }

        private List<KeyValuePair<string, MathExpression>> MathExpressions
        {
            get => new List<KeyValuePair<string, MathExpression>>() {
                new KeyValuePair<string, MathExpression>("Pinabete", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -20.378291( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pinabete", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -20.378291( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pinabete", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 4.627246 - 11.360686/t - 0.006167s - 0.00133n )")),
                new KeyValuePair<string, MathExpression>("Pinabete", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 5.447094 - 21.576918/t - 0.015678s - 0.001387n )")),
                new KeyValuePair<string, MathExpression>("Pinabete", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 8.352033 - 41.928436/t + 0.014195s - 0.00184n )")),

                new KeyValuePair<string, MathExpression>("Cedro Rosado", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -3.638221( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Cedro Rosado", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -3.638221( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Cedro Rosado", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.805506 - 2.624873/t + 0.029507s - 0.000251n )")),
                new KeyValuePair<string, MathExpression>("Cedro Rosado", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.649195 - 5.046975/t + 0.054066s + 0.001012n )")),
                new KeyValuePair<string, MathExpression>("Cedro Rosado", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 3.117363 - 8.840466/t + 0.107077s + 0.000951n )")),

                new KeyValuePair<string, MathExpression>("Aliso", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -5.183772( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Aliso", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -5.183772( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Aliso", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 3.479904 - 5.100774/t + 0.005329s - 0.000192n )")),
                new KeyValuePair<string, MathExpression>("Aliso", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 2.046634 - 13.359966/t + 0.071346s + 0.001672n )")),
                new KeyValuePair<string, MathExpression>("Aliso", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 5.002828 - 19.579749/t + 0.028559s + 0.001735n )")),

                new KeyValuePair<string, MathExpression>("Nim", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -1.725435( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Nim", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -1.725435( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Nim", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 1.567832 - 2.675935/t + 0.100498s + 0.000284n )")),
                new KeyValuePair<string, MathExpression>("Nim", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( -0.421023 - 5.328057/t + 0.199157s + 0.001581n )")),
                new KeyValuePair<string, MathExpression>("Nim", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( -0.96776 - 7.358693/t + 0.307991s + 0.002469n )")),

                new KeyValuePair<string, MathExpression>("Aripin", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -1.872405( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Aripin", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -1.872405( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Aripin", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 1.983661 - 2.330208/t + 0.095564s - 0.000385n )")),
                new KeyValuePair<string, MathExpression>("Aripin", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 0.83226 - 4.71375/t + 0.189626s - 9.7E-05n )")),
                new KeyValuePair<string, MathExpression>("Aripin", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 1.278762 - 7.15454/t + 0.35243s - 0.000352n )")),

                new KeyValuePair<string, MathExpression>("Santa María", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -7.657288( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Santa María", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -7.657288( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Santa María", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 3.861522 - 7.008542/t + 0.027548s - 0.001144n )")),
                new KeyValuePair<string, MathExpression>("Santa María", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 4.181024 - 13.83883/t + 0.051651s - 0.001286n )")),
                new KeyValuePair<string, MathExpression>("Santa María", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 6.72825 - 21.067206/t + 0.087027s - 0.002144n )")),

                new KeyValuePair<string, MathExpression>("Casuarina", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -5.886381( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Casuarina", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -5.886381( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Casuarina", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 3.041145 - 8.076789/t - 0.014162s - 6.9E-05n )")),
                new KeyValuePair<string, MathExpression>("Casuarina", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 2.462079 - 17.066455/t - 0.019585s + 0.00093n )")),
                new KeyValuePair<string, MathExpression>("Casuarina", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 4.147779 - 16.451739/t - 0.039504s + 0.000229n )")),

                new KeyValuePair<string, MathExpression>("Cedro", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -4.034014( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Cedro", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -4.034014( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Cedro", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.334384 - 4.530798/t + 0.145447s - 0.001743n )")),
                new KeyValuePair<string, MathExpression>("Cedro", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( -0.173934 - 9.532625/t + 0.302835s - 1.3E-05n )")),
                new KeyValuePair<string, MathExpression>("Cedro", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 0.988436 - 11.063187/t + 0.417214s - 0.002467n )")),

                new KeyValuePair<string, MathExpression>("Cipres Común", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -6.731967( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Cipres Común", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -6.731967( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Cipres Común", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.707584 - 5.677218/t + 0.067381s - 0.000247n )")),
                new KeyValuePair<string, MathExpression>("Cipres Común", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 2.045355 - 10.794574/t + 0.118218s + 0.00037n )")),
                new KeyValuePair<string, MathExpression>("Cipres Común", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 3.118363 - 17.429548/t + 0.215077s + 0.000309n )")),

                new KeyValuePair<string, MathExpression>("Conacaste", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -4.624413( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Conacaste", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -4.624413( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Conacaste", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.274322 - 6.302477/t + 0.086746s + 0.000159n )")),
                new KeyValuePair<string, MathExpression>("Conacaste", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.102299 - 12.647657/t + 0.170789s + 0.001247n )")),
                new KeyValuePair<string, MathExpression>("Conacaste", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 2.049391 - 18.839421/t + 0.264324s + 0.001348n )")),

                new KeyValuePair<string, MathExpression>("Melina", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -4.589766( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Melina", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -4.589766( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Melina", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.476769 - 3.669808/t + 0.048356s - 0.000258n )")),
                new KeyValuePair<string, MathExpression>("Melina", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 0.780617 - 7.094758/t + 0.092946s + 0.001186n )")),
                new KeyValuePair<string, MathExpression>("Melina", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 1.918322 - 11.678936/t + 0.160806s + 0.001068n )")),

                new KeyValuePair<string, MathExpression>("Caulote", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -0.684405( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Caulote", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -0.684405( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Caulote", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.762289 - 2.32964/t + 0.014772s - 0.000567n )")),
                new KeyValuePair<string, MathExpression>("Caulote", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 2.143734 - 4.666703/t + 0.028075s - 0.000276n )")),
                new KeyValuePair<string, MathExpression>("Caulote", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 1.966696 - 6.206873/t + 0.119088s + 0.000292n )")),

                new KeyValuePair<string, MathExpression>("Canoj", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -8.798094( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Canoj", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -8.798094( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Canoj", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 3.112788 - 6.202454/t + 0.078664s - 0.001055n )")),
                new KeyValuePair<string, MathExpression>("Canoj", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 2.642654 - 12.355272/t + 0.1598s - 0.00112n )")),
                new KeyValuePair<string, MathExpression>("Canoj", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 4.313634 - 21.102053/t + 0.245205s - 0.001508n )")),

                new KeyValuePair<string, MathExpression>("Pino Caribe", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -7.458911( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Caribe", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -7.458911( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Caribe", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.673197 - 5.545766/t + 0.056028s - 0.000142n )")),
                new KeyValuePair<string, MathExpression>("Pino Caribe", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.325956 - 11.038033/t + 0.091341s + 0.001634n )")),
                new KeyValuePair<string, MathExpression>("Pino Caribe", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 2.671109 - 18.578108/t + 0.171615s + 0.001541n )")),

                new KeyValuePair<string, MathExpression>("Pino Candelillo", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -6.96328( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Candelillo", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -6.96328( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Candelillo", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.853221 - 5.94932/t + 0.055943s - 0.000218n )")),
                new KeyValuePair<string, MathExpression>("Pino Candelillo", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.91575 - 11.592777/t + 0.100823s + 0.000843n )")),
                new KeyValuePair<string, MathExpression>("Pino Candelillo", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 3.160695 - 18.203956/t + 0.182736s + 0.000775n )")),

                new KeyValuePair<string, MathExpression>("Pino Ocote", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -6.498108( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Ocote", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -6.498108( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Ocote", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.426552 - 6.706013/t + 0.075921s + 4E-05n )")),
                new KeyValuePair<string, MathExpression>("Pino Ocote", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.060976 - 13.35596/t + 0.15187s + 0.001278n )")),
                new KeyValuePair<string, MathExpression>("Pino Ocote", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 2.246512 - 20.855741/t + 0.242321s + 0.001267n )")),

                new KeyValuePair<string, MathExpression>("Pino Pátula", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -6.921948( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Pátula", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -6.921948( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Pátula", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 1.842624 - 7.912709/t + 0.204784s - 0.000193n )")),
                new KeyValuePair<string, MathExpression>("Pino Pátula", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 0.592964 - 16.050104/t + 0.399771s + 0.000318n )")),
                new KeyValuePair<string, MathExpression>("Pino Pátula", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 1.57958 - 21.303008/t + 0.507162s + 0.000117n )")),

                new KeyValuePair<string, MathExpression>("Pino Triste", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -11.729867( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Triste", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -11.729867( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino Triste", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 3.298035 - 10.936875/t + 0.065073s - 8.3E-05n )")),
                new KeyValuePair<string, MathExpression>("Pino Triste", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 2.367995 - 21.373573/t + 0.153433s + 0.001055n )")),
                new KeyValuePair<string, MathExpression>("Pino Triste", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 4.039077 - 32.749693/t + 0.242141s + 0.000967n )")),

                new KeyValuePair<string, MathExpression>("Pino de Sangre", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -8.864079( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino de Sangre", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -8.864079( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pino de Sangre", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.533776 - 6.885158/t + 0.065936s - 0.000115n )")),
                new KeyValuePair<string, MathExpression>("Pino de Sangre", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.129202 - 14.091632/t + 0.126178s + 0.001344n )")),
                new KeyValuePair<string, MathExpression>("Pino de Sangre", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 2.56331 - 23.018699/t + 0.214254s + 0.001243n )")),

                new KeyValuePair<string, MathExpression>("Casia", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -6.116833( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Casia", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -6.116833( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Casia", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 1.49521 - 1.851407/t + 0.116224s - 0.000438n )")),
                new KeyValuePair<string, MathExpression>("Casia", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( -0.306671 - 4.378177/t + 0.225725s - 3E-06n )")),
                new KeyValuePair<string, MathExpression>("Casia", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 0.584018 - 9.960148/t + 0.294692s + 0.000274n )")),

                new KeyValuePair<string, MathExpression>("Palo Volador", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -7.563575( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Palo Volador", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -7.563575( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Palo Volador", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.624014 - 10.108301/t + 0.030276s + 0.000414n )")),
                new KeyValuePair<string, MathExpression>("Palo Volador", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.609769 - 20.178575/t + 0.060325s + 0.001922n )")),
                new KeyValuePair<string, MathExpression>("Palo Volador", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 5.394304 - 23.23099/t + 0.128387s - 0.001331n )")),

                new KeyValuePair<string, MathExpression>("Caoba", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -10.900122( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Caoba", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -10.900122( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Caoba", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.630349 - 10.089983/t + 0.075246s + 7.5E-05n )")),
                new KeyValuePair<string, MathExpression>("Caoba", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 0.830452 - 20.722084/t + 0.164495s + 0.001994n )")),
                new KeyValuePair<string, MathExpression>("Caoba", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 2.239672 - 32.894188/t + 0.260104s + 0.002181n )")),

                new KeyValuePair<string, MathExpression>("Palo Blanco", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -3.617786( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Palo Blanco", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -3.617786( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Palo Blanco", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 1.663888 - 2.480653/t + 0.089199s - 0.000146n )")),
                new KeyValuePair<string, MathExpression>("Palo Blanco", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( -0.668643 - 4.714003/t + 0.181244s + 0.00101n )")),
                new KeyValuePair<string, MathExpression>("Palo Blanco", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 0.117821 - 8.184507/t + 0.271737s + 0.000896n )")),

                new KeyValuePair<string, MathExpression>("Matilisguate", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -3.662898( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Matilisguate", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -3.662898( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Matilisguate", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 1.320543 - 4.009256/t + 0.158326s - 0.000237n )")),
                new KeyValuePair<string, MathExpression>("Matilisguate", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( -1.422144 - 8.124784/t + 0.299527s + 0.001255n )")),
                new KeyValuePair<string, MathExpression>("Matilisguate", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( -1.137584 - 12.265933/t + 0.4431s + 0.001109n )")),

                new KeyValuePair<string, MathExpression>("Teca", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -3.891677( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Teca", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -3.891677( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Teca", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.293225 - 4.118555/t + 0.052407s - 0.000131n )")),
                new KeyValuePair<string, MathExpression>("Teca", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 0.613447 - 7.899548/t + 0.09739s + 0.001207n )")),
                new KeyValuePair<string, MathExpression>("Teca", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 1.605596 - 12.336335/t + 0.166684s + 0.001142n )")),

                new KeyValuePair<string, MathExpression>("Pukté", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -1.741207( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pukté", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -1.741207( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Pukté", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 3.257189 - 3.956527/t + 0.009321s - 0n )")),
                new KeyValuePair<string, MathExpression>("Pukté", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 3.695791 - 7.913055/t - 0.018641s - 0n )")),
                new KeyValuePair<string, MathExpression>("Pukté", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 4.588308 - 10.377622/t + 0.049617s - 0n )")),

                new KeyValuePair<string, MathExpression>("Guayabon", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -7.206822( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Guayabon", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -7.206822( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("Guayabon", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.537212 - 5.780087/t + 0.00923s + 0.00057n )")),
                new KeyValuePair<string, MathExpression>("Guayabon", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.203433 - 11.513972/t + 0.018414s + 0.00251n )")),
                new KeyValuePair<string, MathExpression>("Guayabon", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 3.066308 - 19.106921/t + 0.07381s + 0.002185n )")),

                new KeyValuePair<string, MathExpression>("San Juan", new MathExpression(MathExpressionsKeys.Height, MathExpressionsDefaultNames.Height,  "s exp( -8.904588( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("San Juan", new MathExpression(MathExpressionsKeys.Site, MathExpressionsDefaultNames.Site,  "h exp( -8.904588( 1/t - .1 ) )")),
                new KeyValuePair<string, MathExpression>("San Juan", new MathExpression(MathExpressionsKeys.DAP, MathExpressionsDefaultNames.DAP,  "exp( 2.769514 - 7.431654/t + 0.050203s - 4.3E-05n )")),
                new KeyValuePair<string, MathExpression>("San Juan", new MathExpression(MathExpressionsKeys.Area, MathExpressionsDefaultNames.Area,  "exp( 1.651327 - 15.314681/t + 0.099127s + 0.001388n )")),
                new KeyValuePair<string, MathExpression>("San Juan", new MathExpression(MathExpressionsKeys.Volume, MathExpressionsDefaultNames.Volume,  "exp( 1.140516 - 32.901795/t + 0.275811s + 0.003415n )")),
            };

        }

    }
}
