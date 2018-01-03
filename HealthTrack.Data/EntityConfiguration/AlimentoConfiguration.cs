using System.Data.Entity.ModelConfiguration;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.EntityConfiguration
{
    public class AlimentoConfiguration : EntityTypeConfiguration<Alimento>
    {
        public AlimentoConfiguration()
        {
            ToTable("TB_HT_ALIMENTO");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("ALIMENTO_ID");

            Property(x => x.Calorias)
                .HasColumnName("CALORIAS")
                .IsRequired();

            Property(x => x.DataHora)
                .HasColumnName("DT_HORA")
                .IsRequired();

            Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(200)
                .IsOptional();

            Property(x => x.Tipo)
                .HasColumnName("TIPO_ALIMENTO")
                .IsRequired();

            HasRequired(x => x.Usuario)
                .WithMany(x => x.Alimentos)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
