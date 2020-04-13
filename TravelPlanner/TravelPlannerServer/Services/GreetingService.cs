using Generated;
using Grpc.Core;
using System.Threading.Tasks;

namespace TravelPlannerServer.Services
{
    internal sealed class GreetingService : Generated.GreetingService.GreetingServiceBase
    {

        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            //Logger.Info(LoggerMessages.ServiceRequestMessage(service: nameof(Greet), host: context.Host, peer: context.Peer));
            return Task.FromResult(new GreetingResponse() { Message = $"Hello, {request.SenderName}." });
        }
    }
}
