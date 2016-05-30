﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class StatsController : ApiController
    {
        private readonly MatchesContext _matchesContext = new MatchesContext();
        private readonly ApplicationDbContext _applicationDbContext = new ApplicationDbContext();

        [HttpGet]
        public Statistics Statistics(int id)
        {
            var exactResultsPerUser = new Dictionary<string, int>();

            var result = new Statistics();
            var users = _applicationDbContext.Users.OrderBy(x => x.UserName).ToList();
            var bettings = _matchesContext.Context.Bettings.Where(x => x.Match.TournamentId == id).ToLookup(x => x.MatchId);
            var matches = _matchesContext.Context.Matches.Where(x => x.TournamentId == id).OrderBy(x => x.DateTime).ToList();

            result.Categories = new List<string>();
            result.Series = new List<Serie>();

            foreach (var user in users)
            {
                result.Series.Add(new Serie { Name = user.UserName, Data = new List<int>() });
                exactResultsPerUser.Add(user.UserName, 0);
            }

            foreach (var match in matches)
            {
                result.Categories.Add($"{match.HomeTeamIsoCode} vs {match.AwayTeamIsoCode}");

                if (!match.HomeScore.HasValue && !match.AwayScore.HasValue)
                {
                    continue;
                }

                var bettingsForMatch = bettings[match.Id].OrderBy(x => x.UserName);
                foreach (var betting in bettingsForMatch)
                {
                    var serie = result.Series.Single(x => x.Name == betting.UserName);
                    var previousScore = serie.Data.LastOrDefault();

                    if (betting.HomeScore == match.HomeScore && betting.AwayScore == match.AwayScore)
                    {
                        serie.Data.Add(previousScore + 2);
                        exactResultsPerUser[betting.UserName] += 1;
                    }
                    else if (betting.GetMatchResult() == match.GetMatchResult())
                    {
                        serie.Data.Add(previousScore + 1);
                    }
                    else
                    {
                        serie.Data.Add(previousScore);
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