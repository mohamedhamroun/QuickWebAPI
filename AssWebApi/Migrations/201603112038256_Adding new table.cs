namespace AssWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingnewtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlerteRemorqueur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        idalerte = c.Int(nullable: false),
                        idremorq = c.String(maxLength: 128, storeType: "nvarchar"),
                      
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alerte", t => t.idalerte)
                .ForeignKey("dbo.Remorqueur", t => t.idremorq)
                .Index(t => t.idalerte)
                .Index(t => t.idremorq);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlerteRemorqueur", "Remorqueur_matricule", "dbo.Remorqueur");
            DropForeignKey("dbo.AlerteRemorqueur", "Alerte_Id", "dbo.Alerte");
            DropIndex("dbo.AlerteRemorqueur", new[] { "Remorqueur_matricule" });
            DropIndex("dbo.AlerteRemorqueur", new[] { "Alerte_Id" });
            DropTable("dbo.AlerteRemorqueur");
        }
    }
}
