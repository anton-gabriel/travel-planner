using Newtonsoft.Json;

namespace TravelPlannerServer.Model
{
    internal sealed class ServerData
    {
        #region Constructors
        public ServerData(string host, int port)
        {
            Host = host;
            Port = port;
        }
        #endregion

        #region Properties
        [JsonProperty]
        public string Host { get; set; }
        [JsonProperty]
        public int Port { get; set; }
        #endregion
    }
}
