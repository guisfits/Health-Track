namespace HealthTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_HT_ALIMENTO", "DESCRICAO", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.TB_HT_USUARIO", "SOBRENOME", c => c.String(nullable: false, maxLength: 120, unicode: false));
            AlterColumn("dbo.TB_HT_EXERCICIOFISICO", "DESCRICAO", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_HT_EXERCICIOFISICO", "DESCRICAO", c => c.String(maxLength: 126, unicode: false));
            AlterColumn("dbo.TB_HT_USUARIO", "SOBRENOME", c => c.String(nullable: false, maxLength: 126, unicode: false));
            AlterColumn("dbo.TB_HT_ALIMENTO", "DESCRICAO", c => c.String(maxLength: 126, unicode: false));
        }
    }
}
