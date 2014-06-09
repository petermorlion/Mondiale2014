using KotProno2.EntityFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public class AddBettingsCommand : Command
    {
        public override void Execute(MatchesDbContext context)
        {
            var data = this.Data as JObject;
            var bettings = data["newBettings"] as JArray;
            //TODO: save multiple bettings
            foreach (var betting in bettings)
            {
                var matchId = (int)betting["matchId"];
                var homeBetting = (int)betting["homeBetting"];
                var awayBetting = (int)betting["awayBetting"];
                var userName = UserName;
                var newBetting = new Betting
                {
                    MatchId = matchId,
                    HomeScore = homeBetting,
                    AwayScore = awayBetting,
                    UserName = UserName
                };

                context.Bettings.Add(newBetting);   
            }

            var topScorer = data["topScorer"]["TopScorerName"].ToString();
            if (string.IsNullOrEmpty(topScorer))
            {
                return;
            }

            var currentTopScorer = context.TopScorers.SingleOrDefault(x => x.UserName == UserName);
            if (currentTopScorer == null)
            {
                context.TopScorers.Add(new TopScorer { UserName = UserName, TopScorerName = topScorer });
            }
            else
            {
                currentTopScorer.TopScorerName = topScorer;
            }
        }
    }
}