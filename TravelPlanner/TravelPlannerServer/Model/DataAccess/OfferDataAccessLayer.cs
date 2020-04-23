using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TravelPlannerServer.Database;
using TravelPlannerServer.Database.UnitOfWork;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Model.DataAccess
{
    internal static class OfferDataAccessLayer
    {
        #region Public methods
        public static void AddOffer(Offer offer)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            unitOfWork.Offers.Add(offer);
            unitOfWork.Complete();
        }
        public static void RemoveOffer(Offer offer)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            unitOfWork.Offers.Remove(offer);
            unitOfWork.Complete();
        }
        public static IEnumerable<Offer> FindOffers(Func<Offer, bool> predicate)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            return unitOfWork.Offers.GetAll().Where(predicate);
        }
        #endregion
    }
}
