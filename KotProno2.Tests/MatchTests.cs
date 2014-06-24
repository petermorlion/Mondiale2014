using KotProno2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KotProno2.Tests
{
    public class MatchTests
    {
        [Fact]
        public void MatchIsSame()
        {
            var match1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode };
            var match2 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode };

            Assert.True(match1.IsSameAs(match2));
            Assert.True(match2.IsSameAs(match1));
        }

        [Fact]
        public void MatchIsNotSameIfDifferentDate()
        {
            var match1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode };
            var match2 = new Match { DateTime = new DateTime(2015, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode };

            Assert.False(match1.IsSameAs(match2));
            Assert.False(match2.IsSameAs(match1));
        }

        [Fact]
        public void MatchIsNotSameIfDifferentHomeTeam()
        {
            var match1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode };
            var match2 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Belgium.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode };

            Assert.False(match1.IsSameAs(match2));
            Assert.False(match2.IsSameAs(match1));
        }

        [Fact]
        public void MatchIsNotSameIfDifferentAwayTeam()
        {
            var match1 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Chili.IsoCode };
            var match2 = new Match { DateTime = new DateTime(2014, 6, 28, 18, 0, 0), HomeTeamIsoCode = Teams.Brasil.IsoCode, AwayTeamIsoCode = Teams.Croatia.IsoCode };

            Assert.False(match1.IsSameAs(match2));
            Assert.False(match2.IsSameAs(match1));
        }
    }
}
