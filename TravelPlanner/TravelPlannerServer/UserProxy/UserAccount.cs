using System;
using System.Collections.Generic;
using System.Text;
using TravelPlannerServer.Model.Entity;

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

        #endregion

        #region Public methods
        public bool AddTrip(Trip trip)
        {
            return false;
        }
        #endregion
    }
}
