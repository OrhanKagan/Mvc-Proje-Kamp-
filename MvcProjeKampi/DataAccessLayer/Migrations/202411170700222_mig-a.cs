﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miga : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReadStatus");
        }
    }
}
