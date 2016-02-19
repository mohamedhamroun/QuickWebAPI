namespace AssWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingvehiculesparametres : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "nature_veh", c => c.String(unicode: false));
            AddColumn("dbo.Client", "modele_veh", c => c.String(unicode: false));
            AddColumn("dbo.Client", "marque_veh", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "marque_veh");
            DropColumn("dbo.Client", "modele_veh");
            DropColumn("dbo.Client", "nature_veh");
        }
    }
}
