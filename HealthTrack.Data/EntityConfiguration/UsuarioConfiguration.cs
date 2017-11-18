using System.Data.Entity.ModelConfiguration;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.EntityConfiguration
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("TB_HT_USUARIO");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("USUARIO_ID");

            Property(x => x.Altura)
                .HasColumnName("ALTURA")
                .IsRequired();

            Property(x => x.Nascimento)
                .HasColumnName("DT_NASCIMENTO")
                .HasColumnType("date")
                .IsRequired();

            Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(32)
                .IsRequired();

            Property(x => x.Sexo)
                .HasColumnName("SEXO")
                .IsRequired();

            Property(x => x.Sobrenome)
                .HasColumnName("SOBRENOME")
                .HasMaxLength(120)
                .IsRequired();

            Property(c => c.ImagemPath)
                .HasColumnName("IMAGEM");

            Ignore(c => c.Imc);
        }
    }
}
