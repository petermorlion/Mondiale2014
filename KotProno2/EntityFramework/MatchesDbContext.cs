using KotProno2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KotProno2.Migrations;

namespace KotProno2.EntityFramework
{
    public class MatchesDbContext : DbContext
    {
        public static string ContextName { get { return "DefaultConnection"; } }

        public MatchesDbContext()
            : base(ContextName)
        {
            // TODO: not necessary? See 'Create your ObjectContext/DbContext Dynamically (in the documentation)
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Command> Commands { get; set; }

        public DbSet<Betting> Bettings { get; set; }

        public DbSet<TopScorer> TopScorers { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }
    }
}