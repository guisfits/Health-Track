namespace HealthTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogIdChanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Logs", newName: "TB_HT_LOG");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TB_HT_LOG", newName: "Logs");
        }
    }
}
