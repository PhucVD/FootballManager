using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FootballManager.Domain;


namespace FootballManager.Service.Interfaces
{
    public interface ITeamService
    {
        Team GetById(int id);

        void Insert(Team model);

        void Update(Team model);
    

        void DeleteById(int id);

        IEnumerable<Team> GetClubsOnly();

        IEnumerable<Team> GetList();

        IEnumerable<Team> GetList(Expression<Func<Team, bool>> filter);

    }

}
