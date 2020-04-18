using Generated;
using Grpc.Core;
using System;

namespace TravelPlannerClient
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            const string Host = "localhost";
            const int Port = 50051;

            var channel = new Channel($"{Host}:{Port}", ChannelCredentials.Insecure);
            var client = new AuthenticationService.AuthenticationServiceClient(channel);

            var request = new LoginRequest
            {
                Username = "Gabi",
                Password = "12345"
            };

            Console.WriteLine("Client sending request: ");
            Console.WriteLine($"{request} {Environment.NewLine}");

            using (var response = client.LoginAsync(request))
            {
                Console.WriteLine("Client received response: ");
                Console.WriteLine(response.ResponseAsync.Result.Id);
            }


            // Shutdown
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
