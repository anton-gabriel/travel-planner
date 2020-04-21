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
        public override double Discount => 10;
        public override uint NumberOfPersons => 5;
        #endregion
    }
}
