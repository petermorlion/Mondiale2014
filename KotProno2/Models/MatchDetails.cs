using System;
using System.Collections.Generic;

namespace KotProno2.Models
{
    public class MatchDetails
    {
        public int Id { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public DateTime DateTime { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        public IList<Betting> Bettings { get; set; }
    }
}