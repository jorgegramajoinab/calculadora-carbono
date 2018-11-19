namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                        Type = c.Byte(nullable: false),
                        Category = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroundIndexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        defaultValue = c.Double(nullable: false),
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
                .ForeignKey("dbo.Species", t => t.specieId, cascadeDelete: true)
                .ForeignKey("dbo.GroundIndexes", t => t.groundIndexId, cascadeDelete: true)
                .Index(t => t.specieId)
                .Index(t => t.groundIndexId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        simpleName = c.String(),
                        commonName = c.String(),
                        scientificName = c.String(),
                        shapeCoefficient = c.Double(nullable: false),
                        limitYear = c.Int(nullable: false),
                        dryMaterial = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MathEspressions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpeciesId = c.Int(nullable: false),
                        Key = c.String(),
                        Name = c.String(),
                        Expression = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .Index(t => t.SpeciesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpeciesGroundIndexes", "groundIndexId", "dbo.GroundIndexes");
            DropForeignKey("dbo.MathEspressions", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.SpeciesGroundIndexes", "specieId", "dbo.Species");
            DropIndex("dbo.MathEspressions", new[] { "SpeciesId" });
            DropIndex("dbo.SpeciesGroundIndexes", new[] { "groundIndexId" });
            DropIndex("dbo.SpeciesGroundIndexes", new[] { "specieId" });
            DropTable("dbo.MathEspressions");
            DropTable("dbo.Species");
            DropTable("dbo.SpeciesGroundIndexes");
            DropTable("dbo.GroundIndexes");
            DropTable("dbo.Configurations");
        }
    }
}
