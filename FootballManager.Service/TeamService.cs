using System.Collections.Generic;
using System.Linq;
using FootballManager.Common.Classes;
using FootballManager.Common.Enums;
using FootballManager.Common.Interfaces;
using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;

namespace FootballManager.Service
{
    public class TeamService: BaseService<Team>, ITeamService
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
            return this._repository.GetMany(x => x.TeamType == TeamType.Club);
        }

        public IEnumerable<TeamViewModel> GetAllTeamViewModel()
        {
            return this.GetAll().Select(AutoMapper.Mapper.Map<TeamViewModel>);
        }

        public TeamViewModel GetTeamViewModelById(int id)
        {
            return AutoMapper.Mapper.Map<TeamViewModel>(this.GetById(id));
        }

        public TeamService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

    public interface ITeamService : IBaseService<Team>
    {
        IEnumerable<Team> GetClubsOnly();
        IEnumerable<TeamViewModel> GetAllTeamViewModel();
        TeamViewModel GetTeamViewModelById(int id);
    }
}
