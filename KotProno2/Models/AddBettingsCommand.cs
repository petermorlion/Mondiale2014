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
            var data = this.Data as JArray;
            //TODO: save multiple bettings
            var matchId = (int)data[0]["matchId"];
            var homeBetting = (int)data[0]["homeBetting"];
            var awayBetting = (int)data[0]["awayBetting"];
            var userName = UserName;
            var betting = new Betting
            {
                MatchId = matchId,
                HomeScore = homeBetting,
                AwayScore = awayBetting,
                UserName = UserName
            };

            context.Bettings.Add(betting);
        }
    }
}