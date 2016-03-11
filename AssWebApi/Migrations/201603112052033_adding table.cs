namespace AssWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtable : DbMigration
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
        }
    }
}
