namespace TravelPlannerServer.Command
{
    internal sealed class AuthenticationInvoker
    {
        #region Constructors
        public AuthenticationInvoker(ICommand command)
        {
            Command = command ?? throw new System.ArgumentNullException(nameof(command));
        }
        #endregion

        #region Properties
        private ICommand Command { get; set; }
        #endregion

        #region Public methods
        public bool Authenticate()
        {
            return Command.Execute();
        }
        #endregion
    }
}
