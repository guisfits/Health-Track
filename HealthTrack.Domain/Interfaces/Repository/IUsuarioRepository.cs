using System.Collections.Generic;
using HealthTrack.Domain.Interfaces.Repository;
using HealthTrack.Domain.Models;

namespace Core.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterDadosDashboard(string Id);
    }
}
