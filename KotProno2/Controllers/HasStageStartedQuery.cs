using System;
using System.Collections.Generic;
using System.Linq;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class HasStageStartedQuery
    {
        private readonly MatchesDbContext _context = new MatchesDbContext();

        public bool Execute(int tournamentId, Stage stage)
        {
            var matches = _context.Matches.Where(x => x.TournamentId == tournamentId).OrderBy(x => x.DateTime).ToList();

            var stageStart = GetStageStart(matches, stage);

            return DateTime.UtcNow >= stageStart;
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