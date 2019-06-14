using System.Collections.Generic;

namespace KotProno2.Models
{
    public class Statistics
    {
        public IList<string> Categories { get; set; }
        public IList<Serie> Series { get; set; }
        public int MostExactResults { get; set; }
        public IList<string> MostExactResultsUsers { get; set; }
        public int LeastExactResults { get; set; }
        public IList<string> LeastExactResultsUsers { get; set; }
    }    
}