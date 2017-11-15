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
            var usuario = context.Usuarios
                .Where(x => x.Id == id)
                .Include(x => x.Alimentos)
                .Include(x => x.ExerciciosFisicos)
                .Include(x => x.Pesos)
                .Include(x => x.PressoesArteriais)
                .FirstOrDefault();

            usuario.Alimentos = usuario.Alimentos.OrderByDescending(c => c.DataHora).Take(5).ToList();
            usuario.ExerciciosFisicos = usuario.ExerciciosFisicos.OrderByDescending(c => c.DataHora).Take(5).ToList();
            usuario.Pesos = usuario.Pesos.OrderByDescending(c => c.DataHora).Take(5).ToList();
            usuario.PressoesArteriais = usuario.PressoesArteriais.OrderByDescending(c => c.DataHora).Take(5).ToList();

            return usuario;
        }
    }
}
