using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected HealthTrackContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(HealthTrackContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objAdded = DbSet.Add(obj);
            return objAdded;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            DbSet.Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;

            return obj;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterPaginado(int s, int t)
        {
            return DbSet.Skip(s).Take(t).ToList();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Remover(Guid id)
        {
            var obj = new TEntity() { Id = id };
            DbSet.Remove(obj);
        }
        
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
