using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Util;

namespace Core.API
{
    public class NationalHolidayReader
    {
       public List<NationalHoliday> GetNationalHolidays(string countryCode, int year)
       {
            string url = "https://date.nager.at/PublicHoliday/Country/" + countryCode + "/" + year + "/CSV";

            List<NationalHoliday> holidays = new List<NationalHoliday>();
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream))
                {
                    //Read header line
                    string headerLine = reader.ReadLine();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                       
                        //Format 2021-12-01
                        var date = DateTime.ParseExact(parts[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        var localName = parts[1];

                        NationalHoliday holiday = new NationalHoliday(date, localName);

                        holidays.Add(holiday);
                    }
                }
            }

            return holidays;
        }
    }
}
