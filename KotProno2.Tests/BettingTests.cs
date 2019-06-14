using KotProno2.Models;
using Xunit;

namespace KotProno2.Tests
{
    public class BettingTests
    {
        [Fact]
        public void GetUserScoreForMatch_WithCorrectScores_Returns2()
        {
            var betting = new Betting
            {
                AwayScore = 1,
                HomeScore = 2
            };

            var match = new Match
            {
                AwayScore = 1,
                HomeScore = 2
            };

            Assert.Equal(2, betting.GetUserScoreForMatch(match));
        }

        [Fact]
        public void GetUserScoreForMatch_WithCorrectResult_Returns1()
        {
            var betting = new Betting
            {
                AwayScore = 1,
                HomeScore = 2
            };

            var match = new Match
            {
                AwayScore = 1,
                HomeScore = 3
            };

            Assert.Equal(1, betting.GetUserScoreForMatch(match));
        }

        [Fact]
        public void GetUserScoreForMatch_WithWrongResult_Returns0()
        {
            var betting = new Betting
            {
                AwayScore = 1,
                HomeScore = 2
            };

            var match = new Match
            {
                AwayScore = 0,
                HomeScore = 0
            };

            Assert.Equal(0, betting.GetUserScoreForMatch(match));
        }

        [Fact]
        public void HasExactScoreForMatch_WithExactScore_ReturnsTrue()
        {
            var betting = new Betting
            {
                AwayScore = 1,
                HomeScore = 2
            };

            var match = new Match
            {
                AwayScore = 1,
                HomeScore = 2
            };

            Assert.True(betting.HasExactResultForMatch(match));
        }

        [Fact]
        public void HasExactScoreForMatch_WithDifferingScore_ReturnsFalse()
        {
            var betting = new Betting
            {
                AwayScore = 1,
                HomeScore = 2
            };

            var match = new Match
            {
                AwayScore = 1,
                HomeScore = 3
            };

            Assert.False(betting.HasExactResultForMatch(match));
        }
    }
}