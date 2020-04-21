using System;

namespace TravelPlannerServer.TravelState
{
    internal sealed class FinishedTripState
         : TripState
    {
        #region Constructors
        public FinishedTripState(TripStateChanger tripChanger)
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
            return false;
        }

        public override bool ChangeNumberOfPersons(uint persons)
        {
            return false;
        }
        #endregion
    }
}
