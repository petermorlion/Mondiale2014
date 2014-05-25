using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string HomeTeamIsoCode { get; set; }
        public string AwayTeamIsoCode { get; set; }
        public DateTime DateTime { get; set; }
    }
}