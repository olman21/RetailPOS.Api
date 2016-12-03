using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get<Tkey>(Tkey id);
        TEntity Get<Tkey,TProperty>(Tkey id, params Expression<Func<TEntity, TProperty>>[] Includes) where TProperty : class;
        
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] Includes);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Update(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
