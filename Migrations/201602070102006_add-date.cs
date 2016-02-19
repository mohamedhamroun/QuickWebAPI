namespace AssWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Intervention", "date", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Intervention", "date");
        }
    }
}
