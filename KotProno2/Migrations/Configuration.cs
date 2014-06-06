namespace KotProno2.Migrations
{
    using KotProno2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KotProno2.EntityFramework.MatchesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KotProno2.EntityFramework.MatchesDbContext";
        }

        protected override void Seed(KotProno2.EntityFramework.MatchesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var matches = new List<Match>
                {
                    new Match { DateTime = new DateTime(2014, 6, 12, 22, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Croatia.IsoCode },
                    
                    new Match { DateTime = new DateTime(2014, 6, 13, 18, 0, 0), HomeTeamIsoCode = Teams.Mexico.IsoCode, AwayTeamIsoCode = Teams.Cameroon.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 13, 21, 0, 0), HomeTeamIsoCode = Teams.Spain.IsoCode, AwayTeamIsoCode = Teams.Netherlands.IsoCode },
                    
                    new Match { DateTime = new DateTime(2014, 6, 14, 00, 0, 0), HomeTeamIsoCode = Teams.Chili.IsoCode, AwayTeamIsoCode = Teams.Australia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 14, 18, 0, 0), HomeTeamIsoCode = Teams.Colombia.IsoCode, AwayTeamIsoCode = Teams.Greece.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 14, 21, 0, 0), HomeTeamIsoCode = Teams.Uruguay.IsoCode, AwayTeamIsoCode = Teams.CostaRica.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 15, 00, 0, 0), HomeTeamIsoCode = Teams.England.IsoCode, AwayTeamIsoCode = Teams.Italy.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 15, 03, 0, 0), HomeTeamIsoCode = Teams.IvoryCoast.IsoCode, AwayTeamIsoCode = Teams.Japan.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 15, 18, 0, 0), HomeTeamIsoCode = Teams.Switzerland.IsoCode, AwayTeamIsoCode = Teams.Ecuador.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 15, 21, 0, 0), HomeTeamIsoCode = Teams.France.IsoCode, AwayTeamIsoCode = Teams.Honduras.IsoCode },
                    
                    new Match { DateTime = new DateTime(2014, 6, 16, 00, 0, 0), HomeTeamIsoCode = Teams.Argentinia.IsoCode, AwayTeamIsoCode = Teams.Bosnia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 16, 18, 0, 0), HomeTeamIsoCode = Teams.Germany.IsoCode, AwayTeamIsoCode = Teams.Portugal.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 16, 21, 0, 0), HomeTeamIsoCode = Teams.Iran.IsoCode, AwayTeamIsoCode = Teams.Nigeria.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 17, 00, 0, 0), HomeTeamIsoCode = Teams.Ghana.IsoCode, AwayTeamIsoCode = Teams.USA.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 17, 18, 0, 0), HomeTeamIsoCode = Teams.Belgium.IsoCode, AwayTeamIsoCode = Teams.Algeria.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 17, 21, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Mexico.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 18, 00, 0, 0), HomeTeamIsoCode = Teams.Russia.IsoCode, AwayTeamIsoCode = Teams.Korea.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 18, 18, 0, 0), HomeTeamIsoCode = Teams.Australia.IsoCode, AwayTeamIsoCode = Teams.Netherlands.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 18, 21, 0, 0), HomeTeamIsoCode = Teams.Spain.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 19, 00, 0, 0), HomeTeamIsoCode = Teams.Cameroon.IsoCode, AwayTeamIsoCode = Teams.Croatia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 19, 18, 0, 0), HomeTeamIsoCode = Teams.Colombia.IsoCode, AwayTeamIsoCode = Teams.IvoryCoast.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 19, 21, 0, 0), HomeTeamIsoCode = Teams.Uruguay.IsoCode, AwayTeamIsoCode = Teams.England.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 20, 00, 0, 0), HomeTeamIsoCode = Teams.Japan.IsoCode, AwayTeamIsoCode = Teams.Greece.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 20, 18, 0, 0), HomeTeamIsoCode = Teams.Italy.IsoCode, AwayTeamIsoCode = Teams.CostaRica.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 20, 21, 0, 0), HomeTeamIsoCode = Teams.Switzerland.IsoCode, AwayTeamIsoCode = Teams.France.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 21, 00, 0, 0), HomeTeamIsoCode = Teams.Honduras.IsoCode, AwayTeamIsoCode = Teams.Ecuador.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 21, 18, 0, 0), HomeTeamIsoCode = Teams.Argentinia.IsoCode, AwayTeamIsoCode = Teams.Iran.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 21, 21, 0, 0), HomeTeamIsoCode = Teams.Germany.IsoCode, AwayTeamIsoCode = Teams.Ghana.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 22, 00, 0, 0), HomeTeamIsoCode = Teams.Nigeria.IsoCode, AwayTeamIsoCode = Teams.Bosnia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 22, 18, 0, 0), HomeTeamIsoCode = Teams.Belgium.IsoCode, AwayTeamIsoCode = Teams.Russia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 22, 21, 0, 0), HomeTeamIsoCode = Teams.Korea.IsoCode, AwayTeamIsoCode = Teams.Algeria.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 23, 00, 0, 0), HomeTeamIsoCode = Teams.USA.IsoCode, AwayTeamIsoCode = Teams.Portugal.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 23, 18, 0, 0), HomeTeamIsoCode = Teams.Australia.IsoCode, AwayTeamIsoCode = Teams.Spain.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 23, 18, 0, 0), HomeTeamIsoCode = Teams.Netherlands.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 23, 22, 0, 0), HomeTeamIsoCode = Teams.Cameroon.IsoCode, AwayTeamIsoCode = Teams.Brasil.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 23, 22, 0, 0), HomeTeamIsoCode = Teams.Croatia.IsoCode, AwayTeamIsoCode = Teams.Mexico.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 24, 18, 0, 0), HomeTeamIsoCode = Teams.Italy.IsoCode, AwayTeamIsoCode = Teams.Uruguay.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 24, 18, 0, 0), HomeTeamIsoCode = Teams.CostaRica.IsoCode, AwayTeamIsoCode = Teams.England.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 24, 22, 0, 0), HomeTeamIsoCode = Teams.Japan.IsoCode, AwayTeamIsoCode = Teams.Colombia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 24, 22, 0, 0), HomeTeamIsoCode = Teams.Greece.IsoCode, AwayTeamIsoCode = Teams.IvoryCoast.IsoCode },
                    
                    new Match { DateTime = new DateTime(2014, 6, 25, 18, 0, 0), HomeTeamIsoCode = Teams.Nigeria.IsoCode, AwayTeamIsoCode = Teams.Argentinia.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 25, 18, 0, 0), HomeTeamIsoCode = Teams.Bosnia.IsoCode, AwayTeamIsoCode = Teams.Iran.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 25, 22, 0, 0), HomeTeamIsoCode = Teams.Honduras.IsoCode, AwayTeamIsoCode = Teams.Switzerland.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 25, 22, 0, 0), HomeTeamIsoCode = Teams.Ecuador.IsoCode, AwayTeamIsoCode = Teams.France.IsoCode },

                    new Match { DateTime = new DateTime(2014, 6, 26, 18, 0, 0), HomeTeamIsoCode = Teams.USA.IsoCode, AwayTeamIsoCode = Teams.Germany.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 26, 18, 0, 0), HomeTeamIsoCode = Teams.Portugal.IsoCode, AwayTeamIsoCode = Teams.Ghana.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 26, 22, 0, 0), HomeTeamIsoCode = Teams.Korea.IsoCode, AwayTeamIsoCode = Teams.Belgium.IsoCode },
                    new Match { DateTime = new DateTime(2014, 6, 26, 22, 0, 0), HomeTeamIsoCode = Teams.Algeria.IsoCode, AwayTeamIsoCode = Teams.Russia.IsoCode },
                };

            foreach (var match in matches)
            {
                // TODO: not the most efficient (separate query every time)
                if (context.Matches.SingleOrDefault(x => x.DateTime == match.DateTime && x.HomeTeamIsoCode == match.HomeTeamIsoCode && x.AwayTeamIsoCode == match.AwayTeamIsoCode) == null)
                {
                    context.Matches.AddOrUpdate(match);
                }
            }
        }
    }
}
