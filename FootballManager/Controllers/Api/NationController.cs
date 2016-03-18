
using System.Collections.Generic;
using System.Web.Http;
using FootballManager.Common.Classes;
using FootballManager.Service;

namespace FootballManager.Controllers.Api
{
    public class NationController : ApiController
    {
        private INationService _nationService;
        public NationController(INationService nationService)
        {
            _nationService = nationService;
        }
        public IEnumerable<NationViewModel> Get()
        {
            return _nationService.GetAllNationViewModel();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}