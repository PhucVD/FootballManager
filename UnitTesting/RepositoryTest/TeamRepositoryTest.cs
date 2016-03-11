using System;
using FootballManager.Data.Repository;
using FootballManager.Domain;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.RepositoryTest
{
    [TestClass]
    public class TeamRepositoryTest : BaseTestClass
    {
        private IRepository<Team> _teamRepo;

        public TeamRepositoryTest()
        {
            _teamRepo = (GenericRepository<Team>)UnityContainer.Resolve(typeof(IRepository<Team>));
        }

        [TestMethod]
        public void FindEmployee()
        {
            var id = 1;
            var name = "Italy";

            var team = _teamRepo.GetById(id);

            var test = _teamRepo.GetAll();

            Assert.AreEqual(name, team.TeamName);
        }
    }
}
