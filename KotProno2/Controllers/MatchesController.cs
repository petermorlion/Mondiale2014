using Breeze.ContextProvider;
using Breeze.WebApi2;
using KotProno2.EntityFramework;
using KotProno2.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KotProno2.Controllers
{
    [BreezeController]
    public class MatchesController : ApiController
    {
        // TODO: Use repo and DI?
        private readonly MatchesContext _contextProvider = new MatchesContext();

        [HttpGet]
        public string Metadata()
        {
            try
            {
                return _contextProvider.Metadata();
            }
            catch (Exception e)
            {
                return e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;
            }
        }

        // ~/breeze/matches/SaveChanges
        [HttpGet]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}