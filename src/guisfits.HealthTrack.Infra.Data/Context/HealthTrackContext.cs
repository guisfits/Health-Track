using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace guisfits.HealthTrack.Infra.Data.Context
{
    public class HealthTrackContext : DbContext
    {
        public HealthTrackContext()
            :base("HealthTrackConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Peso> Pesos { get; set; }
        public DbSet<ExercicioFisico> ExerciciosFisicos { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<PressaoArterial> PressoesArteriais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new AlimentoConfig());
            modelBuilder.Configurations.Add(new ExercicioFisicoConfig());
            modelBuilder.Configurations.Add(new PressaoArterialConfig());
            modelBuilder.Configurations.Add(new PesoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
