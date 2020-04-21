using TravelPlannerServer.AuthenticationObservable;
using TravelPlannerServer.Model.Entity;

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
        #endregion

        #region IUserAccount
        public bool AddTrip(Trip trip)
        {
            return Activated ? UserAccount.AddTrip(trip) : false;
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
