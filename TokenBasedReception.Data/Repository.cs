using TokenBasedReception.Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public Repository(IDbContext context)
        {
            this._context = context;
        }

        public Object ExecuteQuery(string sql, params object[] parameters)
        {          
            return _context.Database.SqlQuery<T>(sql, parameters);
            //string command = sql;
            //return _context.ExecuteStoreCommand(command, parameters);
        }

        public Object ExecuteNonStructuredQuery(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public T Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                T savedEntity = this.Entities.Add(entity);
                return this._context.SaveChanges() > 0 ? savedEntity : null;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entity.Deleted = true;
                entity.DeletedOn = DateTime.UtcNow;
                //this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public int TotalCount(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> searchPredicate = null)
        {
            if (searchPredicate == null)
                return this.Entities.Where(predicate).Count();
            else
                return this.Entities.Where(predicate).Where(searchPredicate).Count();
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
    }

    /// <summary>
    /// Class for keeping order by column name and its order direction
    /// </summary>
    public class OrderByColumn
    {
        public string Column { get; set; }
        public OrderDirection Direction { get; set; }
    }

    /// <summary>
    /// Order direction
    /// </summary>
    public enum OrderDirection
    {
        [Description("DESC")]
        DESC = 0,
        [Description("ASC")]
        ASC = 1
    }

    /// <summary>
    /// Custom Extension to handle string value to enum
    /// </summary>
    public static class OrderDirectionExtensions
    {
        public static string ToDescriptionString(this OrderDirection val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                                                    .GetType()
                                                    .GetField(val.ToString())
                                                    .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
