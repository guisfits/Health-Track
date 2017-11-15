using System.Data.Entity.ModelConfiguration;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.EntityConfiguration
{
    public class ExercicioFisicoConfiguration : EntityTypeConfiguration<ExercicioFisico>
    {
        public ExercicioFisicoConfiguration()
        {
            ToTable("TB_HT_EXERCICIOFISICO");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("EXERCICIOFISICO_ID");

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
                .HasColumnName("TIPO_EXERCICIOFISICO")
                .IsRequired();

            HasRequired(x => x.Usuario)
                .WithMany(x => x.ExerciciosFisicos)
                .HasForeignKey(x => x.UsuarioId);

            Ignore(c => c.Validation);
        }
    }
}
