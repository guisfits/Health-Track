using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HealthTrack.Data.Context;
using HealthTrack.Domain.Interfaces.Repository;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly HealthTrackContext context;
        protected readonly DbSet<TEntity> Db;

        protected Repository(HealthTrackContext context)
        {
            this.context = context;
            Db = context.Set<TEntity>();
        }

        public virtual TEntity Get(string Id)
        {
            return Db.Find(Id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicace)
        {
            return Db.Where(predicace).ToList();
        }

        public virtual IEnumerable<TEntity> Pagination(int page, int pagesize)
        {
            return Db.Skip(page * pagesize).Take(pagesize).ToList();
        }

        public virtual void Add(TEntity obj)
        {
            obj.Id = Guid.NewGuid().ToString();
            Db.Add(obj);
        }

        public virtual void AddRange(IEnumerable<TEntity> obj)
        {
            Db.AddRange(obj);
        }

        public virtual void Update(TEntity obj)
        {
            Db.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity obj)
        {
            Db.Remove(obj);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> obj)
        {
            Db.RemoveRange(obj);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
