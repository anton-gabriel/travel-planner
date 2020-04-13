using TravelPlannerServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelPlannerServer
{
    internal sealed class Server
        : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Creates a new server. Should be called in using block
        /// </summary>
        /// <param name="host">The host of the server.</param>
        /// <param name="port">The port on which server should listen.</param>
        public Server(string host, int port)
        {
            GrpcServer = new Grpc.Core.Server()
            {
                Ports = { new Grpc.Core.ServerPort(host, port, Grpc.Core.ServerCredentials.Insecure) }
            };
            LoadServices();
        }
        /// <summary>
        /// Creates a new server.
        /// </summary>
        /// <param name="serverData">Contains host and port data in one object.</param>
        public Server(ServerData serverData) 
            : this(host: serverData.Host, port: serverData.Port)
        {

        }
        #endregion

        #region Properties
        public Grpc.Core.Server GrpcServer { get; private set; }
        public IEnumerable<Grpc.Core.ServerServiceDefinition> Services
        {
            get
            {
                yield return Generated.GreetingService.BindService(new Services.GreetingService());
            }
        }

        /// <summary>
        /// The action after that the server will shut down.
        /// </summary>
        public Action CloseServerAction { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Starts the server.
        /// </summary>
        public void Start()
        {
            GrpcServer.Start();
            var port = GrpcServer.Ports.FirstOrDefault();
            //Logger.Info(LoggerMessages.ServerStartedMessage(port.Host, port.Port));
        }
        #endregion

        #region Logger
        //private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
        #endregion

        #region Private methods
        private void LoadServices()
        {
            Services.ToList().ForEach(service => GrpcServer.Services.Add(service));
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            CloseServerAction.Invoke();
            GrpcServer.ShutdownAsync().Wait();
            var port = GrpcServer.Ports.FirstOrDefault();
            //Logger.Info(message: LoggerMessages.ServerClosedMessage(port.Host, port.Port));
        }
        #endregion
    }
}
