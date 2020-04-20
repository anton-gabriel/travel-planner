using TravelPlannerServer.Logger;
using TravelPlannerServer.Model.DataAccess;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Command
{
    internal sealed class LoginCommand
        : ICommand
    {
        #region Constructors
        public LoginCommand(User user)
        {
            User = user;
        }
        #endregion

        #region Properties
        private User User { get; set; }
        #endregion

        #region ICommand
        public bool Execute()
        {
            var logger = TravelPlannerLogger.Instance;
            logger.Info($"Login was attempted by {User}");
            if (UserDataAccessLayer.Login(User))
            {
                logger.Info($"Successful login for {User}");
                return true;
            }
            logger.Info($"Failed login for {User}.");
            return false;
        }
        #endregion
    }
}
