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

            Property(p => p.SexoString)
                .IsRequired()
                .HasMaxLength(9);

            Property(p => p.Altura)
                .IsRequired();

            Property(p => p.Nascimento)
                .IsRequired();

            Property(p => p.Excluido)
                .IsRequired();

            Property(p => p.IdentityId)
                .IsRequired();

            Ignore(p => p.Sexo);

            Ignore(p => p.Imc);

            Ignore(p => p.IdadeAtual);

            Ignore(p => p.PesoAtual);

            Ignore(p => p.ValidationResult);

            ToTable("Usuarios");
        }
    }
}
