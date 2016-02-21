using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FootballManager.Data.Repository;
using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;

namespace FootballManager.Service
{
    public class TeamService: ITeamService
    {
        protected IRepository<Team> repository;
        protected IUnitOfWork unitOfWork;

        public TeamService()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = new GenericRepository<Team>(this.unitOfWork);
        }

        public Team GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Insert(Team model)
        {
            throw new NotImplementedException();
        }

        public void Update(Team model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Team model)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public IEnumerable<Team> GetMany(Expression<Func<Team, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITeamService
    {
        Team GetById(int id);

        void Insert(Team model);

        void Update(Team model);

        void Delete(Team model);

        void DeleteById(int id);

        IEnumerable<Team> GetAll();

        IEnumerable<Team> GetMany(Expression<Func<Team, bool>> filter);

    }
}
