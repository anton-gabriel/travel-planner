using Microsoft.EntityFrameworkCore;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Database
{
    internal sealed class TravelPlannerContext
        : DbContext
    {
        #region Constructors
        public TravelPlannerContext()
        {
        }
        #endregion

        #region Properties
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TravelPlanner;Trusted_Connection=True;");
        }
    }
}
