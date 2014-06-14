using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public class OverviewMatch
    {
        public string HomeTeamIsoCode { get; set; }
        public string AwayTeamIsoCode { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
    }
}