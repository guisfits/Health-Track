using guisfits.HealthTrack.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace guisfits.HealthTrack.Infra.Data.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.Sobrenome)
                .IsRequired()
                .HasMaxLength(300);

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(300);

            Property(p => p.Sexo)
                .IsRequired();

            Property(p => p.AlturaMetros)
                .IsRequired();

            Property(p => p.Nascimento)
                .IsRequired();

            ToTable("Usuarios");
        }
    }
}
