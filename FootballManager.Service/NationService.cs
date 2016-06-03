using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Service
{
    public class NationService: BaseService<Nation>
    {
        public NationService(IUnitOfWork unitOfWork, IRepository<Nation> repository) : base(unitOfWork, repository)
        {
            
        }
    }
}
