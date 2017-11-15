using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HealthTrack.Data.EntityConfiguration;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.Context
{
    public class HealthTrackContext : DbContext
    {
        public HealthTrackContext()
            :base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<ExercicioFisico> ExerciciosFisicos { get; set; }
        public DbSet<Peso> Pesos { get; set; }
        public DbSet<PressaoArterial> PressoesArteriais { get; set; }
        public DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(c => c.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(c => c.HasMaxLength(126));

            modelBuilder.Configurations.Add(new AlimentoConfiguration());
            modelBuilder.Configurations.Add(new ExercicioFisicoConfiguration());
            modelBuilder.Configurations.Add(new PesoConfiguration());
            modelBuilder.Configurations.Add(new PressaoArterialConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
