using Newtonsoft.Json;
using System.IO;

namespace TravelPlannerServer.Utils.Readers
{
    internal static class JsonReader<T>
        where T : class
    {
        #region Public methods
        public static T ReadObject(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
        public static T TryReadObject(string file)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
            }
            catch
            {
                return default;
            }
        }
        #endregion
    }
}
