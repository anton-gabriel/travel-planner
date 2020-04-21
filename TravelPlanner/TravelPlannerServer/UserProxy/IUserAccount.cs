using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.UserProxy
{
    internal interface IUserAccount
    {
        bool AddTrip(Trip trip);
    }
}
