﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;
using FootballManager.Service.Interfaces;
using System.Reflection;

namespace FootballManager.Service
{
    public class TournamentService : BaseService, ITournamentService
    {
        private readonly IRepository<Tournament> _tournamentRepository;

        public TournamentService(IUnitOfWork unitOfWork, IRepository<Tournament> repository) : base(unitOfWork)
        {
            _tournamentRepository = repository;
        }


        public Tournament GetById(int id)
        {
            return _tournamentRepository.GetById(id);
        }

        public IEnumerable<Tournament> GetList(Expression<Func<Tournament, bool>> filter)
        {
            return _tournamentRepository.GetList(new Expression<Func<Tournament, object>>[] { x => x.Host }, filter)
                .ToList();
        }

        public void Insert(Tournament model)
        {
            _tournamentRepository.Insert(model);
            this.Save();
        }

        public void Update(Tournament model)
        {
            throw new NotImplementedException();
        }

        public int UpdateInfo(string pk, string name, string value)
        {
            var tournament = _tournamentRepository.GetById(int.Parse(pk));

            // Find column which need to be updated
            var property = tournament.GetType().GetProperties().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (property != null)
            {
                // Convert type
                object converted = Convert.ChangeType(value, property.PropertyType);
                // Set value
                property.SetValue(tournament, value);

                return this.Save();
            }
            
            return 0;
        }

        public void DeleteById(int id)
        {
            _tournamentRepository.DeleteById(id);
            this.Save();
        }

    }
}
