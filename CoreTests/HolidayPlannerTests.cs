using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Util;

namespace Core.Tests
{
    [TestClass()]
    public class HolidayPlannerTests
    {
        [TestMethod()]
        public void CalculateHolidaysTest_1()
        {
            DateTime holidayPeriodStart = new DateTime(2021, 4, 1);
            DateTime holidayPeriodEnd = new DateTime(2022, 3, 31);

            List<int> years = new List<int>() { 2021 };
            HolidayPlanner planner = new HolidayPlanner("FI", years, holidayPeriodStart, holidayPeriodEnd);

            DateRangeInput range = new DateRangeInput(new DateTime(2021, 1, 1), new DateTime(2021, 1, 7));
            int holidays = planner.CalculateHolidays(range);
            Assert.AreEqual(4, holidays);
        }

        [TestMethod()]
        public void CalculateHolidaysTest_2()
        {
            DateTime holidayPeriodStart = new DateTime(2021, 4, 1);
            DateTime holidayPeriodEnd = new DateTime(2022, 3, 31);

            List<int> years = new List<int>() { 2021 };
            HolidayPlanner planner = new HolidayPlanner("FI", years, holidayPeriodStart, holidayPeriodEnd);

            DateRangeInput range = new DateRangeInput(new DateTime(2021, 3, 1), new DateTime(2021, 5, 1));
            int holidays = planner.CalculateHolidays(range);
            Assert.AreEqual(-1, holidays);
        }

        [TestMethod()]
        public void IsValidTest_1()
        {
            DateTime holidayPeriodStart = new DateTime(2021, 4, 1);
            DateTime holidayPeriodEnd = new DateTime(2022, 3, 31);

            List<int> years = new List<int>() { 2021 };
            HolidayPlanner planner = new HolidayPlanner("FI", years, holidayPeriodStart, holidayPeriodEnd);

            DateRangeInput range = new DateRangeInput(new DateTime(2021,2, 2), new DateTime(2021, 1, 7));
            Assert.IsFalse(planner.IsValid(range));

        }

        [TestMethod()]
        public void IsValidTest_2()
        {
            DateTime holidayPeriodStart = new DateTime(2021, 4, 1);
            DateTime holidayPeriodEnd = new DateTime(2022, 3, 31);

            List<int> years = new List<int>() { 2021 };
            HolidayPlanner planner = new HolidayPlanner("FI", years, holidayPeriodStart, holidayPeriodEnd);

            DateRangeInput range = new DateRangeInput(new DateTime(2020, 1, 1), new DateTime(2020, 2, 2));
            Assert.IsTrue(planner.IsValid(range));

        }

        [TestMethod()]
        public void IsValidTest_3()
        {
            DateTime holidayPeriodStart = new DateTime(2021, 4, 1);
            DateTime holidayPeriodEnd = new DateTime(2022, 3, 31);

            List<int> years = new List<int>() { 2021 };
            HolidayPlanner planner = new HolidayPlanner("FI", years, holidayPeriodStart, holidayPeriodEnd);

            DateRangeInput range = new DateRangeInput(new DateTime(2010, 1, 1), new DateTime(2021, 1, 7));
            Assert.IsFalse(planner.IsValid(range));

        }

        [TestMethod()]
        public void IsValidTest_4()
        {
            // Note 1.12.2021 - 2.1.2022 is a valid time span for a holiday
            // 1.3.2021 - 1.4.2021 is not a valid time span for a holiday
            DateTime holidayPeriodStart = new DateTime(2021, 4, 1);
            DateTime holidayPeriodEnd = new DateTime(2022, 3, 31);

            List<int> years = new List<int>() { 2021 };
            HolidayPlanner planner = new HolidayPlanner("FI", years, holidayPeriodStart, holidayPeriodEnd);

            DateRangeInput range = new DateRangeInput(new DateTime(2021, 3, 1), new DateTime(2021, 4, 1));
            Assert.IsFalse(planner.IsValid(range));

            DateRangeInput range2 = new DateRangeInput(new DateTime(2021, 12, 1), new DateTime(2022, 1, 2));
            Assert.IsTrue(planner.IsValid(range2));

        }
    }
}