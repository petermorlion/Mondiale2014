using KotProno2.Models;
using System;
using System.Linq;
using Xunit;

namespace KotProno2.Tests
{
    public class MatchTests
    {
        private readonly Team _brasil = Teams.All.Single(x => x.IsoCode == "br");
        private readonly Team _chili = Teams.All.Single(x => x.IsoCode == "cl");
        private readonly Team _belgium = Teams.All.Single(x => x.IsoCode == "be");
        private readonly Team _croatia = Teams.All.Single(x => x.IsoCode == "hr");

        [Fact]
        public void MatchIsSame()
        {
            var match1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = _brasil.IsoCode, AwayTeamIsoCode = _chili.IsoCode };
            var match2 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = _brasil.IsoCode, AwayTeamIsoCode = _chili.IsoCode };

            Assert.True(match1.IsSameAs(match2));
            Assert.True(match2.IsSameAs(match1));
        }

        [Fact]
        public void MatchIsNotSameIfDifferentDate()
        {
            var match1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = _brasil.IsoCode, AwayTeamIsoCode = _chili.IsoCode };
            var match2 = new Match { DateTime = new DateTime(2015, 6, 28, 18, 0, 0), HomeTeamIsoCode = _brasil.IsoCode, AwayTeamIsoCode = _chili.IsoCode };

            Assert.False(match1.IsSameAs(match2));
            Assert.False(match2.IsSameAs(match1));
        }

        [Fact]
        public void MatchIsNotSameIfDifferentHomeTeam()
        {
            var match1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = _brasil.IsoCode, AwayTeamIsoCode = _chili.IsoCode };
            var match2 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = _belgium.IsoCode, AwayTeamIsoCode = _chili.IsoCode };

            Assert.False(match1.IsSameAs(match2));
            Assert.False(match2.IsSameAs(match1));
        }

        [Fact]
        public void MatchIsNotSameIfDifferentAwayTeam()
        {
            var match1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = _brasil.IsoCode, AwayTeamIsoCode = _chili.IsoCode };
            var match2 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = _brasil.IsoCode, AwayTeamIsoCode = _croatia.IsoCode };

            Assert.False(match1.IsSameAs(match2));
            Assert.False(match2.IsSameAs(match1));
        }

        [Fact]
        public void HasScores_WithBothScores_ReturnsTrue()
        {
            var match = new Match() { AwayScore = 1, HomeScore = 2 };

            Assert.True(match.HasScores());
        }

        [Fact]
        public void HasScores_WithoutHomeScore_ReturnsFalse()
        {
            var match = new Match() { AwayScore = 1 };

            Assert.False(match.HasScores());
        }

        [Fact]
        public void HasScores_WithoutAwayScore_ReturnsFalse()
        {
            var match = new Match() { HomeScore = 1 };

            Assert.False(match.HasScores());
        }
    }
}
