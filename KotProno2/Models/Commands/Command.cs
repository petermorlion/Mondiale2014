using KotProno2.EntityFramework;
using System;

namespace KotProno2.Models.Commands
{
    public abstract class Command
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public DateTime DateTime { get; set; }

        public string UserName { get; set; }

        public abstract void Execute(MatchesDbContext context);
    }
}