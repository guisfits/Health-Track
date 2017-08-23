using guisfits.HealthTrack.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace guisfits.HealthTrack.Infra.Data.EntityConfig
{
    public class PressaoArterialConfig : EntityTypeConfiguration<PressaoArterial>
    {
        public PressaoArterialConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Sistolica)
                .IsRequired();

            Property(p => p.Diastolica)
                .IsRequired();

            Property(p => p.DataHora)
                .IsRequired();

            Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(20);

            HasRequired(p => p.Usuario)
                .WithMany(p => p.PressoesArteriais)
                .HasForeignKey(p => p.UsuarioId);

            Ignore(p => p.ValidationResult);

            ToTable("PressoesArteriais");
        }
    }
}
