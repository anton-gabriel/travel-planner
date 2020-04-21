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
        public override double Discount => 0;
        public override uint NumberOfPersons => 1;
        #endregion
    }
}
