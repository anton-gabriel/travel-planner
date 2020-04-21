using System;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.TravelState
{
    internal sealed class OngoingTripState
         : TripState
    {
        #region Constructors
        public OngoingTripState(TripStateChanger tripChanger)
            : base(tripChanger)
        {

        }
        #endregion

        #region Overrides
        public override bool Cancel()
        {
            return false;
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
            return false;
        }
        #endregion
    }
}
