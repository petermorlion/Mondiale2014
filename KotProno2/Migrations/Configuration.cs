using KotProno2.EntityFramework;
using System.Data.Entity.Migrations;

namespace KotProno2.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MatchesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "KotProno2.EntityFramework.MatchesDbContext";
        }
    }
}
