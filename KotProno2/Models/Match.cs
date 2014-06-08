using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public class Match
    {
        private DateTime _dateTime;

        public int Id { get; set; }
        public string HomeTeamIsoCode { get; set; }
        public string AwayTeamIsoCode { get; set; }
        public DateTime DateTime
        {
            get { return _dateTime; }
            set {
                _dateTime = value;
                Date = value.ToString("dd MM");
                Time = value.ToString("Hh:mm");
            }
        }

        public string Date { get; set; }
        public string Time { get; set; }
    }
}