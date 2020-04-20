using TravelPlannerServer.Logger;
using TravelPlannerServer.Model.DataAccess;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Command
{
    internal sealed class RegisterCommand
        : ICommand
    {
        #region Constructors
        public RegisterCommand(User user)
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
            logger.Info($"Register was attempted by {User}.");
            if (UserDataAccessLayer.Register(User))
            {
                logger.Info($"Successful register for {User}.");
                return true;
            }
            logger.Info($"Failed register for {User}.");
            return false;
        }
        #endregion
    }
}
