using System.ComponentModel.DataAnnotations.Schema;

namespace KotProno2.Models
{
    public class Betting
    {
        public int Id { get; set; }

        public int MatchId { get; set; }

        [ForeignKey("MatchId")]
        public Match Match { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public string UserName { get; set; }

        public MatchResult GetMatchResult()
        {
            if (HomeScore - AwayScore > 0)
            {
                return MatchResult.HomeWon;
            }
            else if (HomeScore - AwayScore < 0)
            {
                return MatchResult.AwayWon;
            }
            else
            {
                return MatchResult.Draw;
            }
        }
    }
}