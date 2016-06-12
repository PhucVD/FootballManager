using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Service
{
    public class TeamService : BaseService<Team>, ITeamService
    {
        public TeamService(IUnitOfWork unitOfWork, ITeamRepository repository) : base(unitOfWork, repository)
        {

        }

        public override IEnumerable<Team> GetMany(Expression<Func<Team, bool>> filter)
        {
            return repository.GetMany(new Expression<Func<Team, object>>[] { x => x.Country }, filter)
                .AsEnumerable();
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
