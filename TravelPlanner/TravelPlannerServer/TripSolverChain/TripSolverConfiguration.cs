namespace TravelPlannerServer.TripSolverChain
{
    internal static class TripSolverConfiguration
    {
        public static TripSolver GetTripSolver()
        {
            return new TripSolver(new SingleTripSolver(new FamilyTripSolver(new GroupTripSolver())));
        }
    }
}
