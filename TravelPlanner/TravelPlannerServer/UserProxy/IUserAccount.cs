using Generated;
using Grpc.Core;
using TravelPlannerServer.Model;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.UserProxy
{
    internal interface IUserAccount
    {
        TravelRequest TravelRequest { get; set; }
        bool AddTrip(Trip trip);
        void TravelRequestMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream);
        void FindOffersMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream);
        void TripsMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream);
        public bool SetEndDateAction(string endDate);
        public bool SetNumberOfPersonsAction(string number);
        public bool SetNumberOfRoomsAction(string number);
        public bool SetLocationAction(string location);
        public bool SaveAction();
        public bool ChangeNumberOfPersonsAction(string number);
        public bool ChangeEndDateAction(string endDate);
        public bool CancelAction();
    }
}
