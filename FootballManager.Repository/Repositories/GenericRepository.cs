using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Repository.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly DbContext _context;
        protected readonly DbSet<TEntity> dbSet;

        #endregion

        #region Constructor

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.GetDbContext();
            this.dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region Methods

        public virtual void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
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
            int numRowsAffected = _context.Database.ExecuteSqlCommand(sql);
            return numRowsAffected;
        }

        #endregion

    }
}
