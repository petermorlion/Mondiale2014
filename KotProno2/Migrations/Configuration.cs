namespace KotProno2.Migrations
{
    using KotProno2.EntityFramework;
    using KotProno2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<KotProno2.EntityFramework.MatchesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KotProno2.EntityFramework.MatchesDbContext";
        }

        protected override void Seed(MatchesDbContext context)
        {
            CreateGroupstageMatches(context);
            UpdateGroupStageMatches(context);
            CreateEighthFinalMatches(context);
            CreateQuarterFinalMatches(context);
            CreateSemiFinalMatches(context);
        }

        private void CreateSemiFinalMatches(MatchesDbContext context)
        {
            var persistedSemiFinalMatches = context.Matches.Where(x => x.DateTime > new DateTime(2014, 7, 8, 0, 0, 0)).ToList();
            var semiFinal1 = new Match { DateTime = new DateTime(2014, 7, 8, 22, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Germany.IsoCode, Stage = Stage.SemiFinals };
            var semiFinal2 = new Match { DateTime = new DateTime(2014, 7, 9, 22, 0, 0), HomeTeamIsoCode = Teams.Netherlands.IsoCode, AwayTeamIsoCode = Teams.Argentinia.IsoCode, Stage = Stage.SemiFinals };
            var semiFinalMatches = new[] { semiFinal1, semiFinal2 };
            foreach (var match in semiFinalMatches)
            {
                if (!persistedSemiFinalMatches.Any(x => x.IsSameAs(match)))
                {
                    context.Matches.Add(match);
                }
            }
        }

        private void CreateQuarterFinalMatches(MatchesDbContext context)
        {
            var persistedQuarterFinalMatches = context.Matches.Where(x => x.DateTime > new DateTime(2014, 7, 1, 22, 0, 0)).ToList();
            var quarterFinal1 = new Match { DateTime = new DateTime(2014, 7, 4, 18, 0, 0), HomeTeamIsoCode = Teams.France.IsoCode, AwayTeamIsoCode = Teams.Germany.IsoCode, Stage = Stage.QuarterFinals};
            var quarterFinal2 = new Match { DateTime = new DateTime(2014, 7, 4, 22, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Colombia.IsoCode, Stage = Stage.QuarterFinals };
            var quarterFinal3 = new Match { DateTime = new DateTime(2014, 7, 5, 18, 0, 0), HomeTeamIsoCode = Teams.Argentinia.IsoCode, AwayTeamIsoCode = Teams.Belgium.IsoCode, Stage = Stage.QuarterFinals };
            var quarterFinal4 = new Match { DateTime = new DateTime(2014, 7, 5, 22, 0, 0), HomeTeamIsoCode = Teams.Netherlands.IsoCode, AwayTeamIsoCode = Teams.CostaRica.IsoCode, Stage = Stage.QuarterFinals };
            var quarterFinalMatches = new[] { quarterFinal1, quarterFinal2, quarterFinal3, quarterFinal4 };
            foreach (var match in quarterFinalMatches)
            {
                if (!persistedQuarterFinalMatches.Any(x => x.IsSameAs(match)))
                {
                    context.Matches.Add(match);
                }
            }
        }

        private void CreateEighthFinalMatches(MatchesDbContext context)
        {
            var persistedEighthFinalMatches = context.Matches.Where(x => x.DateTime > new DateTime(2014, 6, 26, 22, 0, 0)).ToList();
            var eighthFinal1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode, Stage = Stage.EighthFinals };
            var eighthFinal2 = new Match { DateTime = new DateTime(2014, 6, 28, 22, 0, 0), HomeTeamIsoCode = Teams.Colombia.IsoCode, AwayTeamIsoCode = Teams.Uruguay.IsoCode, Stage = Stage.EighthFinals };
            var eighthFinal3 = new Match { DateTime = new DateTime(2014, 6, 29, 18, 0, 0), HomeTeamIsoCode = Teams.Netherlands.IsoCode, AwayTeamIsoCode = Teams.Mexico.IsoCode, Stage = Stage.EighthFinals };
            var eighthFinal4 = new Match { DateTime = new DateTime(2014, 6, 29, 22, 0, 0), HomeTeamIsoCode = Teams.CostaRica.IsoCode, AwayTeamIsoCode = Teams.Greece.IsoCode, Stage = Stage.EighthFinals };
            var eighthFinal5 = new Match { DateTime = new DateTime(2014, 6, 30, 18, 0, 0), HomeTeamIsoCode = Teams.France.IsoCode, AwayTeamIsoCode = Teams.Nigeria.IsoCode, Stage = Stage.EighthFinals };
            var eighthFinal6 = new Match { DateTime = new DateTime(2014, 6, 30, 22, 0, 0), HomeTeamIsoCode = Teams.Germany.IsoCode, AwayTeamIsoCode = Teams.Algeria.IsoCode, Stage = Stage.EighthFinals };
            var eighthFinal7 = new Match { DateTime = new DateTime(2014, 7, 01, 18, 0, 0), HomeTeamIsoCode = Teams.Argentinia.IsoCode, AwayTeamIsoCode = Teams.Switzerland.IsoCode, Stage = Stage.EighthFinals };
            var eighthFinal8 = new Match { DateTime = new DateTime(2014, 7, 01, 22, 0, 0), HomeTeamIsoCode = Teams.Belgium.IsoCode, AwayTeamIsoCode = Teams.USA.IsoCode, Stage = Stage.EighthFinals };
            var eighthFinalMatches = new[] { eighthFinal1, eighthFinal2, eighthFinal3, eighthFinal4, eighthFinal5, eighthFinal6, eighthFinal7, eighthFinal8 };
            foreach (var match in eighthFinalMatches)
            {
                if (!persistedEighthFinalMatches.Any(x => x.IsSameAs(match)))
                {
                    context.Matches.Add(match);
                }
            }
        }

        private void UpdateGroupStageMatches(MatchesDbContext context)
        {
            var groupStageMatches = context.Matches.Where(x => x.DateTime <= new DateTime(2014, 6, 26, 22, 0, 0));
            foreach (var match in groupStageMatches)
            {
                match.Stage = Stage.GroupStage;
            }
        }

        private void CreateGroupstageMatches(MatchesDbContext context)
        {
            var lastMatch = new Match { DateTime = new DateTime(2014, 6, 26, 22, 0, 0), HomeTeamIsoCode = Teams.Algeria.IsoCode, AwayTeamIsoCode = Teams.Russia.IsoCode };
            var persistedMatches = context.Matches.ToList();
            if (persistedMatches.SingleOrDefault(x => x.IsSameAs(lastMatch)) != null)
            {
                return;
            }

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
                    lastMatch,
                };

            foreach (var match in matches)
            {
                context.Matches.AddOrUpdate(match);
            }
        }
    }
}
