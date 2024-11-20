namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migdrafts_add_colums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftsID = c.Int(nullable: false, identity: true),
                        DraftsReceiverMail = c.String(maxLength: 50),
                        DraftsSubject = c.String(maxLength: 100),
                        DraftsMessageContent = c.String(),
                        DraftsStatus = c.Boolean(nullable: false),
                        DraftsDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DraftsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drafts");
        }
    }
}
