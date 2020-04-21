using System;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.TravelState
{
    internal sealed class TripStateChanger
    {
        #region Constructors
        public TripStateChanger(Trip trip)
        {
            Trip = trip ?? throw new ArgumentNullException(nameof(trip));
            DueTripState = new DueTripState(this);
            OngoingTripState = new OngoingTripState(this);
            FinishedTripState = new FinishedTripState(this);
            CurrentState = CheckState;
        }
        #endregion

        #region Properties
        public Trip Trip { get; private set; }
        public TripState CurrentState { get; set; }
        public TripState DueTripState { get; set; }
        public TripState OngoingTripState { get; set; }
        public TripState FinishedTripState { get; set; }
        #endregion

        #region Public methods
        public bool ChangeNumberOfPersons(uint persons)
        {
            CurrentState = CheckState;
            return CurrentState.ChangeNumberOfPersons(persons);
        }
        public bool ChangeEndDate(DateTime date)
        {
            CurrentState = CheckState;
            return CurrentState.ChangeEndDate(date);
        }
        public bool Cancel()
        {
            CurrentState = CheckState;
            return CurrentState.Cancel();
        }
        public void SetState(TripState state)
        {
            CurrentState = state ?? throw new ArgumentNullException(nameof(state));
        }
        public TripState CheckState
        {
            get
            {
                if (DateTime.Now < Trip.StartDate)
                {
                    return DueTripState;
                }
                if (DateTime.Now < Trip.EndDate)
                {
                    return OngoingTripState;
                }
                return FinishedTripState;
            }
        }
        #endregion
    }
}
