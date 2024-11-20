namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migfaaaaaaaaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "status", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterStatus");
        }
    }
}
