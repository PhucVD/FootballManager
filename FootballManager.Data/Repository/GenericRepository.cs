using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Data.UnitOfWorks;

namespace FootballManager.Data.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        protected DbContext context;
        protected DbSet<TEntity> dbSet;

        #endregion

        #region Constructor

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            this.context = unitOfWork.GetDbContext();
            this.dbSet = context.Set<TEntity>();
        }

        #endregion

        #region Methods

        public virtual void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void DeleteById(int id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual TEntity GetById(int id)
        {
            TEntity entity = dbSet.Find(id);
            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Where(filter);
        }

        public virtual int ExecuteCommand(string sql)
        {
            int numRowsAffected = context.Database.ExecuteSqlCommand(sql);
            return numRowsAffected;
        }

        #endregion

    }
}
