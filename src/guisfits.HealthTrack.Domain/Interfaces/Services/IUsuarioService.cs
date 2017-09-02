using System;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Interfaces.Services
{
    public interface IUsuarioService : IEntityService<Usuario>
    {
        Guid ObterIdPeloIdentity(string idIdentity);
    }
}
