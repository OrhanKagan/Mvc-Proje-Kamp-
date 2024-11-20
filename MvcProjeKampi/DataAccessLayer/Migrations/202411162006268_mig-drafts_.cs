namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migdrafts_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DarftsStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DarftsStatus");
        }
    }
}
