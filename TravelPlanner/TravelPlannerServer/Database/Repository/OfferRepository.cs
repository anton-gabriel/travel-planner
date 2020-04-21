using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Database.Repository
{
    internal sealed class OfferRepository
        : Repository<Offer>, IOfferRepository
    {
        #region Constructors
        public OfferRepository(TravelPlannerContext context)
            : base(context)
        {

        }
        #endregion
    }
}
