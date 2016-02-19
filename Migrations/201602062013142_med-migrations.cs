namespace AssWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medmigrations : DbMigration
    {
        public override void Up()
        {
            
          //  AddColumn("dbo.Alerte", "date", c => c.String(unicode: false));
            //AddColumn("dbo.Intervention", "data_debut", c => c.String(unicode: false));
            //AddColumn("dbo.Intervention", "date_fin", c => c.String(unicode: false));

            CreateTable(
                "dbo.Intervention",
                c => new
                {
                    idalerte = c.Int(nullable: false),
                    idremorq = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    etat = c.String(unicode: false),                 
                    data_debut = c.String(maxLength: 128, storeType: "nvarchar"),
                    date_fin = c.String(maxLength: 128, storeType: "nvarchar"),
                })
                .PrimaryKey(t => new { t.idalerte, t.idremorq })
                .ForeignKey("dbo.Alerte", t => t.idalerte)
                .ForeignKey("dbo.Remorqueur", t => t.idremorq)
                .Index(t => t.idalerte)
                .Index(t => t.idremorq);
        }
        
        public override void Down()
        {
            //DropPrimaryKey("dbo.Intervention");
            //AlterColumn("dbo.Intervention", "idclient", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            //DropColumn("dbo.Intervention", "date_fin");
            //DropColumn("dbo.Intervention", "data_debut");
            //DropColumn("dbo.Alerte", "date");
            //AddPrimaryKey("dbo.Intervention", new[] { "idclient", "idremorq" });
        }
    }
}
