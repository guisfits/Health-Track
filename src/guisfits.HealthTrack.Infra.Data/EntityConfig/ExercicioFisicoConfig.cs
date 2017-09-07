using guisfits.HealthTrack.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace guisfits.HealthTrack.Infra.Data.EntityConfig
{
    public class ExercicioFisicoConfig : EntityTypeConfiguration<ExercicioFisico>
    {
        public ExercicioFisicoConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.TipoExercicioString)
                .IsRequired()
                .HasMaxLength(20);

            Property(p => p.Descricao)
                .IsOptional()
                .HasMaxLength(300);

            Property(p => p.Calorias)
                .IsRequired();

            Property(p => p.DataHora)
                .IsRequired();

            HasRequired(p => p.Usuario)
                .WithMany(p => p.ExerciciosFisicos)
                .HasForeignKey(p => p.UsuarioId);

            Ignore(p => p.Tipo);

            Ignore(p => p.ValidationResult);

            ToTable("ExerciciosFisicos");
        }
    }
}
