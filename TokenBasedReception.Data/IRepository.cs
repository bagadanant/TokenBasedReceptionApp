using TokenBasedReception.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        int TotalCount(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> searchPredicate = null);

        Object ExecuteQuery(string sql, params object[] parameters);
        Object ExecuteNonStructuredQuery(string sql, params object[] parameters);
    }
}
