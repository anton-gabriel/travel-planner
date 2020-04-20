using Generated;
using Grpc.Core;
using System.Threading.Tasks;
using TravelPlannerServer.Command;
using TravelPlannerServer.Model.DataAccess;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Services
{
    internal sealed class AuthenticationService
        : Generated.AuthenticationService.AuthenticationServiceBase
    {
        public override Task<AuthenticationResponse> Login(LoginRequest request, ServerCallContext context)
        {
            User user = new User(request.Username, request.Password);
            AuthenticationInvoker invoker = new AuthenticationInvoker(new LoginCommand(user));
            AuthenticationResponse response = invoker.Authenticate()
                ? new AuthenticationResponse() { Success = true }
                : new AuthenticationResponse() { Success = false };
            return Task.FromResult(response);
        }

        public override Task<AuthenticationResponse> Register(RegisterRequest request, ServerCallContext context)
        {
            User user = new User(request.Username, request.Password);
            AuthenticationInvoker invoker = new AuthenticationInvoker(new RegisterCommand(user));
            AuthenticationResponse response = invoker.Authenticate()
                ? new AuthenticationResponse() { Success = true }
                : new AuthenticationResponse() { Success = false };
            return Task.FromResult(response);
        }
    }
}
