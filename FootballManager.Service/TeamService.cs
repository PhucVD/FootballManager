using System.Collections.Generic;
using System.Linq;
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
        
    }

    public interface ITournamentService : IBaseService<Tournament>
    {

    }
}
