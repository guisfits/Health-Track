using guisfits.HealthTrack.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace guisfits.HealthTrack.Infra.Data.EntityConfig
{
    public class PesoConfig : EntityTypeConfiguration<Peso>
    {
        public PesoConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.DataHora)
                .IsRequired();

            Property(p => p.ValorKg)
                .IsRequired();

            HasRequired(p => p.Usuario)
                .WithMany(p => p.PesosKg)
                .HasForeignKey(p => p.UsuarioId);

            Ignore(p => p.ValidationResult);

            ToTable("Pesos");
        }
    }
}
