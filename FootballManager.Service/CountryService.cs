using System;
using System.Collections.Generic;
using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;
using FootballManager.Service.Interfaces;
using System.Linq;

namespace FootballManager.Service
{
    public class CountryService : BaseService, ICountryService
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryService(IUnitOfWork unitOfWork, IRepository<Country> repository) : base(unitOfWork)
        {
            _countryRepository = repository;
        }

        public IEnumerable<Country> GetList()
        {
            return _countryRepository.GetList().ToList();
        }
    }
}
