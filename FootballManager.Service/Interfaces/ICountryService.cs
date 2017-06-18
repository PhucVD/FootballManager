using System.Collections.Generic;
using FootballManager.Domain;

namespace FootballManager.Service.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<Country> GetList();
    }

}
