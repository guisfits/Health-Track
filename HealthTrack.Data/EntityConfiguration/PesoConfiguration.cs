using System.Data.Entity.ModelConfiguration;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.EntityConfiguration
{
    public class PesoConfiguration : EntityTypeConfiguration<Peso>
    {
        public PesoConfiguration()
        {
            ToTable("TB_HT_PESO");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("PESO_ID");

            Property(x => x.DataHora)
                .HasColumnName("DT_HORA")
                .IsRequired();

            Property(x => x.ValorPeso)
                .HasColumnName("VALOR_PESO")
                .IsRequired();

            HasRequired(x => x.Usuario)
                .WithMany(x => x.Pesos)
                .HasForeignKey(x => x.UsuarioId);

            Ignore(c => c.Validation);
        }
    }
}
