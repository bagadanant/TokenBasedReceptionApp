using TokenBasedReception.Core;
using System.Data.Entity;
using TokenBasedReception.Core.Entity;

namespace TokenBasedReception.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        Database Database { get; }
        int SaveChanges();
    }
}
