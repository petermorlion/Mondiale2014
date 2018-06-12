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
                        Teams.GreatBritain,
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
                        Teams.Korea,

                        Teams.Romania,
                        Teams.Albania,
                        Teams.Wales,
                        Teams.Slovakia,
                        Teams.England,
                        Teams.Turkey,
                        Teams.Poland,
                        Teams.NorthernIreland,
                        Teams.Ukraine,
                        Teams.Czech,
                        Teams.Ireland,
                        Teams.Sweden,
                        Teams.Austria,
                        Teams.Hungary,
                        Teams.Iceland,
                        Teams.Egypt,
                        Teams.SaudiArabia,
                        Teams.Marocco,
                        Teams.Peru,
                        Teams.Denmark,
                        Teams.Serbia,
                        Teams.Panama,
                        Teams.Senegal,
                        Teams.Tunisia
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
        public static Team GreatBritain = new Team { GroupLetter = "D", Name = "Groot Brittannië", IsoCode = "gb" };
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

        public static Team Romania = new Team { IsoCode = "ro", Name = "Roemenië" };
        public static Team Albania = new Team { IsoCode = "al", Name = "Albanië" };
        public static Team Wales = new Team { IsoCode = "_Wales", Name = "Wales" };
        public static Team Slovakia = new Team { IsoCode = "sk", Name = "Slovakije" };
        public static Team England = new Team { IsoCode = "_England", Name = "Engeland" };
        public static Team Turkey = new Team { IsoCode = "tr", Name = "Turkije" };
        public static Team Poland = new Team { IsoCode = "pl", Name = "Polen" };
        public static Team NorthernIreland = new Team { IsoCode = "_Northern_Ireland", Name = "Noord-Ierland" };
        public static Team Ukraine = new Team { IsoCode = "ua", Name = "Oekraïne" };
        public static Team Czech = new Team { IsoCode = "cz", Name = "Tsjechië" };
        public static Team Ireland = new Team { IsoCode = "ie", Name = "Ierland" };
        public static Team Sweden = new Team { IsoCode = "se", Name = "Zweden" };
        public static Team Austria = new Team { IsoCode = "at", Name = "Oostenrijk" };
        public static Team Hungary = new Team { IsoCode = "hu", Name = "Hongarije" };
        public static Team Iceland = new Team { IsoCode = "is", Name = "Ijsland" };
        public static Team Egypt = new Team { IsoCode = "eg", Name = "Egypte" };
        public static Team SaudiArabia = new Team { IsoCode = "sa", Name = "Saoedi-Arabië" };
        public static Team Marocco = new Team { IsoCode = "ma", Name = "Marokko" };
        public static Team Peru = new Team { IsoCode = "pe", Name = "Peru" };
        public static Team Denmark = new Team { IsoCode = "dk", Name = "Denemarken" };
        public static Team Serbia = new Team { IsoCode = "rs", Name = "Serbia" };
        public static Team Panama = new Team { IsoCode = "pa", Name = "Panama" };
        public static Team Senegal = new Team { IsoCode = "sn", Name = "Senegal" };
        public static Team Tunisia = new Team { IsoCode = "tn", Name = "Tunesië" };
    }
}