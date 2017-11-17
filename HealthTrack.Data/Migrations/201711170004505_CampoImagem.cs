namespace HealthTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoImagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_HT_USUARIO", "IMAGEM", c => c.String(maxLength: 126, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_HT_USUARIO", "IMAGEM");
        }
    }
}
