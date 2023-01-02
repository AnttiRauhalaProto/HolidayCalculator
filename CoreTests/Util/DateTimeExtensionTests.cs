using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tests
{
    [TestClass()]
    public class DateTimeExtensionTests
    {
        [TestMethod()]
        public void AllDatesBetweenTest()
        {
            DateTime start = new DateTime(2020, 1, 1);
            DateTime end = new DateTime(2020, 1, 7);

            var list = start.AllDatesBetween(end).ToList();

            Assert.AreEqual(7, list.Count);
            Assert.AreEqual(start, list.First());
            Assert.AreEqual(end, list.Last());
        }
    }
}