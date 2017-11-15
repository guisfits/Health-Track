namespace HealthTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogIdToString : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TB_HT_LOG");
            AlterColumn("dbo.TB_HT_LOG", "LOG_ID", c => c.String(nullable: false, maxLength: 126, unicode: false));
            AddPrimaryKey("dbo.TB_HT_LOG", "LOG_ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TB_HT_LOG");
            AlterColumn("dbo.TB_HT_LOG", "LOG_ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TB_HT_LOG", "LOG_ID");
        }
    }
}
