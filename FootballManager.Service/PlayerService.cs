using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Service
{
    public class PlayerService: BaseService<Player>
    {
        public PlayerService(IUnitOfWork unitOfWork, IRepository<Player> repository) : base(unitOfWork, repository)
        {

        }
    }
}
