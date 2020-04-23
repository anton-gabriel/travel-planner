using System;
using System.Collections.Generic;
using System.Text;
using TravelPlannerServer.Model;

namespace TravelPlannerServer.Services
{
    class GeneralFunctionality
    {
        public static TravelRequest TravelRequest { get; set; }

        public static bool ConvertToDateTime(in string data, out DateTime result)
        {
            result = default;
            try
            {
                result = DateTime.Parse(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
