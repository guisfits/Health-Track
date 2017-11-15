using System.Data.Entity.ModelConfiguration;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.EntityConfiguration
{
    public class PressaoArterialConfiguration : EntityTypeConfiguration<PressaoArterial>
    {
        public PressaoArterialConfiguration()
        {
            ToTable("TB_HT_PRESSAOARTERIAL");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("PRESSAOARTERIAL_ID");

            Property(x => x.DataHora)
                .HasColumnName("DT_HORA")
                .IsRequired();

            Property(x => x.Diastolica)
                .HasColumnName("DIASTOLICA")
                .IsRequired();

            Property(x => x.Sistolica)
                .HasColumnName("SISTOLICA")
                .IsRequired();

            Property(x => x.Status)
                .HasColumnName("STATUS")
                .HasMaxLength(32)
                .IsRequired();

            HasRequired(x => x.Usuario)
                .WithMany(x => x.PressoesArteriais)
                .HasForeignKey(x => x.UsuarioId);

            Ignore(c => c.Validation);
        }
    }
}
