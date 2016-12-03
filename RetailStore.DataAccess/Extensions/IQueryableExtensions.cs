using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RetailStore.DataAccess.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> IncludeMultiple<T,TProperty>(this IQueryable<T> query, params Expression<Func<T, TProperty>>[] includes)
    where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
