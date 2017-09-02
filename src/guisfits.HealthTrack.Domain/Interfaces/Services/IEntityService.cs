using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Interfaces.Services
{
    interface IEntityService<TEntity> where TEntity : Entity
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterPaginado(int s, int t);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
    }
}
