using Generated;
using Grpc.Core;
using System.Threading.Tasks;
using TravelPlannerServer.Model.DataAccess;
using TravelPlannerServer.Model.Entity;

namespace TravelPlannerServer.Services
{
    internal sealed class AuthenticationService
        : Generated.AuthenticationService.AuthenticationServiceBase
    {
        public override Task<AuthenticationResponse> Login(LoginRequest request, ServerCallContext context)
        {
            AuthenticationResponse response = UserDataAccessLayer.Login(new User(request.Username, request.Password))
                ? new AuthenticationResponse() { Success = true }
                : new AuthenticationResponse() { Success = false };
            return Task.FromResult(response);
        }

        public override Task<AuthenticationResponse> Register(RegisterRequest request, ServerCallContext context)
        {
            AuthenticationResponse response = UserDataAccessLayer.Register(new User(request.Username, request.Password))
                ? new AuthenticationResponse() { Success = true }
                : new AuthenticationResponse() { Success = false };
            return Task.FromResult(response);
        }
    }
}
