using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.EntityConfiguration
{
    public class LogConfiguration : EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
        {
            ToTable("TB_HT_LOG");

            HasKey(c => c.Id);

            Property(x => x.Id)
                .HasColumnName("LOG_ID");

            Property(x => x.Data)
                .HasColumnName("DT_HORA")
                .IsRequired();

            Property(x => x.Ip)
                .HasColumnName("IP")
                .HasMaxLength(16)
                .IsRequired();

            Property(x => x.Mensagem)
                .HasColumnName("MENSAGEM")
                .HasMaxLength(356)
                .IsRequired();

            Property(x => x.IdentityId)
                .HasColumnName("IDENTITY_ID")
                .HasMaxLength(126)
                .IsOptional();
        }
    }
}
