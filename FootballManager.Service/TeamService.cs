using System.Collections.Generic;
using System.Linq;
using FootballManager.Data.Repository;
using FootballManager.Domain;

namespace FootballManager.Service
{
    public class TeamService: BaseService<Team>, ITeamService
    {
        //public TeamService() : base()
        //{
        //    this.repository = new TeamRepository(this.unitOfWork);
        //}
       
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
