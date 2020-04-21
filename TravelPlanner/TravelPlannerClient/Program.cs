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
            const string stopMessage = "stop";
            using var call = connection.Client.Communicate();
            var responseReaderTask = Task.Run(async () =>
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var response = call.ResponseStream.Current;
                    Console.WriteLine("Received: " + response);
                }
            });

            string input = Console.ReadLine();
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
            await call.RequestStream.CompleteAsync();
            await responseReaderTask;
        }

        private static void ShowMenu(ServerConnection connection)
        {
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");
            Console.WriteLine("0.Exit");

            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Login(connection);
                        break;
                    case 2:
                        Register(connection);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Comandă invalidă");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void Login(ServerConnection connection)
        {
            Console.WriteLine($"Username: ");
            string username = Console.ReadLine();
            Console.WriteLine($"Password: ");
            string password = Console.ReadLine();
        }

        private static void Register(ServerConnection connection)
        {
            Console.WriteLine($"Username: ");
            string username = Console.ReadLine();
            Console.WriteLine($"Password: ");
            string password = Console.ReadLine();
        }
    }
}
