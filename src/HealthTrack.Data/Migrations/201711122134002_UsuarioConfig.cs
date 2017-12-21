namespace HealthTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioConfig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TB_HT_USUARIO", "Imc_Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_HT_USUARIO", "Imc_Valor", c => c.Single(nullable: false));
        }
    }
}
