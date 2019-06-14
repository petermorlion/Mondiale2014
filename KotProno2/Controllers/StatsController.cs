using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class StatsController : ApiController
    {
        private readonly MatchesDbContext _context;
        private readonly ApplicationDbContext _applicationDbContext = new ApplicationDbContext();

        public StatsController(MatchesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Statistics Statistics(int id)
        {
            var result = new Statistics();
            var users = _applicationDbContext.Users.OrderBy(x => x.UserName).ToList();
            var bettings = _context.Bettings.Where(x => x.Match.TournamentId == id).ToLookup(x => x.MatchId);
            var matches = _context.Matches.Where(x => x.TournamentId == id).OrderBy(x => x.DateTime).ToList();

            result.Categories = matches.Select(match => $"{match.HomeTeamIsoCode} vs {match.AwayTeamIsoCode}").ToList();
            result.Series = users.Select(user => new Serie { Name = user.UserName, Data = new List<int>() }).ToList();
            var exactResultsPerUser = users.ToDictionary(x => x.UserName, x => 0);

            foreach (var match in matches.Where(match => match.HasScores()))
            {
                foreach (var user in users)
                {
                    var bettingForMatch = bettings[match.Id].SingleOrDefault(x => x.UserName == user.UserName);
                    var serie = result.Series.Single(x => x.Name == user.UserName);
                    var previousScore = serie.Data.LastOrDefault();

                    if (bettingForMatch == null)
                    {
                        serie.Data.Add(previousScore);
                    }
                    else
                    {
                        serie.Data.Add(previousScore + bettingForMatch.GetUserScoreForMatch(match));

                        if (bettingForMatch.HasExactResultForMatch(match))
                        {
                            exactResultsPerUser[user.UserName] += 1;
                        }
                    }
                }
            }

            var mostExactResults = exactResultsPerUser.Max(x => x.Value);
            result.MostExactResults = mostExactResults;
            result.MostExactResultsUsers = exactResultsPerUser
                .Where(x => x.Value == mostExactResults)
                .Select(x => x.Key).ToList();

            var leastExactResults = exactResultsPerUser.Min(x => x.Value);
            result.LeastExactResults = leastExactResults;
            result.LeastExactResultsUsers = exactResultsPerUser
                .Where(x => x.Value == leastExactResults)
                .Select(x => x.Key).ToList();

            return result;
        }
    }
}