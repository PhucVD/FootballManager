using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FootballManager.Common.Classes;
using FootballManager.Common.Enums;
using FootballManager.Service;

namespace FootballManager.Controllers.Api
{
    public class TeamController : ApiController
    {
        private ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        // GET api/<controller>
        public IEnumerable<TeamViewModel> Get()
        {
            return _teamService.GetAllTeamViewModel();
        }

        // GET api/<controller>/5
        public TeamViewModel Get(int id)
        {
            return _teamService.GetTeamViewModelById(id);
        }

        // POST api/<controller>
        public void Post([FromBody] TeamViewModel model)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]TeamViewModel model)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}