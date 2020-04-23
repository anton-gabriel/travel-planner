using Generated;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TravelPlannerServer.Model;
using TravelPlannerServer.Model.Entity;
using TravelPlannerServer.Services;
using TravelPlannerServer.Utils.Enums;
using static TravelPlannerServer.Model.TravelRequest;

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
            if (GeneralFunctionality.ConvertToDateTime(in startDate, out DateTime startDateFormated))
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
            if (GeneralFunctionality.ConvertToDateTime(in endDate, out DateTime endDateFormated))
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
            GeneralFunctionality.TravelRequest = TravelRequestBuilder.Build();
            return true;
        }

        public async void FindOffersMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await responseStream.WriteAsync(new Response()
            {
                Message =
                "1.Make travel request" + "\n" +
                "0.Exit"
            });
        }

        public async void TripsMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await responseStream.WriteAsync(new Response()
            {
                Message =
                "1.Make travel request" + "\n" +
                "0.Exit"
            });
        }
        #endregion
    }
}
