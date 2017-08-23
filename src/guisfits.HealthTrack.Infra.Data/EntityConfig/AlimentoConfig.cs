using guisfits.HealthTrack.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace guisfits.HealthTrack.Infra.Data.EntityConfig
{
    public class AlimentoConfig : EntityTypeConfiguration<Alimento>
    {
        public AlimentoConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Tipo)
                .IsRequired();

            Property(p => p.Descricao)
                .IsOptional()
                .HasMaxLength(300);

            Property(p => p.Calorias)
                .IsRequired();

            Property(p => p.DataHora)
                .IsRequired();

            //Cria o relacionamento com Usuario
            HasRequired(p => p.Usuario)
                .WithMany(p => p.Alimentos)
                .HasForeignKey(p => p.UsuarioId);

            Ignore(p => p.ValidationResult);

            ToTable("Alimentos");
        }
    }
}
