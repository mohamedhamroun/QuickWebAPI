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
                        message = c.String(unicode: false),
                        longitude = c.Double(nullable: false),
                        latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.cin)
                .Index(t => t.cin);
            
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
                    })
                .PrimaryKey(t => t.cin);
            
            CreateTable(
                "dbo.Intervention",
                c => new
                    {
                        idclient = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        idremorq = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        etat = c.String(unicode: false),
                        Alerte_Id = c.Int(),
                        Remorqueur_matricule = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.idclient, t.idremorq })
                .ForeignKey("dbo.Alerte", t => t.Alerte_Id)
                .ForeignKey("dbo.Remorqueur", t => t.Remorqueur_matricule)
                .Index(t => t.Alerte_Id)
                .Index(t => t.Remorqueur_matricule);
            
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
                    })
                .PrimaryKey(t => t.matricule);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Intervention", "Remorqueur_matricule", "dbo.Remorqueur");
            DropForeignKey("dbo.Intervention", "Alerte_Id", "dbo.Alerte");
            DropForeignKey("dbo.Alerte", "cin", "dbo.Client");
            DropIndex("dbo.Intervention", new[] { "Remorqueur_matricule" });
            DropIndex("dbo.Intervention", new[] { "Alerte_Id" });
            DropIndex("dbo.Alerte", new[] { "cin" });
            DropTable("dbo.Remorqueur");
            DropTable("dbo.Intervention");
            DropTable("dbo.Client");
            DropTable("dbo.Alerte");
        }
    }
}
