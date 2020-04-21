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
        protected override double Discount => 15;
        protected override uint NumberOfPersons => 15;
        #endregion
    }
}
