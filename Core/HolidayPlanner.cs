using Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class HolidayPlanner
    {
        private DateTime holidayPeriodStart;
        private DateTime holidayPeriodEnd;
        private API.NationalHolidayReader reader;
        private List<NationalHoliday> culturalHolidays;

        /// <summary>
        /// Initialize holiday calculator
        /// </summary>
        /// <param name="countryCode">National holidays based this country.</param>
        /// <param name="years">Initialize only these years </param>
        /// <param name="_holidayPeriodStart">Holiday period begins day</param>
        /// <param name="_holidayPeriodEnd">Holiday period end day</param>
        public HolidayPlanner(string countryCode, List<int> years, DateTime _holidayPeriodStart, DateTime _holidayPeriodEnd)
        {
            this.reader = new API.NationalHolidayReader();
            this.culturalHolidays = new List<NationalHoliday>();
            this.holidayPeriodStart = _holidayPeriodStart;
            this.holidayPeriodEnd = _holidayPeriodEnd;

            //Read natinal holidays from wanted years
            foreach (int year in years)
            {
                this.culturalHolidays.AddRange(this.reader.GetNationalHolidays(countryCode, year));
            }

        }

        /// <summary>
        /// Calculates how many holiday days a person has to use to be able to be on holiday during input period
        /// </summary>
        public int CalculateHolidays(DateRangeInput inputParamter)
        {
            //Validate input
            if(!IsValid(inputParamter))
            {
                return -1;
            }

            int dayCount = 0;
            foreach (DateTime day in inputParamter.StartHoliday.AllDatesBetween(inputParamter.EndHoliday))
            {
                //Sundays do no consume holiday days
                //National holidays do not consume holiday days
                if (day.Date.DayOfWeek != DayOfWeek.Sunday && !culturalHolidays.Any(d => d.Date == day.Date))
                {
                    dayCount = dayCount + 1;
                }
            }

            return dayCount;
        }

        /// <summary>
        /// Validates input
        /// </summary>
        public bool IsValid(DateRangeInput inputParamter)
        {
            //The dates for the time span must be in chronological order
            if (inputParamter.EndHoliday < inputParamter.StartHoliday)
            {
                return false;
            }

            //The maximum length of the time span is 50 days
            if ((inputParamter.EndHoliday - inputParamter.StartHoliday).TotalDays > 50 )
            {
                return false;
            }


            //The whole time span has to be within the same holiday period that begins on the 1st of April and ends on the 31st of March
            if (inputParamter.EndHoliday.Date > this.holidayPeriodEnd.Date)
            {
                return false;
            }

            if (inputParamter.StartHoliday.Date < this.holidayPeriodStart.Date)
            {
                return false;
            }

            return true;
        }
    }
}
