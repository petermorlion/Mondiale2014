using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public static class Teams
    {
        public static IEnumerable<Team> All
        {
            get
            {
                return new List<Team>
                    {
                        Teams.Brasil,
                        Teams.Croatia,
                        Teams.Mexico,
                        Teams.Cameroon,
                        
                        Teams.Spain,
                        Teams.Netherlands,
                        Teams.Chili,
                        Teams.Australia,
                        
                        Teams.Colombia,
                        Teams.Greece,
                        Teams.IvoryCoast,
                        Teams.Japan,
                        
                        Teams.Uruguay,
                        Teams.CostaRica,
                        Teams.England,
                        Teams.Italy,
                        
                        Teams.Switzerland,
                        Teams.Ecuador,
                        Teams.France,
                        Teams.Honduras,
                        
                        Teams.Argentinia,
                        Teams.Bosnia,
                        Teams.Iran,
                        Teams.Nigeria,
                        
                        Teams.Germany,
                        Teams.Portugal,
                        Teams.Ghana,
                        Teams.USA,
                        
                        Teams.Belgium,
                        Teams.Algeria,
                        Teams.Russia,
                        Teams.Korea
                    };
            }
        }

        public static Team Brasil = new Team { GroupLetter = "A", Name = "Brazilië", IsoCode = "br" };
        public static Team Croatia = new Team { GroupLetter = "A", Name = "Kroatië", IsoCode = "hr" };
        public static Team Mexico = new Team { GroupLetter = "A", Name = "Mexico", IsoCode = "mx" };
        public static Team Cameroon = new Team { GroupLetter = "A", Name = "Kameroen", IsoCode = "cm" };

        public static Team Spain = new Team { GroupLetter = "B", Name = "Spanje", IsoCode = "es" };
        public static Team Netherlands = new Team { GroupLetter = "B", Name = "Nederland", IsoCode = "nl" };
        public static Team Chili = new Team { GroupLetter = "B", Name = "Chili", IsoCode = "cl" };
        public static Team Australia = new Team { GroupLetter = "B", Name = "Australië", IsoCode = "au" };

        public static Team Colombia = new Team { GroupLetter = "C", Name = "Colombia", IsoCode = "co" };
        public static Team Greece = new Team { GroupLetter = "C", Name = "Griekenland", IsoCode = "gr" };
        public static Team IvoryCoast = new Team { GroupLetter = "C", Name = "Ivoorkust", IsoCode = "ci" };
        public static Team Japan = new Team { GroupLetter = "C", Name = "Japan", IsoCode = "jp" };

        public static Team Uruguay = new Team { GroupLetter = "D", Name = "Uruguay", IsoCode = "uy" };
        public static Team CostaRica = new Team { GroupLetter = "D", Name = "Costa Rica", IsoCode = "cr" };
        public static Team England = new Team { GroupLetter = "D", Name = "Engeland", IsoCode = "gb" };
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