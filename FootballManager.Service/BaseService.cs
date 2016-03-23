using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Common;
using FootballManager.Data.Repository;
using FootballManager.Data.UnitOfWorks;

namespace FootballManager.Service
{
    public abstract class BaseService<T>: IBaseService<T> 
        where T: class
    {
        protected IRepository<T> repository;
        protected IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository; 
        }

        public virtual T GetById(int id)
        {
            return repository.GetById(id);
        }

        public virtual void Insert(T model)
        {
            repository.Insert(model);
            this.Save();
        }

        public virtual void Update(T model)
        {
            repository.Update(model);
            this.Save();
        }

        public virtual void Delete(T model)
        {
            repository.Delete(model);
            this.Save();
        }

        public virtual void DeleteById(int id)
        {
            repository.DeleteById(id);
            this.Save();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return repository.GetAll().ToList();
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
