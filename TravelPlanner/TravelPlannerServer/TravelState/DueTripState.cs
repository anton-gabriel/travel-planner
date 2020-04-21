using System;
using TravelPlannerServer.TripSolverChain;

namespace TravelPlannerServer.TravelState
{
    internal sealed class DueTripState
         : TripState
    {
        #region Constructors
        public DueTripState(TripStateChanger tripChanger)
            : base(tripChanger)
        {
        }
        #endregion

        #region Overrides
        public override bool Cancel()
        {
            TripChanger.SetState(TripChanger.FinishedTripState);
            return true;
        }

        public override bool ChangeEndDate(DateTime date)
        {
            if (date > TripChanger.Trip.EndDate)
            {
                TripChanger.Trip.EndDate = date;
                return true;
            }
            return false;
        }

        public override bool ChangeNumberOfPersons(uint persons)
        {
            if (persons > TripChanger.Trip.NumberOfPersons)
            {
                var solver = TripSolverConfiguration.GetTripSolver();
                TripChanger.Trip.Price = solver.GetTripPrice(persons, TripChanger.Trip.Offer);
                TripChanger.Trip.NumberOfPersons = persons;
            }
            return true;
        }
        #endregion
    }
}
