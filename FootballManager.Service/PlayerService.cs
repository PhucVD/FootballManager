using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;

namespace FootballManager.Service
{
    public class PlayerService: BaseService<Player>
    {
        public PlayerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
