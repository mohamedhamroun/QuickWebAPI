namespace AssWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alerte",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cin = c.String(maxLength: 128, storeType: "nvarchar"),
                        matricule = c.String(maxLength: 128, storeType: "nvarchar"),
                        date = c.String(unicode: false),
                        etat = c.String(unicode: false),
                        message = c.String(unicode: false),
                        longitude = c.Double(nullable: false),
                        latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.cin)
                .ForeignKey("dbo.Remorqueur", t => t.matricule)
                .Index(t => t.cin)
                .Index(t => t.matricule);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        cin = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        nom = c.String(unicode: false),
                        prenom = c.String(unicode: false),
                        email = c.String(unicode: false),
                        tel = c.String(unicode: false),
                        password = c.String(unicode: false),
                        nature_veh = c.String(unicode: false),
                        modele_veh = c.String(unicode: false),
                        marque_veh = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.cin);
            
            CreateTable(
                "dbo.Remorqueur",
                c => new
                    {
                        matricule = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        nom = c.String(unicode: false),
                        prenom = c.String(unicode: false),
                        email = c.String(unicode: false),
                        tel = c.String(unicode: false),
                        password = c.String(unicode: false),
                        longitude = c.Double(nullable: false),
                        latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.matricule);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alerte", "matricule", "dbo.Remorqueur");
            DropForeignKey("dbo.Alerte", "cin", "dbo.Client");
            DropIndex("dbo.Alerte", new[] { "matricule" });
            DropIndex("dbo.Alerte", new[] { "cin" });
            DropTable("dbo.Remorqueur");
            DropTable("dbo.Client");
            DropTable("dbo.Alerte");
        }
    }
}
