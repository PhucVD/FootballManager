using FootballManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Interfaces
{
    public interface IPlayerService
    {
        Player GetById(int id);

        void Insert(Player model);

        void Update(Player model);

        //void Delete(Player model);

        void DeleteById(int id);

        IEnumerable<Player> GetList();

        //IEnumerable<Player> GetMany(Expression<Func<Player, bool>> filter);

        int Save();

    }
}
