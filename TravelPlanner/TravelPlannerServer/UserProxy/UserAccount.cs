using Generated;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TravelPlannerServer.Model;
using TravelPlannerServer.Model.DataAccess;
using TravelPlannerServer.Model.Entity;
using TravelPlannerServer.Services;
using TravelPlannerServer.TravelState;
using TravelPlannerServer.Utils.Enums;
using static TravelPlannerServer.Model.TravelRequest;
using System.Linq;
using TravelPlannerServer.TripSolverChain;

namespace TravelPlannerServer.UserProxy
{
    internal sealed class UserAccount
        : IUserAccount
    {
        #region Constructors
        public UserAccount()
        {
        }
        #endregion

        #region Properties
        private TravelRequestBuilder TravelRequestBuilder { get; set; }
        public TravelRequest TravelRequest { get; set; }
        private TripStateChanger TripStateChanger { get; set; }
        public string Username { get; set; }
        #endregion

        #region Public methods
        public bool AddTrip(Trip trip)
        {
            return false;
        }

        public async void TravelRequestMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await responseStream.WriteAsync(new Response()
            {
                Message =
                "1.Set end date" + "\n" +
                "2.Set number of persons" + "\n" +
                "3.Set number of rooms" + "\n" +
                "4.Set location" + "\n" +
                "5.Save" + "\n" +
                "0.Exit"
            });
        }

        public bool SetStartDateAction(string startDate)
        {
            if (ConvertToDateTime(in startDate, out DateTime startDateFormated))
            {
                TravelRequestBuilder = new TravelRequestBuilder(startDateFormated);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetEndDateAction(string endDate)
        {
            if (ConvertToDateTime(in endDate, out DateTime endDateFormated))
            {
                TravelRequestBuilder = TravelRequestBuilder.AddEndDate(endDateFormated);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetNumberOfPersonsAction(string number)
        {
            TravelRequestBuilder = TravelRequestBuilder.AddNumberOfPersons(Convert.ToUInt32(number));
            return true;
        }

        public bool SetNumberOfRoomsAction(string number)
        {
            TravelRequestBuilder = TravelRequestBuilder.AddNumberOfRooms(Convert.ToUInt32(number));
            return true;
        }

        public bool SetLocationAction(string location)
        {
            TravelRequestBuilder = TravelRequestBuilder.AddLocation(Enum.Parse<TravelLocationType>(location));
            return true;
        }

        public bool SaveAction()
        {
            TravelRequest = TravelRequestBuilder.Build();
            return true;
        }

        public bool GetTripAction(Offer offer)
        {
            TripSolver tripSolver = TripSolverConfiguration.GetTripSolver();
            tripSolver.GetTripPrice(TravelRequest.NumberOfPersons, offer);
            UserDataAccessLayer.AddTrip(UserDataAccessLayer.GetUser(Username).Id, new Trip(offer, TravelRequest.StartDate));
            return true;
        }

        public async void TripsMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await responseStream.WriteAsync(new Response()
            {
                Message =
                "1.Edit travel" + "\n" +
                "2.Back" + "\n" +
                "0.Exit"
            });
        }

        public bool ChangeNumberOfPersonsAction(string input)
        {
            return TripStateChanger.ChangeNumberOfPersons(Convert.ToUInt32(input));
        }

        public bool ChangeEndDateAction(string input)
        {
            if (ConvertToDateTime(in input, out DateTime endDateFormated))
            {
                return TripStateChanger.ChangeEndDate(endDateFormated); ;
            }
            else
            {
                return false;
            }
        }

        public bool CancelAction()
        {
            return TripStateChanger.Cancel(); ;
        }

        public static bool ConvertToDateTime(in string data, out DateTime result)
        {
            result = default;
            try
            {
                result = DateTime.Parse(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
