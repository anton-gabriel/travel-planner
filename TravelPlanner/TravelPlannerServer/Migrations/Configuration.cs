using System.Data.Entity.Migrations;
using TravelPlannerServer.Database;

namespace TravelPlannerServer.Migrations
{
    internal sealed class Configuration
        : DbMigrationsConfiguration<TravelPlannerContext>
    {
        #region Constructors
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        #endregion
    }
}
