using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Service
{
    public class CountryService : BaseService<Country>
    {
        public CountryService(IUnitOfWork unitOfWork, IRepository<Country> repository) : base(unitOfWork, repository)
        {
            
        }
    }
}
