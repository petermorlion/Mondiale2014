using KotProno2.EntityFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KotProno2.Controllers;

namespace KotProno2.Models
{
    public class AddBettingsCommand : Command
    {
        public override void Execute(MatchesDbContext context)
        {
            var jObject = JObject.Parse(this.Data);
            var data = jObject;
            var bettings = data["newBettings"] as JArray;
            var matches = context.Matches;
            var currentBettings = context.Bettings.Where(x => x.UserName == UserName);

            foreach (var betting in bettings)
            {
                var matchId = (int)betting["matchId"];
                var homeBetting = (int)betting["homeBetting"];
                var awayBetting = (int)betting["awayBetting"];

                if (!CanSave(matchId, matches))
                {
                    continue;
                }

                var existingBetting = currentBettings.SingleOrDefault(x => x.MatchId == matchId);
                if (existingBetting == null)
                {
                    var newBetting = new Betting
                    {
                        MatchId = matchId,
                        HomeScore = homeBetting,
                        AwayScore = awayBetting,
                        UserName = UserName
                    };

                    context.Bettings.Add(newBetting);   
                }
                else
                {
                    existingBetting.HomeScore = homeBetting;
                    existingBetting.AwayScore = awayBetting;
                }
            }

            if (data["topScorer"] == null)
            {
                return;
            }

            var topScorer = data["topScorer"]["TopScorerName"].ToString();
            var tournamentId = int.Parse(data["topScorer"]["TournamentId"].ToString());
            if (string.IsNullOrEmpty(topScorer))
            {
                return;
            }

            var currentTopScorer = context.TopScorers.SingleOrDefault(x => x.UserName == UserName && x.TournamentId == tournamentId);
            if (currentTopScorer == null)
            {
                context.TopScorers.Add(new TopScorer { UserName = UserName, TopScorerName = topScorer, TournamentId = tournamentId});
            }
            else
            {
                currentTopScorer.TopScorerName = topScorer;
            }
        }

        private bool CanSave(int matchId, IEnumerable<Match> matches)
        {
            var match = matches.SingleOrDefault(x => x.Id == matchId);

            if (match == null)
                return false;

            return !match.IsReadOnly;
        }
    }
}