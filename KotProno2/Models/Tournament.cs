using System.Collections.Generic;

namespace KotProno2.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Match> Matches { get; set; }
    }
}