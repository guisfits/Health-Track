using guisfits.HealthTrack.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace guisfits.HealthTrack.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioViewModel Adicionar(UsuarioViewModel obj);
        UsuarioViewModel ObterPorId(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        IEnumerable<UsuarioViewModel> ObterPaginado(int s, int t);
        UsuarioViewModel Atualizar(UsuarioViewModel obj);
        void Remover(Guid id);
    }
}
