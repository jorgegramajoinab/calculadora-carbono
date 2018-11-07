namespace model
{
    using model.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarbonCalculatorModel : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'CarbonCalculatorModel' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'model.CarbonCalculatorModel' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'CarbonCalculatorModel'  en el archivo de configuración de la aplicación.
        public CarbonCalculatorModel()
            : base("name=CarbonCalculatorModel")
        {
            this.Configuration.EnsureTransactionsForFunctionsAndCommands = true;
            Database.SetInitializer<CarbonCalculatorModel>(new CreateDatabaseIfNotExists<CarbonCalculatorModel>());
        }

        public CarbonCalculatorModel(string connection)
            : base(connection)
        {
            this.Configuration.EnsureTransactionsForFunctionsAndCommands = true;
            Database.SetInitializer<CarbonCalculatorModel>(new CreateDatabaseIfNotExists<CarbonCalculatorModel>());
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<Coefficient> Coefficients { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<GroundIndex> GroundIndexes { get; set; }
        public virtual DbSet<SpeciesGroundIndex> SpeciesGroundIndexes { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}