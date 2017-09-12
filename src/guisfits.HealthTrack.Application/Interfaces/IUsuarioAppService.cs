using System;
using guisfits.HealthTrack.Application.ViewModels;

namespace guisfits.HealthTrack.Application.Interfaces
{
    public interface IUsuarioAppService : IEntityAppService<UsuarioViewModel>
    {
        Guid ObterIdPeloIdentity(string idIdentity);
        UsuarioViewModel ObterTudoDoUsuario(Guid id);
    }
}
