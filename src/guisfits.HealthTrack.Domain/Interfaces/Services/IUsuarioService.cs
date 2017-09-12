using guisfits.HealthTrack.Domain.Models;
using System;

namespace guisfits.HealthTrack.Domain.Interfaces.Services
{
    public interface IUsuarioService : IEntityService<Usuario>
    {
        Guid ObterIdPeloIdentity(string idIdentity);
        Usuario ObterTudoDoUsuario(Guid id);
    }
}
