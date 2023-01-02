using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.API.Tests
{
    [TestClass()]
    public class NationalHolidayReaderTests
    {
        [TestMethod()]
        public void GetNationalHolidaysTest()
        {
            NationalHolidayReader nationalHolidayReader = new NationalHolidayReader();
            var holidays = nationalHolidayReader.GetNationalHolidays("FI", 2021); 

            Assert.AreEqual(15, holidays.Count);
        }
    }
}