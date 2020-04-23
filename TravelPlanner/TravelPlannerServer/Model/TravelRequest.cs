using System;
using TravelPlannerServer.Utils.Enums;

namespace TravelPlannerServer.Model
{
    internal sealed class TravelRequest
    {
        #region Constructors
        public TravelRequest(DateTime startDate)
        {
            StartDate = startDate;
        }
        #endregion

        #region Properties
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public TravelLocationType LocationType { get; private set; }
        public uint NumberOfPersons { get; private set; }
        public uint NumberOfRooms { get; private set; }
        #endregion

        #region Builder
        internal sealed class TravelRequestBuilder
        {
            #region Constructors
            public TravelRequestBuilder(DateTime startDate)
            {
                TravelRequest = new TravelRequest(startDate);
            }
            #endregion

            #region Properties
            private TravelRequest TravelRequest { get; set; }
            #endregion

            #region Builder
            public TravelRequestBuilder AddEndDate(DateTime date)
            {
                TravelRequest.EndDate = date;
                return this;
            }
            public TravelRequestBuilder AddNumberOfPersons(uint persons)
            {
                TravelRequest.NumberOfPersons = persons;
                return this;
            }
            public TravelRequestBuilder AddNumberOfRooms(uint rooms)
            {
                TravelRequest.NumberOfRooms = rooms;
                return this;
            }
            public TravelRequestBuilder AddLocation(TravelLocationType locationType)
            {
                TravelRequest.LocationType = locationType;
                return this;
            }
            public TravelRequest Build()
            {
                return TravelRequest;
            }
            #endregion
        }
        #endregion
    }
}
