using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Common;
using FootballManager.Data.Repository;
using FootballManager.Data.UnitOfWorks;

namespace FootballManager.Service
{
    public class BaseService<T>: IBaseService<T> 
        where T: class
    {
        protected IRepository<T> _repository;
        protected IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = new GenericRepository<T>(this._unitOfWork); 
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Insert(T model)
        {
            _repository.Insert(model);
            this.Save();
        }

        public virtual void Update(T model)
        {
            _repository.Update(model);
            this.Save();
        }

        public virtual void Delete(T model)
        {
            _repository.Delete(model);
            this.Save();
        }

        public virtual void DeleteById(int id)
        {
            _repository.DeleteById(id);
            this.Save();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> filter)
        {
            return _repository.GetMany(filter).AsEnumerable();
        }

        public int Save()
        {
            try
            {
                return _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                LogHelper.Error("Update database failed!", ex);
                throw;
            }
        }
    }
}
