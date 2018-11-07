namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coefficients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        speciesId = c.Int(nullable: false),
                        type = c.String(),
                        value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Species", t => t.speciesId, cascadeDelete: true)
                .Index(t => t.speciesId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        commonName = c.String(),
                        scientificName = c.String(),
                        shapeCoefficient = c.Double(nullable: false),
                        limitYear = c.Int(nullable: false),
                        dryMaterial = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpeciesGroundIndexes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        specieId = c.Int(nullable: false),
                        groundIndexId = c.Int(nullable: false),
                        value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GroundIndexes", t => t.groundIndexId, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.specieId, cascadeDelete: true)
                .Index(t => t.specieId)
                .Index(t => t.groundIndexId);
            
            CreateTable(
                "dbo.GroundIndexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        defaultValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coefficients", "speciesId", "dbo.Species");
            DropForeignKey("dbo.SpeciesGroundIndexes", "specieId", "dbo.Species");
            DropForeignKey("dbo.SpeciesGroundIndexes", "groundIndexId", "dbo.GroundIndexes");
            DropIndex("dbo.SpeciesGroundIndexes", new[] { "groundIndexId" });
            DropIndex("dbo.SpeciesGroundIndexes", new[] { "specieId" });
            DropIndex("dbo.Coefficients", new[] { "speciesId" });
            DropTable("dbo.GroundIndexes");
            DropTable("dbo.SpeciesGroundIndexes");
            DropTable("dbo.Species");
            DropTable("dbo.Coefficients");
        }
    }
}
