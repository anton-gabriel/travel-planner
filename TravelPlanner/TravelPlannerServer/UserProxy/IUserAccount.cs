using Generated;
using Grpc.Core;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.UserProxy
{
    internal interface IUserAccount
    {
        bool AddTrip(Trip trip);
        void TravelRequestMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream);
        void FindOffersMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream);
        void TripsMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream);
        public bool SetStartDateAction(string startDate);
        public bool SetEndDateAction(string endDate);
        public bool SetNumberOfPersonsAction(string number);
        public bool SetNumberOfRoomsAction(string number);
        public bool SetLocationAction(string location);
        public bool SaveAction();

    }
}
