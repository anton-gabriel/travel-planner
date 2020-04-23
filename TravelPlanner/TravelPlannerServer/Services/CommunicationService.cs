using Generated;
using Grpc.Core;
using System.Threading.Tasks;
using TravelPlannerServer.Command;
using TravelPlannerServer.Logger;
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
        }
        #endregion

        #region Properties
        private AuthenticationInvoker AuthenticationInvoker { get; set; } = new AuthenticationInvoker();
        private UserAccountProxy UserAccount { get; set; } = new UserAccountProxy();
        private TravelPlannerLogger Logger => TravelPlannerLogger.Instance;
        private string State { get; set; } = "";
        
        #endregion

        #region Overrides
        public override async Task Communicate(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream, ServerCallContext context)
        {
            while (true)
            {
                await requestStream.MoveNext();
                var request = requestStream.Current;
                if (State == "startState")
                {
                    switch (request.Input)
                    {
                        case "1":
                            await LoginAction(requestStream, responseStream);
                            break;
                        case "2":
                            await RegisterAction(requestStream, responseStream);
                            break;
                        default:
                            await InvalidAction(requestStream, responseStream);
                            break;
                    }
                }
                else if (State == "mainState")
                {
                    switch (request.Input)
                    {
                        case "1":
                            await TravelRequestMenu(requestStream, responseStream);
                            break;
                        case "2":
                            await FindOffersMenu(requestStream, responseStream);
                            break;
                        case "3":
                            await TripsMenu(requestStream, responseStream);
                            break;
                        default:
                            await InvalidAction(requestStream, responseStream);
                            break;
                    }
                }
                else if (State == "travelRequestState")
                {
                    switch (request.Input)
                    {
                        case "1":
                            await SetEndDateAction(requestStream, responseStream);
                            break;
                        case "2":
                            await SetNumberOfPersonsAction(requestStream, responseStream);
                            break;
                        case "3":
                            await SetNumberOfRoomsAction(requestStream, responseStream);
                            break;
                        case "4":
                            await SetLocationAction(requestStream, responseStream);
                            break;
                        case "5":
                            await SaveAction(requestStream, responseStream);
                            break;
                        default:
                            await InvalidAction(requestStream, responseStream);
                            break;
                    }
                }
                else
                {
                    switch (request.Input)
                    {
                        case "startMenu":
                            await StartMenu(requestStream, responseStream);
                            break;
                        default:
                            await InvalidAction(requestStream, responseStream);
                            break;
                    }
                }
            }
        }
        #endregion

        #region Private methods

        private async Task InvalidAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            await responseStream.WriteAsync(new Response()
            {
                Message = "Invalid action" + "\n" +
                    "Press Enter key to continue.\n"
            });
            await requestStream.MoveNext();
        }

        private async Task SetStartDateAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            await responseStream.WriteAsync(new Response()
            {
                Message = "Please enter the start date of the travel (MMM dd, yyyy)"
            });
            await requestStream.MoveNext();
            string input = requestStream.Current.Input;
            if(UserAccount.SetStartDateAction(input))
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Successful" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            else
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Failed" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            await requestStream.MoveNext();
        }

        private async Task SetEndDateAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            await responseStream.WriteAsync(new Response()
            {
                Message = "Please enter the end date of the travel (M dd, yyyy)"
            });
            await requestStream.MoveNext();
            string input = requestStream.Current.Input;
            if (UserAccount.SetEndDateAction(input))
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Successful" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            else
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Failed" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            await requestStream.MoveNext();
            await TravelRequestMenu(requestStream, responseStream);
        }

        private async Task SetNumberOfPersonsAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            await responseStream.WriteAsync(new Response()
            {
                Message = "Please enter the number of persons of the travel"
            });
            await requestStream.MoveNext();
            string input = requestStream.Current.Input;
            if (UserAccount.SetNumberOfPersonsAction(input))
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Successful" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            else
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Failed" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            await requestStream.MoveNext();
            await TravelRequestMenu(requestStream, responseStream);
        }

        private async Task SetNumberOfRoomsAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            await responseStream.WriteAsync(new Response()
            {
                Message = "Please enter the number of rooms of the travel"
            });
            await requestStream.MoveNext();
            string input = requestStream.Current.Input;
            if (UserAccount.SetNumberOfRoomsAction(input))
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Successful" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            else
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Failed" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            await requestStream.MoveNext();
            await TravelRequestMenu(requestStream, responseStream);
        }

        private async Task SaveAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            if (UserAccount.SaveAction())
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Successful" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            else
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Failed" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            await requestStream.MoveNext();
            await MainMenu(requestStream, responseStream);
        }

        private async Task SetLocationAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            await responseStream.WriteAsync(new Response()
            {
                Message = "Please enter the location of the travel"
            });
            await requestStream.MoveNext();
            string input = requestStream.Current.Input;
            if (UserAccount.SetLocationAction(input))
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Successful" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            else
            {
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Failed" + "\n" +
                    "Press Enter key to continue.\n"
                });
            }
            await requestStream.MoveNext();
            await TravelRequestMenu(requestStream, responseStream);
        }

        private async Task StartMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            await responseStream.WriteAsync(new Response()
            {
                Message =
                "1.Login" + "\n" +
                "2.Register" + "\n" +
                "0.Exit"
            });
            State = "startState";
        }

        private async Task MainMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            await responseStream.WriteAsync(new Response()
            {
                Message =
                "1.Make travel request" + "\n" +
                "2.Find offers" + "\n" +
                "3.Show my trips" + "\n" +
                "0.Exit"
            });
            State = "mainState";
        }

        private async Task TravelRequestMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await SetStartDateAction(requestStream, responseStream);
            await ClearScreen(requestStream, responseStream);
            UserAccount.TravelRequestMenu(requestStream, responseStream);
            State = "travelRequestState";
            
        }

        private async Task FindOffersMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            UserAccount.FindOffersMenu(requestStream, responseStream);
            State = "findOffersState";
        }

        private async Task TripsMenu(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await ClearScreen(requestStream, responseStream);
            UserAccount.TripsMenu(requestStream, responseStream);
            State = "tripsState";
        }

        private async Task ClearScreen(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await responseStream.WriteAsync(new Response()
            {
                Message = "cls"
            });
        }

        private async Task LoginAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await responseStream.WriteAsync(new Response()
            {
                Message = "Please input username:"
            });
            await requestStream.MoveNext();
            string username = requestStream.Current.Input;

            await responseStream.WriteAsync(new Response()
            {
                Message = "Please input password:"
            });
            await requestStream.MoveNext();
            string password = requestStream.Current.Input;

            if (AuthenticationInvoker.Authenticate(new LoginCommand(new User(username, password))))
            {
                Logger.Info("Loggin successful");
                await MainMenu(requestStream, responseStream);
            }
            else
            {
                Logger.Info("Loggin failed");
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Loggin failed" + "\n" +
                    "Press Enter key to continue.\n"
                });
                await requestStream.MoveNext();
                await StartMenu(requestStream, responseStream);
            }
        }

        private async Task RegisterAction(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<Response> responseStream)
        {
            await responseStream.WriteAsync(new Response()
            {
                Message = "Please input username:"
            });
            await requestStream.MoveNext();
            string username = requestStream.Current.Input;

            await responseStream.WriteAsync(new Response()
            {
                Message = "Please input password:"
            });
            await requestStream.MoveNext();
            string password = requestStream.Current.Input;

            if (AuthenticationInvoker.Authenticate(new RegisterCommand(new User(username, password))))
            {
                Logger.Info("Register successful");
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Register successful" + "\n" +
                    "Press Enter key to continue.\n"
                });
                await requestStream.MoveNext();
                await StartMenu(requestStream, responseStream);
            }
            else
            {
                Logger.Info("Register failed");
                await responseStream.WriteAsync(new Response()
                {
                    Message = "Register failed" + "\n" +
                    "Press Enter key to continue.\n"
                });
                await requestStream.MoveNext();
                await StartMenu(requestStream, responseStream);
            }
        }
        #endregion
    }
}
