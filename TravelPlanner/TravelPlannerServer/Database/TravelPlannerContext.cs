using System.Data.Entity;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Database
{
    internal sealed class TravelPlannerContext
        : DbContext
    {
        #region Constructors
        public TravelPlannerContext()
            : base("name=TravelPlannerContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Properties
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
