using System;
using FootballManager.Common;
using FootballManager.Repository.UnitOfWorks;
using FootballManager.Repository.Repositories;

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

        //public void UpdateInfo(string pk, string name, string value)
        //{
        //    var tournament = _tournamentRepository.GetById(int.Parse(pk));
        //    foreach (PropertyInfo property in tournament.GetType().GetProperties())
        //    {
        //        // Find column which should be updated
        //        if (property.Name.Equals(name))
        //        {
        //            // Change the type of the value to the type of the property
        //            object converted = Convert.ChangeType(value, property.PropertyType);
        //            // Set the property value
        //            property.SetValue(tournament, value);
        //        }
        //    }
        //}
    }
}
