using TravelPlannerServer.Database;
using TravelPlannerServer.Database.UnitOfWork;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Model.DataAccess
{
    internal static class TripDataAccessLayer
    {
        #region Public methods
        public static void AddTrip(Trip trip)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            unitOfWork.Trips.Add(trip);
            unitOfWork.Complete();
        }
        public static void RemoveTrip(Trip trip)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            unitOfWork.Trips.Remove(trip);
            unitOfWork.Complete();
        }
        public static void UpdateTrip(Trip trip)
        {
            using var unitOfWork = new UnitOfWork(new TravelPlannerContext());
            var result = unitOfWork.Trips.Get(trip.Id);
            result.NumberOfPersons = trip.NumberOfPersons;
            result.Offer = trip.Offer;
            unitOfWork.Complete();
        }
        #endregion
    }
}
