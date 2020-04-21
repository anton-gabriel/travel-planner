using System;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.TravelState
{
    internal abstract class TripState
    {
        #region Constructors
        public TripState(TripStateChanger tripChanger)
        {
            TripChanger = tripChanger ?? throw new ArgumentNullException(nameof(tripChanger));
        }
        #endregion

        #region Properties
        public TripStateChanger TripChanger { get; private set; }
        #endregion

        #region Public methods
        public abstract bool ChangeNumberOfPersons(uint persons);
        public abstract bool ChangeEndDate(DateTime date);
        public abstract bool Cancel();
        #endregion
    }
}
