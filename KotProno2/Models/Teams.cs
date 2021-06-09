using System.Collections.Generic;

namespace KotProno2.Models
{
    public static class Teams
    {
        public static IEnumerable<Team> All => new List<Team>
        {
            Brasil,
            Croatia,
            Mexico,
            Cameroon,

            Spain,
            Netherlands,
            Chili,
            Australia,

            Colombia,
            Greece,
            IvoryCoast,
            Japan,

            Uruguay,
            CostaRica,
            GreatBritain,
            Italy,

            Switzerland,
            Ecuador,
            France,
            Honduras,

            Argentinia,
            Bosnia,
            Iran,
            Nigeria,

            Germany,
            Portugal,
            Ghana,
            USA,

            Belgium,
            Algeria,
            Russia,
            Korea,

            Romania,
            Albania,
            Wales,
            Slovakia,
            England,
            Turkey,
            Poland,
            NorthernIreland,
            Ukraine,
            Czech,
            Ireland,
            Sweden,
            Austria,
            Hungary,
            Iceland,
            Egypt,
            SaudiArabia,
            Marocco,
            Peru,
            Denmark,
            Serbia,
            Panama,
            Senegal,
            Tunisia,
            Finland,
            NorthMacedonia,
            Scotland
        };

        private static readonly Team Brasil = new Team("Brazilië", "br");
        private static readonly Team Croatia = new Team("Kroatië", "hr");
        private static readonly Team Mexico = new Team("Mexico", "mx");
        private static readonly Team Cameroon = new Team("Kameroen", "cm");
        private static readonly Team Spain = new Team("Spanje", "es");
        private static readonly Team Netherlands = new Team("Nederland", "nl");
        private static readonly Team Chili = new Team("Chili", "cl");
        private static readonly Team Australia = new Team("Australië", "au");
        private static readonly Team Colombia = new Team("Colombia", "co");
        private static readonly Team Greece = new Team("Griekenland", "gr");
        private static readonly Team IvoryCoast = new Team("Ivoorkust", "ci");
        private static readonly Team Japan = new Team("Japan", "jp");
        private static readonly Team Uruguay = new Team("Uruguay", "uy");
        private static readonly Team CostaRica = new Team("Costa Rica", "cr");
        private static readonly Team GreatBritain = new Team("Groot Brittannië", "gb");
        private static readonly Team Italy = new Team("Italië", "it");
        private static readonly Team Switzerland = new Team("Zwitserland", "ch");
        private static readonly Team Ecuador = new Team("Ecuador", "ec");
        private static readonly Team France = new Team("Frankrijk", "fr");
        private static readonly Team Honduras = new Team("Honduras", "hn");
        private static readonly Team Argentinia = new Team("Argentinië", "ar");
        private static readonly Team Bosnia = new Team("Boznië-Herzegovina", "ba");
        private static readonly Team Iran = new Team("Iran", "ir");
        private static readonly Team Nigeria = new Team("Nigeria", "ng");
        private static readonly Team Germany = new Team("Duitsland", "de");
        private static readonly Team Portugal = new Team("Portugal", "pt");
        private static readonly Team Ghana = new Team("Ghana", "gh");
        private static readonly Team USA = new Team("USA", "us");
        private static readonly Team Belgium = new Team("België", "be");
        private static readonly Team Algeria = new Team("Algerije", "dz");
        private static readonly Team Russia = new Team("Rusland", "ru");
        private static readonly Team Korea = new Team("Zuid-Korea", "kr");
        private static readonly Team Romania = new Team("Roemenië", "ro");
        private static readonly Team Albania = new Team("Albanië", "al");
        private static readonly Team Wales = new Team("Wales", "_Wales");
        private static readonly Team Slovakia = new Team("Slovakije", "sk");
        private static readonly Team England = new Team("Engeland", "_England");
        private static readonly Team Turkey = new Team("Turkije", "tr");
        private static readonly Team Poland = new Team("Polen", "pl");
        private static readonly Team NorthernIreland = new Team("Noord-Ierland", "_Northern_Ireland");
        private static readonly Team Ukraine = new Team("Oekraïne", "ua");
        private static readonly Team Czech = new Team("Tsjechië", "cz");
        private static readonly Team Ireland = new Team("Ierland", "ie");
        private static readonly Team Sweden = new Team("Zweden", "se");
        private static readonly Team Austria = new Team("Oostenrijk", "at");
        private static readonly Team Hungary = new Team("Hongarije", "hu");
        private static readonly Team Iceland = new Team("Ijsland", "is");
        private static readonly Team Egypt = new Team("Egypte", "eg");
        private static readonly Team SaudiArabia = new Team("Saoedi-Arabië", "sa");
        private static readonly Team Marocco = new Team("Marokko", "ma");
        private static readonly Team Peru = new Team("Peru", "pe");
        private static readonly Team Denmark = new Team("Denemarken", "dk");
        private static readonly Team Serbia = new Team("Serbia", "rs");
        private static readonly Team Panama = new Team("Panama", "pa");
        private static readonly Team Senegal = new Team("Senegal", "sn");
        private static readonly Team Tunisia = new Team("Tunesië", "tn");
        private static readonly Team Finland = new Team("Finland", "fi");
        private static readonly Team NorthMacedonia = new Team("Noord-Macedonië", "mk");
        private static readonly Team Scotland = new Team("Schotland", "_Scotland");
    }
}
