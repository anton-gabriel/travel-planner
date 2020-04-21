namespace TravelPlannerServer.TripSolverChain
{
    internal sealed class FamilyTripSolver
        : TripSolver
    {
        #region Cosntructors
        public FamilyTripSolver(TripSolver parent)
            : base(parent)
        {
        }
        #endregion

        #region Overrides
        protected override double Discount => 10;
        protected override uint NumberOfPersons => 5;
        #endregion
    }
}
