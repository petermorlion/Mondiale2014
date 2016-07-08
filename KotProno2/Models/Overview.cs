using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public class Overview
    {
        public Overview()
        {
            UserNames = new List<string>();
            OverviewMatches = new List<OverviewMatch>();
            UsersWithCorrectTopScorer = new List<string>();
        }

        public IList<string> UserNames { get; private set; }
        public IList<OverviewMatch> OverviewMatches { get; private set; }
        public IList<string> UsersWithCorrectTopScorer { get; private set; }
    }
}