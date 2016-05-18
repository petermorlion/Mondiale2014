using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class TournamentsController : ApiController
    {
        // ~/api/tournaments/id
        [HttpGet]
        public IList<Tournament> Get(int id)
        {
            return new List<Tournament>();
        }
    }
}
