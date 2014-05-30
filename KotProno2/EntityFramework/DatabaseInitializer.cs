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

        private static class Teams
        {
            public static Team Brasil = new Team { GroupLetter = "A", Name = "Brazilië", IsoCode = "br" };
            public static Team Croatia = new Team { GroupLetter = "A", Name = "Kroatië", IsoCode = "hr" };
            public static Team Mexico = new Team { GroupLetter = "A", Name = "Mexico", IsoCode = "mx" };
            public static Team Cameroon = new Team { GroupLetter = "A", Name = "Kameroen", IsoCode = "cm" };

            public static Team Spain = new Team { GroupLetter = "B", Name = "Spanje", IsoCode = "es" };
            public static Team Netherlands = new Team { GroupLetter = "B", Name = "Nederland", IsoCode = "nl" };
            public static Team Chili = new Team { GroupLetter = "B", Name = "Chili", IsoCode = "ch" };
            public static Team Australia = new Team { GroupLetter = "B", Name = "Australië", IsoCode = "au" };

            public static Team Colombia = new Team { GroupLetter = "C", Name = "Colombia", IsoCode = "co" };
            public static Team Greece = new Team { GroupLetter = "C", Name = "Griekenland", IsoCode = "gr" };
            public static Team IvoryCoast = new Team { GroupLetter = "C", Name = "Ivoorkust", IsoCode = "ci" };
            public static Team Japan = new Team { GroupLetter = "C", Name = "Japan", IsoCode = "jp" };

            public static Team Uruguay = new Team { GroupLetter = "D", Name = "Uruguay", IsoCode = "es" };
            public static Team CostaRica = new Team { GroupLetter = "D", Name = "Costa Rica", IsoCode = "cr" };
            public static Team England = new Team { GroupLetter = "D", Name = "Engeland", IsoCode = "en" };
            public static Team Italy = new Team { GroupLetter = "D", Name = "Italië", IsoCode = "it" };

            public static Team Switzerland = new Team { GroupLetter = "E", Name = "Zwitserland", IsoCode = "ch" };
            public static Team Ecuador = new Team { GroupLetter = "E", Name = "Ecuador", IsoCode = "ec" };
            public static Team France = new Team { GroupLetter = "E", Name = "Frankrijk", IsoCode = "fr" };
            public static Team Honduras = new Team { GroupLetter = "E", Name = "Honduras", IsoCode = "hn" };

            public static Team Argentinia = new Team { GroupLetter = "F", Name = "Argentinië", IsoCode = "ar" };
            public static Team Bosnia = new Team { GroupLetter = "F", Name = "Boznië-Herzegovina", IsoCode = "ba" };
            public static Team Iran = new Team { GroupLetter = "F", Name = "Iran", IsoCode = "ir" };
            public static Team Nigeria = new Team { GroupLetter = "F", Name = "Nigeria", IsoCode = "ng" };

            public static Team Germany = new Team { GroupLetter = "G", Name = "Duitsland", IsoCode = "de" };
            public static Team Portugal = new Team { GroupLetter = "G", Name = "Portugal", IsoCode = "pt" };
            public static Team Ghana = new Team { GroupLetter = "G", Name = "Ghana", IsoCode = "gh" };
            public static Team USA = new Team { GroupLetter = "G", Name = "USA", IsoCode = "us" };

            public static Team Belgium = new Team { GroupLetter = "H", Name = "België", IsoCode = "be" };
            public static Team Algeria = new Team { GroupLetter = "H", Name = "Algerije", IsoCode = "dz" };
            public static Team Russia = new Team { GroupLetter = "H", Name = "Rusland", IsoCode = "ru" };
            public static Team Korea = new Team { GroupLetter = "H", Name = "Zuid-Korea", IsoCode = "kr" };
        }
    }
}