using EntityFramework.Filters;
using Retail.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RetailStore.DataAccess.Extensions;

namespace Retail.DataAccess
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext Context;
        private DbSet<TEntity> _entities;

        private DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = Context.Set<TEntity>();
                }
                return _entities;
            }
        }

        public EFRepository(DbContext context)
        {
            Context = context;
            Context.EnableFilter("SoftDelete");
        }

        public TEntity Get<Tkey>(Tkey id)
        {
            return this.Entities.Find(id);
        }

        public TEntity Get<Tkey,TProperty>(Tkey id, params Expression<Func<TEntity, TProperty>>[] Includes) where TProperty : class
        {
            var entity = this.Entities.Find(id);
            if (Includes != null)
            {
                foreach (var include in Includes)
                {
                    this.Context.Entry<TEntity>(entity).Reference<TProperty>(include).Load();
                }
            }
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Entities.ToList();
        }

        public IEnumerable<TEntity> GetAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] Includes)
        {
            return this.Entities.IncludeMultiple(Includes).ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Entities.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            this.Entities.Add(entity);
        }
        public void Update(TEntity entity)
        {
            this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Entities.AddRange(entities);
        }
        public void Remove(TEntity entity)
        {
            this.Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Entities.RemoveRange(entities);
        }
    }
}
