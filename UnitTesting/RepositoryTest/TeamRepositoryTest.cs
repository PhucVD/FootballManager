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
        private TeamRepository _teamRepo;

        public TeamRepositoryTest()
        {
            _teamRepo = (TeamRepository)UnityContainer.Resolve(typeof(ITeamRepository));
        }

        [TestMethod]
        public void FindEmployee()
        {
            var id = 1;
            var name = "Italy";

            var team = _teamRepo.GetById(id);

            Assert.AreEqual(name, team.TeamName);
        }
    }
}
