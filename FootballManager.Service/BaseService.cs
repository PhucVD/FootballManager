using System;
using FootballManager.Common;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Service
{
    public abstract class BaseService
    {
        protected IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
