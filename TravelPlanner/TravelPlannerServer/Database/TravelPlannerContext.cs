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
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TravelPlanner;Trusted_Connection=True;");
        }
    }
}
