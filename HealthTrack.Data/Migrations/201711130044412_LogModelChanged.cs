namespace HealthTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogModelChanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LogModels", newName: "Logs");
            DropPrimaryKey("dbo.Logs");
            AlterColumn("dbo.Logs", "LOG_ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Logs", "LOG_ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Logs");
            AlterColumn("dbo.Logs", "LOG_ID", c => c.String(nullable: false, maxLength: 126, unicode: false));
            AddPrimaryKey("dbo.Logs", "LOG_ID");
            RenameTable(name: "dbo.Logs", newName: "LogModels");
        }
    }
}
