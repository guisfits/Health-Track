namespace HealthTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_HT_ALIMENTO",
                c => new
                    {
                        ALIMENTO_ID = c.String(nullable: false, maxLength: 126, unicode: false),
                        DESCRICAO = c.String(maxLength: 126, unicode: false),
                        CALORIAS = c.Single(nullable: false),
                        DT_HORA = c.DateTime(nullable: false),
                        TIPO_ALIMENTO = c.Int(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 126, unicode: false),
                    })
                .PrimaryKey(t => t.ALIMENTO_ID)
                .ForeignKey("dbo.TB_HT_USUARIO", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.TB_HT_USUARIO",
                c => new
                    {
                        USUARIO_ID = c.String(nullable: false, maxLength: 126, unicode: false),
                        NOME = c.String(nullable: false, maxLength: 32, unicode: false),
                        SOBRENOME = c.String(nullable: false, maxLength: 126, unicode: false),
                        ALTURA = c.Single(nullable: false),
                        DT_NASCIMENTO = c.DateTime(nullable: false, storeType: "date"),
                        SEXO = c.Int(nullable: false),
                        Imc_Valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.USUARIO_ID);
            
            CreateTable(
                "dbo.TB_HT_EXERCICIOFISICO",
                c => new
                    {
                        EXERCICIOFISICO_ID = c.String(nullable: false, maxLength: 126, unicode: false),
                        DESCRICAO = c.String(maxLength: 126, unicode: false),
                        CALORIAS = c.Single(nullable: false),
                        DT_HORA = c.DateTime(nullable: false),
                        TIPO_EXERCICIOFISICO = c.Int(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 126, unicode: false),
                    })
                .PrimaryKey(t => t.EXERCICIOFISICO_ID)
                .ForeignKey("dbo.TB_HT_USUARIO", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.TB_HT_PESO",
                c => new
                    {
                        PESO_ID = c.String(nullable: false, maxLength: 126, unicode: false),
                        VALOR_PESO = c.Single(nullable: false),
                        DT_HORA = c.DateTime(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 126, unicode: false),
                    })
                .PrimaryKey(t => t.PESO_ID)
                .ForeignKey("dbo.TB_HT_USUARIO", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.TB_HT_PRESSAOARTERIAL",
                c => new
                    {
                        PRESSAOARTERIAL_ID = c.String(nullable: false, maxLength: 126, unicode: false),
                        DT_HORA = c.DateTime(nullable: false),
                        SISTOLICA = c.Single(nullable: false),
                        DIASTOLICA = c.Single(nullable: false),
                        STATUS = c.String(nullable: false, maxLength: 32, unicode: false),
                        UsuarioId = c.String(nullable: false, maxLength: 126, unicode: false),
                    })
                .PrimaryKey(t => t.PRESSAOARTERIAL_ID)
                .ForeignKey("dbo.TB_HT_USUARIO", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.LogModels",
                c => new
                    {
                        LOG_ID = c.String(nullable: false, maxLength: 126, unicode: false),
                        IDENTITY_ID = c.String(maxLength: 126, unicode: false),
                        DT_HORA = c.DateTime(nullable: false),
                        MENSAGEM = c.String(nullable: false, maxLength: 356, unicode: false),
                        IP = c.String(nullable: false, maxLength: 16, unicode: false),
                    })
                .PrimaryKey(t => t.LOG_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_HT_ALIMENTO", "UsuarioId", "dbo.TB_HT_USUARIO");
            DropForeignKey("dbo.TB_HT_PRESSAOARTERIAL", "UsuarioId", "dbo.TB_HT_USUARIO");
            DropForeignKey("dbo.TB_HT_PESO", "UsuarioId", "dbo.TB_HT_USUARIO");
            DropForeignKey("dbo.TB_HT_EXERCICIOFISICO", "UsuarioId", "dbo.TB_HT_USUARIO");
            DropIndex("dbo.TB_HT_PRESSAOARTERIAL", new[] { "UsuarioId" });
            DropIndex("dbo.TB_HT_PESO", new[] { "UsuarioId" });
            DropIndex("dbo.TB_HT_EXERCICIOFISICO", new[] { "UsuarioId" });
            DropIndex("dbo.TB_HT_ALIMENTO", new[] { "UsuarioId" });
            DropTable("dbo.LogModels");
            DropTable("dbo.TB_HT_PRESSAOARTERIAL");
            DropTable("dbo.TB_HT_PESO");
            DropTable("dbo.TB_HT_EXERCICIOFISICO");
            DropTable("dbo.TB_HT_USUARIO");
            DropTable("dbo.TB_HT_ALIMENTO");
        }
    }
}
