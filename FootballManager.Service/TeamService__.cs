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
    public class TeamService__: ITeamService
    {
        protected IRepository<Team> repository;
        protected IUnitOfWork unitOfWork;

        public TeamService__()
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
            repository.Insert(model);
            unitOfWork.Commit();
        }

        public void Update(Team model)
        {
            repository.Update(model);
            unitOfWork.Commit();
        }

        public void Delete(Team model)
        {
            repository.Delete(model);
            unitOfWork.Commit();
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
            unitOfWork.Commit();
        }

        public IEnumerable<Team> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public IEnumerable<Team> GetMany(Expression<Func<Team, bool>> filter)
        {
            return repository.GetMany(filter).ToList();
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
