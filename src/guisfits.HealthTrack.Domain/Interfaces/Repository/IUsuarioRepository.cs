using guisfits.HealthTrack.Domain.Models;
using System;

namespace guisfits.HealthTrack.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Guid ObterIdPeloIdentity(string idIdentity);
        Usuario ObterTudoDoUsuario(Guid id);
    }
}
