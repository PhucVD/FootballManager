using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FootballManager.Domain;
using FootballManager.Repository.UnitOfWorks;

namespace FootballManager.Repository.Repositories
{
    public class TeamRepository: GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public override IQueryable<Team> GetAll()
        {
            return dbSet.Include(p => p.Country);
        }
    }

    public interface ITeamRepository : IRepository<Team>
    {
        
    }
}
