using System;

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
        public string Location { get; private set; }
        public uint NumberOfDays { get; private set; }
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
            public TravelRequestBuilder AddAddEndDate(DateTime date)
            {
                TravelRequest.EndDate = date;
                return this;
            }
            public TravelRequestBuilder AddNumberOfDays(uint days)
            {
                TravelRequest.NumberOfDays = days;
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
            public TravelRequestBuilder AddLocation(string location)
            {
                TravelRequest.Location = location;
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
