using Generated;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using TravelPlannerClient.Utils;

namespace TravelPlannerClient
{
    internal sealed class Program
    {
        static async Task Main(string[] args)
        {
            ServerConnection connection = new ServerConnection(Constants.Host, Constants.Port);
            const string stopMessage = "0";
            using var call = connection.Client.Communicate();
            var responseReaderTask = Task.Run(async () =>
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var response = call.ResponseStream.Current;
                    if (response.Message == "cls")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine(response.Message);
                    }
                }
            });

            string input = "startMenu";
            while (input != stopMessage)
            {
                try
                {
                    await call.RequestStream.WriteAsync(new UserRequest() { Input = input });
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                input = Console.ReadLine();
            }
            try
            {
                await call.RequestStream.CompleteAsync();
                await responseReaderTask;
            }
            catch (Exception)
            {

            }
        }
    }
}
