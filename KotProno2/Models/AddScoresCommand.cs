using KotProno2.EntityFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public class AddScoresCommand : Command
    {
        public override void Execute(MatchesDbContext context)
        {
            var jObject = JObject.Parse(this.Data);
            var data = jObject;
            var newScores = data["newScores"] as JArray;
            var matches = context.Matches.ToList();

            foreach (var newScore in newScores)
            {
                var matchId = (int)newScore["matchId"];
                var homeScore = (int)newScore["homeScore"];
                var awayScore = (int)newScore["awayScore"];
                var penaltyWinnerString = (string)newScore["penaltyWinner"];

                var match = matches.SingleOrDefault(x => x.Id == matchId);
                if (match == null)
                    continue;

                match.HomeScore = homeScore;
                match.AwayScore = awayScore;

                PenaltyWinner penaltyWinner;
                if (Enum.TryParse(penaltyWinnerString, out penaltyWinner))
                {
                    match.PenaltyWinner = penaltyWinner;
                }
                else
                {
                    match.PenaltyWinner = null;
                }
            }
        }
    }
}