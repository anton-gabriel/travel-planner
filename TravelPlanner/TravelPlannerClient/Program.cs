using Generated;
using System;
using TravelPlannerClient.Utils;

namespace TravelPlannerClient
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            ServerConnection connection = new ServerConnection(Constants.Host, Constants.Port);
            while (true)
            {
                ShowMenu(connection);
            }
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
            var request = new LoginRequest()
            {
                Username = username,
                Password = password
            };

            using (var response = connection.Client.LoginAsync(request))
            {
                if (response.ResponseAsync.Result.Success)
                {
                    Console.WriteLine("Login successful.");
                    //Show travel menu
                }
                else
                {
                    Console.WriteLine("Login failed.");
                }
            }
        }

        private static void Register(ServerConnection connection)
        {
            Console.WriteLine($"Username: ");
            string username = Console.ReadLine();
            Console.WriteLine($"Password: ");
            string password = Console.ReadLine();
            var request = new RegisterRequest()
            {
                Username = username,
                Password = password
            };

            using (var response = connection.Client.RegisterAsync(request))
            {
                if (response.ResponseAsync.Result.Success)
                {
                    Console.WriteLine("Registration successful.");
                    //Show travel menu
                }
                else
                {
                    Console.WriteLine("Registration failed.");
                }
            }
        }
    }
}
