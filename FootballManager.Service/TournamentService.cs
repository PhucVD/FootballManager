using System.Collections.Generic;
using System.Linq;
using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Service
{
    public class TeamService: BaseService<Team>, ITeamService
    {
        public TeamService(IUnitOfWork unitOfWork, ITeamRepository repository) : base(unitOfWork, repository)
        {

        }

        public IEnumerable<Team> GetClubsOnly()
        {
            return this.repository.GetMany(x => x.TeamType == TeamType.Club);
        } 
        
    }

    public interface ITeamService : IBaseService<Team>
    {
        IEnumerable<Team> GetClubsOnly();

    }
}
