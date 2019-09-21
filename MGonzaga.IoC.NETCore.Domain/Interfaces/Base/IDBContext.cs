using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MGonzaga.IoC.NETCore.Domain.Interfaces.Base
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        //Database Database { get; }
        //void BulkInsert<T>(IEnumerable<T> eEntitys);
    }
}
