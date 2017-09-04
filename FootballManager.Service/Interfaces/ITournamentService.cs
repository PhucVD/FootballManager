using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FootballManager.Domain;

namespace FootballManager.Service.Interfaces
{
    public interface ITournamentService
    {
        Tournament GetById(int id);

        void Insert(Tournament model);

        void Update(Tournament model);

        int UpdateInfo(string pk, string name, string value);

        //void Delete(Tournament model);

        void DeleteById(int id);

        IEnumerable<Tournament> GetList(Expression<Func<Tournament, bool>> filter);

        int Save();
    }
}
