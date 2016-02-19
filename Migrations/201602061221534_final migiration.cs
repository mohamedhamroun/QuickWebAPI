namespace AssWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalmigiration : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Remorqueur", "longitude", c => c.Double(nullable: false));
            //AddColumn("dbo.Remorqueur", "latitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Remorqueur", "latitude");
            //DropColumn("dbo.Remorqueur", "longitude");
        }
    }
}
