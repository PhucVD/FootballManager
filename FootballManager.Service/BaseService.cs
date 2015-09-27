using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Common;
using FootballManager.Data.Repository;
using FootballManager.Data.UnitOfWorks;

namespace FootballManager.Service
{
    public abstract class BaseService<T>: IDataService<T> 
        where T: class
    {
        protected IRepository<T> repository;
        protected IUnitOfWork unitOfWork;

        public BaseService()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = new GenericRepository<T>(this.unitOfWork); 
        }

        public virtual T GetById(int id)
        {
            return repository.GetById(id);
        }

        public virtual void Insert(T model)
        {
            repository.Insert(model);
        }

        public virtual void Update(T model)
        {
            repository.Update(model);
        }

        public virtual void Delete(T model)
        {
            repository.Delete(model);
        }

        public virtual void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return repository.GetAll().AsEnumerable();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> filter)
        {
            return repository.GetMany(filter).AsEnumerable();
        }

        public int Save()
        {
            try
            {
                return unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Update database failed!", ex);
                throw;
            }
        }
    }
}
