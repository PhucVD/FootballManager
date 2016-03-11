using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;

namespace FootballManager.Service
{
    public class NationService: BaseService<Nation>
    {
        public NationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
