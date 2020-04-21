using System.Collections.Generic;
using TravelPlannerServer.AuthenticationObservable;

namespace TravelPlannerServer.Command
{
    internal sealed class AuthenticationInvoker
    {
        #region Constructors
        public AuthenticationInvoker()
        {
            Listeners = new List<IAuthenticationObservable>();
        }
        #endregion

        #region Listeners
        public List<IAuthenticationObservable> Listeners { get; private set; }
        #endregion

        #region Public methods
        public bool Authenticate(ICommand command)
        {
            if (command is null)
            {
                throw new System.ArgumentNullException(nameof(command));
            }
            bool result = command.Execute();
            Listeners.ForEach(listener => listener.Update(result));
            return result;
        }
        #endregion
    }
}
