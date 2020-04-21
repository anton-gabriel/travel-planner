namespace TravelPlannerServer.TripSolverChain
{
    internal sealed class SingleTripSolver
        : TripSolver
    {
        #region Cosntructors
        public SingleTripSolver(TripSolver parent)
            : base(parent)
        {
        }
        #endregion

        #region Overrides
        protected override double Discount => 0;
        protected override uint NumberOfPersons => 1;
        #endregion
    }
}
