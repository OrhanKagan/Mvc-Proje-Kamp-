namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migfggdvdfdfddddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "status", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterStatus", c => c.String());
        }
    }
}
