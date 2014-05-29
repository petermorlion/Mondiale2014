using KotProno2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public abstract class Command
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public object Data { get; set; }

        public DateTime DateTime { get; set; }

        public string UserName { get; set; }

        public abstract void Execute(MatchesDbContext context);
    }
}