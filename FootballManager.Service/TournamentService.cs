using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Service
{
    public class TournamentService : BaseService<Tournament>, ITournamentService
    {
        public TournamentService(IUnitOfWork unitOfWork, IRepository<Tournament> repository) : base(unitOfWork, repository)
        {

        }

        public override IEnumerable<Tournament> GetMany(Expression<Func<Tournament, bool>> filter)
        {
            return repository.GetMany(new Expression<Func<Tournament, object>>[] { x => x.Host }, filter)
                .AsEnumerable();
        }
    }

    public interface ITournamentService : IBaseService<Tournament>
    {

    }
}
