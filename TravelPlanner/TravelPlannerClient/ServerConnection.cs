using Generated;
using Grpc.Core;
using System;

namespace TravelPlannerClient
{
    internal sealed class ServerConnection
        : IDisposable
    {
        #region Constructors
        public ServerConnection(string host, int port)
        {
            Channel = new Channel($"{host}:{port}", ChannelCredentials.Insecure);
            Client = new AuthenticationService.AuthenticationServiceClient(Channel);
        }
        #endregion

        #region Properties
        public Channel Channel { get; private set; }
        public AuthenticationService.AuthenticationServiceClient Client;

        #endregion

        #region IDisposable
        public void Dispose()
        {
            Channel.ShutdownAsync().Wait();
        }
        #endregion
    }
}
