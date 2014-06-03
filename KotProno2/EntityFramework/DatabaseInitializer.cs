using KotProno2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KotProno2.EntityFramework
{
    // TODO: use correct inheritance!
    public class DatabaseInitializer : DropCreateDatabaseAlways<MatchesDbContext>
    {
        protected override void Seed(MatchesDbContext context)
        {
            var matches = new List<Match>
                {
                    new Match { DateTime = new DateTime(2014, 6, 12, 22, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Croatia.IsoCode },
                    
                    new Match { DateTime = new DateTime(2014, 6, 13, 18, 0, 0), HomeTeamIsoCode = Teams.Mexico.IsoCode, AwayTeamIsoCode = Teams.Cameroon.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 13, 21, 0, 0), HomeTeamIsoCode = Teams.Spain.IsoCode, AwayTeamIsoCode = Teams.Netherlands.IsoCode },
                    
                    new Match { DateTime = new DateTime(2014, 6, 14, 00, 0, 0), HomeTeamIsoCode = Teams.Chili.IsoCode, AwayTeamIsoCode = Teams.Australia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 14, 18, 0, 0), HomeTeamIsoCode = Teams.England.IsoCode, AwayTeamIsoCode = Teams.Italy.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 14, 18, 0, 0), HomeTeamIsoCode = Teams.Colombia.IsoCode, AwayTeamIsoCode = Teams.Greece.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 14, 21, 0, 0), HomeTeamIsoCode = Teams.Uruguay.IsoCode, AwayTeamIsoCode = Teams.CostaRica.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 15, 03, 0, 0), HomeTeamIsoCode = Teams.IvoryCoast.IsoCode, AwayTeamIsoCode = Teams.Japan.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 15, 18, 0, 0), HomeTeamIsoCode = Teams.Switzerland.IsoCode, AwayTeamIsoCode = Teams.Ecuador.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 15, 21, 0, 0), HomeTeamIsoCode = Teams.France.IsoCode, AwayTeamIsoCode = Teams.Honduras.IsoCode },
                    
                    new Match { DateTime = new DateTime(2014, 6, 16, 00, 0, 0), HomeTeamIsoCode = Teams.Argentinia.IsoCode, AwayTeamIsoCode = Teams.Bosnia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 16, 18, 0, 0), HomeTeamIsoCode = Teams.Germany.IsoCode, AwayTeamIsoCode = Teams.Portugal.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 16, 21, 0, 0), HomeTeamIsoCode = Teams.Iran.IsoCode, AwayTeamIsoCode = Teams.Nigeria.IsoCode },
                };

            foreach (var match in matches)
                context.Matches.Add(match);

            base.Seed(context);
        }
    }
}