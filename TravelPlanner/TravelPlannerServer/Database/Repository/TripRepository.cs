using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Database.Repository
{
    internal sealed class TripRepository
        : Repository<Trip>, ITripRepository
    {
        #region Constructors
        public TripRepository(TravelPlannerContext context)
            : base(context)
        {

        }
        #endregion
    }
}
