using System;
using TravelPlannerServer.Database.Repository;

namespace TravelPlannerServer.Database.UnitOfWork
{
    internal sealed class UnitOfWork
        : IUnitOfWork
    {
        #region Constructors
        public UnitOfWork(TravelPlannerContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            Users = new UserRepository(context);
            Offers = new OfferRepository(context);
            Trips = new TripRepository(context);
        }
        #endregion

        #region Private fields
        private readonly TravelPlannerContext context;
        #endregion

        #region Properties
        public IUserRepository Users { get; private set; }
        public IOfferRepository Offers { get; private set; }
        public ITripRepository Trips { get; private set; }
        #endregion

        #region IUnitOfWork
        public int Complete()
        {
            return this.context.SaveChanges();
        }
        public void Dispose()
        {
            this.context.Dispose();
        }
        #endregion
    }
}
