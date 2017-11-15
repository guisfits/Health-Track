using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HealthTrack.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get(string Id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity obj);
        void AddRange(IEnumerable<TEntity> obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void RemoveRange(IEnumerable<TEntity> obj);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicace);
        IEnumerable<TEntity> Pagination(int page, int pagesize);
    }
}
