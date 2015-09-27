using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;

namespace FootballManager.Data.Repository
{
    public class TeamRepository: GenericRepository<Team>
    {
        public TeamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public override IQueryable<Team> GetAll()
        {
            return dbSet.Include(p => p.Nation);
        }
    }
}
