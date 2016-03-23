using FootballManager.Data.Repository;
using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;

namespace FootballManager.Service
{
    public class PlayerService: BaseService<Player>
    {
        public PlayerService(IUnitOfWork unitOfWork, IRepository<Player> repository) : base(unitOfWork, repository)
        {

        }
    }
}
