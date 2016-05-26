using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class MatchController : ApiController
    {
        private readonly MatchesContext _matchesContext = new MatchesContext();

        [HttpGet]
        public IList<Match> Get(int id)
        {
            var matches = _matchesContext.Context.Matches.Where(x => x.TournamentId == id).ToList();

            var groupStageStart = GetStageStart(matches, Stage.GroupStage);
            var eighthFinalStart = GetStageStart(matches, Stage.EighthFinals);
            var quarterFinalsStart = GetStageStart(matches, Stage.QuarterFinals);
            var semiFinalsStart = GetStageStart(matches, Stage.SemiFinals);
            var finalsStart = GetStageStart(matches, Stage.Finals);

            foreach (var match in matches)
            {
                switch (match.Stage)
                {
                    case Stage.GroupStage:
                        match.IsReadOnly = DateTime.UtcNow >= groupStageStart;
                        break;
                    case Stage.EighthFinals:
                        match.IsReadOnly = DateTime.UtcNow >= eighthFinalStart;
                        break;
                    case Stage.QuarterFinals:
                        match.IsReadOnly = DateTime.UtcNow >= quarterFinalsStart;
                        break;
                    case Stage.SemiFinals:
                        match.IsReadOnly = DateTime.UtcNow >= semiFinalsStart;
                        break;
                    case Stage.Finals:
                        match.IsReadOnly = DateTime.UtcNow >= finalsStart;
                        break;
                    default:
                        match.IsReadOnly = true;
                        break;
                }
            }

            return matches;
        }

        private DateTime GetStageStart(IList<Match> matches, Stage stage)
        {
            var firstMatch = matches.Where(x => x.Stage == stage).OrderBy(x => x.DateTime).FirstOrDefault();
            if (firstMatch == null)
            {
                return DateTime.MaxValue;
            }

            return firstMatch.DateTime;
        }
    }
}