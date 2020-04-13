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
            var client = new GreetingService.GreetingServiceClient(channel);

            var request = new GreetingRequest
            {
                Message = "Hi",
                SenderName = "Gabi"
            };

            Console.WriteLine("Client sending request: ");
            Console.WriteLine($"{request} {System.Environment.NewLine}");

            using (var response = client.GreetAsync(request))
            {
                Console.WriteLine("Client received response: ");
                Console.WriteLine(response.ResponseAsync.Result);
            }


            // Shutdown
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
