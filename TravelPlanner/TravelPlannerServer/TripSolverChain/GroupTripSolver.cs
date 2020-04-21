namespace TravelPlannerServer.TripSolverChain
{
    internal sealed class GroupTripSolver
        : TripSolver
    {
        #region Cosntructors
        public GroupTripSolver()
            : base(null)
        {

        }
        #endregion

        #region Overrides
        public override double Discount => 15;
        public override uint NumberOfPersons => 15;
        #endregion
    }
}
