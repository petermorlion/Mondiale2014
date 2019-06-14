using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KotProno2.Models
{
    public class Match
    {
        public int Id { get; set; }

        [Column("Tournament_Id")]
        public int TournamentId { get; set; }

        [ForeignKey("TournamentId")]
        public Tournament Tournament { get; set; }

        public string HomeTeamIsoCode { get; set; }
        public string AwayTeamIsoCode { get; set; }
        public DateTime DateTime { get; set; }

        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        public Stage Stage { get; set; }

        public bool IsReadOnly
        {
            get
            {
                var now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));
                return now >= DateTime;
            }
        }

        public PenaltyWinner? PenaltyWinner { get; set; }

        public MatchResult GetMatchResult()
        {
            if (!HomeScore.HasValue || !AwayScore.HasValue)
            {
                return MatchResult.Draw;
            }

            if (HomeScore - AwayScore > 0)
            {
                return MatchResult.HomeWon;
            }

            if (HomeScore - AwayScore < 0)
            {
                return MatchResult.AwayWon;
            }

            if (PenaltyWinner.HasValue && PenaltyWinner.Value == KotProno2.Models.PenaltyWinner.Home)
            {
                return MatchResult.HomeWon;
            }

            if (PenaltyWinner.HasValue && PenaltyWinner.Value == KotProno2.Models.PenaltyWinner.Away)
            {
                return MatchResult.AwayWon;
            }

            return MatchResult.Draw;
        }

        public bool IsSameAs(Match match)
        {
            return DateTime == match.DateTime 
                && HomeTeamIsoCode == match.HomeTeamIsoCode 
                && AwayTeamIsoCode == match.AwayTeamIsoCode;
        }

        public override string ToString()
        {
            return $"{HomeTeamIsoCode} - {AwayTeamIsoCode}";
        }

        public bool HasScores()
        {
            return HomeScore.HasValue && AwayScore.HasValue;
        }
    }
}