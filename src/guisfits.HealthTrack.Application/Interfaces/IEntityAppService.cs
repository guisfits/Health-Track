using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Application.ViewModels;

namespace guisfits.HealthTrack.Application.Interfaces
{
    public interface IEntityAppService<TEntity> : IDisposable where TEntity : EntityViewModel
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterPaginado(int s, int t);
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
    }
}
