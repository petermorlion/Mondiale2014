namespace KotProno2.Models
{
    public class TopScorer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string TopScorerName { get; set; }
        public int TournamentId { get; set; }
        public bool IsCorrect { get; set; }
    }
}