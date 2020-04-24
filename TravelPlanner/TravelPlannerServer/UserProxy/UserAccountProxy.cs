using Generated;
using Grpc.Core;
using System;
using TravelPlannerServer.AuthenticationObservable;
using TravelPlannerServer.Model;
using TravelPlannerServer.Model.Entity;
using TravelPlannerServer.TravelState;

namespace TravelPlannerServer.UserProxy
{
    internal sealed class UserAccountProxy
        : IUserAccount, IAuthenticationObservable
    {
        #region Constructors
        public UserAccountProxy()
        {
            UserAccount = new UserAccount();
        }
        #endregion

        #region Properties
        private IUserAccount UserAccount { get; set; }
        private bool Activated { get; set; }
        public TravelRequest TravelRequest
        {
            get => Activated ? UserAccount.TravelRequest : null;

            set
            {
                if (Activated)
                {
                    UserAccount.TravelRequest = value;
                }
            }
        }

        public string Username
        {
            get => Activated ? UserAccount.Username : null;

            set
            {
                if (Activated)
                {
                    UserAccount.Username = value;
                }
            }
        }

        public TripStateChanger TripStateChanger
        {
            get => Activated ? UserAccount.TripStateChanger : null;

            set
            {
                if (Activated)
                {
                    UserAccount.TripStateChanger = value;
                }
            }
        }
        #endregion

        #region IUserAccount
        public bool AddTrip(Trip trip)
        {
            return Activated ? UserAccount.AddTrip(trip) : false;
        }

        public bool GetTripAction(Offer offer)
        {
            return Activated ? UserAccount.GetTripAction(offer) : false;
        }

        public bool SaveAction()
        {
            return Activated ? UserAccount.SaveAction() : false;
        }

        public bool SetEndDateAction(string endDate)
        {
            return Activated ? UserAccount.SetEndDateAction(endDate) : false;
        }

        public bool SetLocationAction(string location)
        {
            return Activated ? UserAccount.SetLocationAction(location) : false;
        }

        public bool SetNumberOfPersonsAction(string number)
        {
            return Activated ? UserAccount.SetNumberOfPersonsAction(number) : false;
        }

        public bool SetNumberOfRoomsAction(string number)
        {
            return Activated ? UserAccount.SetNumberOfRoomsAction(number) : false;
        }

        public bool SetStartDateAction(string startDate)
        {
            return Activated ? UserAccount.SetStartDateAction(startDate) : false;
        }

        public void TravelRequestMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            if (Activated)
            {
                UserAccount.TravelRequestMenu(requestStream, responseStream);
            }
        }

        public void TripsMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            if (Activated)
            {
                UserAccount.TripsMenu(requestStream, responseStream);
            }
        }

        public bool ChangeNumberOfPersonsAction(string number)
        {
            return Activated ? UserAccount.ChangeNumberOfPersonsAction(number) : false;
        }

        public bool ChangeEndDateAction(string endDate)
        {
            return Activated ? UserAccount.ChangeEndDateAction(endDate) : false;
        }
        public bool UpdateAction()
        {
            return Activated ? UserAccount.UpdateAction() : false;
        }
        public bool CancelAction()
        {
            return Activated ? UserAccount.CancelAction() : false;
        }
        #endregion

        #region IAuthenticationObservable
        public void Update(bool authenticated)
        {
            Activated = authenticated;
        }
        #endregion
    }
}
