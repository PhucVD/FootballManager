using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;
using FootballManager.Domain;

namespace FootballManager.Data
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Database Database { get; }
        DbSet Set(Type entityType);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }

    public interface IFootballContext : IDbContext
    {
        DbSet<Team> Teams { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Nation> Nations { get; set; }
    }
}
