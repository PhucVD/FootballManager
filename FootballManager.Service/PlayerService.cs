using System;
using System.Collections.Generic;
using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;
using FootballManager.Service.Interfaces;
using System.Linq;

namespace FootballManager.Service
{
    public class PlayerService: BaseService, IPlayerService
    {
        private readonly IRepository<Player> _playerRepository;

        public PlayerService(IUnitOfWork unitOfWork, IRepository<Player> repository) : base(unitOfWork)
        {
            _playerRepository = repository;
        }

        public IEnumerable<Player> GetList()
        {
            return _playerRepository.GetList().ToList();
        }

        public Player GetById(int id)
        {
            return _playerRepository.GetById(id);
        }

        public void Insert(Player model)
        {
            _playerRepository.Insert(model);
            this.Save();
        }

        public void Update(Player model)
        {
            _playerRepository.Update(model);
            this.Save();
        }

        public void DeleteById(int id)
        {
            _playerRepository.DeleteById(id);
            this.Save();
        }
    }
}
