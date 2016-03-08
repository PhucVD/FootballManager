using System.Collections.Generic;
using System.Linq;
using FootballManager.Data.Repository;
using FootballManager.Domain;

namespace FootballManager.Service
{
    public class TeamService: BaseService<Team>
    {
        //public TeamService() : base()
        //{
        //    this.repository = new TeamRepository(this.unitOfWork);
        //}

        //public void Test()
        //{

        //}
        public IEnumerable<Team> GetClubsOnly()
        {
            return this.repository.GetMany(x => x.TeamType == TeamType.Club);
        } 
        
    }
}
