using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;
using FootballManager.Service.Interfaces;

namespace FootballManager.Service
{
    public class TeamService : BaseService, ITeamService
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamService(IUnitOfWork unitOfWork, ITeamRepository repository) : base(unitOfWork)
        {
            _teamRepository = repository;
        }
        public IEnumerable<Team> GetList()
        {
            return _teamRepository.GetList(new Expression<Func<Team, object>>[] { x => x.Country }, x => true)
                .ToList();
        }

        public IEnumerable<Team> GetList(Expression<Func<Team, bool>> filter)
        {
            return _teamRepository.GetList(new Expression<Func<Team, object>>[] { x => x.Country }, filter)
                .ToList();
        }

        public IEnumerable<Team> GetClubsOnly()
        {
            return _teamRepository.GetList(x => x.TeamType == TeamType.Club).ToList();
        }

        public Team GetById(int id)
        {
            return _teamRepository.GetById(id);
        }

        public void Insert(Team model)
        {
            _teamRepository.Insert(model);
        }

        public void Update(Team model)
        {
            _teamRepository.Update(model);
        }

        public void DeleteById(int id)
        {
            _teamRepository.DeleteById(id);
        }

    }

}
