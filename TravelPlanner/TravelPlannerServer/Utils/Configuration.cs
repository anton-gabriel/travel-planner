using TravelPlannerServer.Model;
using TravelPlannerServer.Utils.Constants;
using TravelPlannerServer.Utils.Readers;

namespace TravelPlannerServer.Utils
{
    internal sealed class Configuration
    {
        #region Constructors
        public Configuration()
        {
            Settings = LoadServerData();
            ConfigLogger();
        }
        #endregion

        #region Private fields

        #region Singleton fields
        private static Configuration instance = null;
        private static readonly object padlock = new object();
        #endregion

        #endregion

        #region Properties

        #region Singleton properties
        public static Configuration Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Configuration();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public Settings Settings { get; private set; }
        #endregion

        #region Private methods
        private Settings LoadServerData()
        {
            return JsonReader<Settings>.TryReadObject(Paths.ConfigFile);
        }

        private void ConfigLogger()
        {

        }
        #endregion
    }
}
