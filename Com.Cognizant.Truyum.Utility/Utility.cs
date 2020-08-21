using System;

namespace Com.Cognizant.Truyum.Utility
{
    public class Utility
    {
        public static DateTime ConvertToDate(string inputDate)
        {
            return DateTime.ParseExact(inputDate, "dd / MM / yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string ConvertToString(DateTime dateTime)
        {
            return dateTime.ToString("dd-MM-yyyy");
        }
    }
}
