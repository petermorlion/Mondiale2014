﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
    }
}