using Newtonsoft.Json;

namespace TravelPlannerServer.Model
{
    internal sealed class Settings
    {
        #region Constructors
        public Settings(ServerData serverData, string loggingFile)
        {
            ServerData = serverData;
            LoggingFile = loggingFile;
        }
        #endregion

        #region Properties
        [JsonProperty]
        public ServerData ServerData { get; private set; }
        [JsonProperty]
        public string LoggingFile { get; private set; }
        #endregion
    }
}
