using System.Collections.Generic;
using System.Linq;
using FootballManager.Data.Repository;
using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;

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
