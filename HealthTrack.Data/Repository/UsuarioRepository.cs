using System.Data.Entity;
using System.Linq;
using Core.Interfaces.Repository;
using HealthTrack.Data.Context;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(HealthTrackContext context) 
            : base(context)
        {
        }

        public Usuario ObterDadosDashboard(string id)
        {
            return context.Usuarios
                .Where(x => x.Id == id)
                .Include(x => x.Alimentos)
                .Include(x => x.ExerciciosFisicos)
                .Include(x => x.Pesos)
                .Include(x => x.PressoesArteriais)
                .FirstOrDefault();
        }
    }
}
