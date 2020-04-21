using Generated;
using Grpc.Core;
using System.Threading.Tasks;
using TravelPlannerServer.Command;
using TravelPlannerServer.Model.Entity;
using TravelPlannerServer.UserProxy;

namespace TravelPlannerServer.Services
{
    internal sealed class CommunicationService
        : Generated.CommunicationService.CommunicationServiceBase
    {
        #region Constructors
        public CommunicationService()
        {
            AuthenticationInvoker.Listeners.Add(UserAccount);
            //exemplu logare

            if (AuthenticationInvoker.Authenticate(new LoginCommand(new User("test", "test"))))
            {
                ///
            }
            if (AuthenticationInvoker.Authenticate(new RegisterCommand(new User("test", "test"))))
            {
                ///
            }
        }
        #endregion

        #region Properties
        private AuthenticationInvoker AuthenticationInvoker { get; set; } = new AuthenticationInvoker();
        private UserAccountProxy UserAccount { get; set; } = new UserAccountProxy();
        #endregion

        #region Overrides
        public override async Task Communicate(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var request = requestStream.Current;

                await responseStream.WriteAsync(new Response()
                {
                    Message = $"Received: {request.Input}"
                });
            }
        }
        #endregion
    }
}
