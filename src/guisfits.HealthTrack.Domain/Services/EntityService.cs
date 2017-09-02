using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Domain.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : Entity, new()
    {
        private readonly IRepository<TEntity> _repository;

        public EntityService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Adicionar(TEntity obj)
        {
            return obj.EhValido() ? _repository.Adicionar(obj) : obj;
        }

        public TEntity ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public IEnumerable<TEntity> ObterPaginado(int s, int t)
        {
            return _repository.ObterPaginado(s, t);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Buscar(predicate);
        }

        public TEntity Atualizar(TEntity obj)
        {
            return obj.EhValido() ? _repository.Atualizar(obj) : obj;
        }

        public void Remover(Guid id)
        {
            _repository.Remover(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
