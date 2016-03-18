using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FootballManager.Common.Classes;
using FootballManager.Common.Enums;

namespace FootballManager.Controllers.Api
{
    public class TeamTypeController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<SelectItem> Get()
        {
            return Enum.GetValues(typeof(TeamType))
                    .Cast<TeamType>()
                    .Select(v => new SelectItem
                    {
                        Id = v.ToString(),
                        Label = v.ToString(),
                    })
                    .ToList();
        }

    }
}