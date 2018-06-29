using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KotProno2.Models
{
    public class Match
    {
        private DateTime _dateTime;

        public int Id { get; set; }

        [Column("Tournament_Id")]
        public int TournamentId { get; set; }

        [ForeignKey("TournamentId")]
        public Tournament Tournament { get; set; }

        public string HomeTeamIsoCode { get; set; }
        public string AwayTeamIsoCode { get; set; }
        public DateTime DateTime
        {
            get { return _dateTime; }
            set {
                _dateTime = value;
            }
        }

        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        public Stage Stage { get; set; }

        public bool IsReadOnly
        {
            get
            {
#if DEBUG
                return false;
#endif
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
            else if (HomeScore - AwayScore < 0)
            {
                return MatchResult.AwayWon;
            }
            else
            {
                if (PenaltyWinner.HasValue && PenaltyWinner.Value == KotProno2.Models.PenaltyWinner.Home)
                {
                    return MatchResult.HomeWon;
                }
                else if (PenaltyWinner.HasValue && PenaltyWinner.Value == KotProno2.Models.PenaltyWinner.Away)
                {
                    return MatchResult.AwayWon;
                }
                else
                {
                    return MatchResult.Draw;
                }
            }
        }

        public bool IsSameAs(Match match)
        {
            return DateTime == match.DateTime 
                && HomeTeamIsoCode == match.HomeTeamIsoCode 
                && AwayTeamIsoCode == match.AwayTeamIsoCode;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", HomeTeamIsoCode, AwayTeamIsoCode);
        }
    }
}