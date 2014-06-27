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
            var matches = context.Matches;
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

                if (!CanSave(newBetting, matches))
                {
                    continue;
                }

                context.Bettings.Add(newBetting);   
            }

            if (data["topScorer"] == null)
            {
                return;
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

        private bool CanSave(Betting newBetting, IEnumerable<Match> matches)
        {
            var match = matches.SingleOrDefault(x => x.Id == newBetting.MatchId);

            if (match == null)
                return false;

            // TODO: more or less duplicate from controller
            switch (match.Stage)
            {
                case Stage.GroupStage:
                    return DateTime.UtcNow < new DateTime(2014, 6, 12, 20, 0, 0, DateTimeKind.Utc);
                case Stage.EighthFinals:
                    return DateTime.UtcNow < new DateTime(2014, 6, 28, 16, 0, 0, DateTimeKind.Utc);
                case Stage.QuarterFinals:
                    return DateTime.UtcNow < new DateTime(2014, 7, 04, 16, 0, 0, DateTimeKind.Utc);
                case Stage.SemiFinals:
                    return DateTime.UtcNow < new DateTime(2014, 7, 08, 20, 0, 0, DateTimeKind.Utc);
                case Stage.Finals:
                    return DateTime.UtcNow < new DateTime(2014, 7, 12, 20, 0, 0, DateTimeKind.Utc);
                default:
                    return false;
            }
        }
    }
}