using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CompanyCoreLib.Tests
{
    [TestClass]
    public class AnalyticsTest
    {
        static Analytics AnalyticsClass = null;

        [ClassInitialize]
        static public void Init(TestContext tc)
        {
            AnalyticsClass = new Analytics();
        }

        [TestMethod]
        public void PopularMonths_Await3ItemsWithSortByDate()
        {
            List<DateTime> dates = new List<DateTime>() {
                new DateTime(2020, 12, 17),
                new DateTime(2020, 12, 15),
                new DateTime(2020, 11, 17),
                new DateTime(2020, 10, 1) 
            };

            dates = AnalyticsClass.PopularMonths(dates);
            // должно вернуть 3 записи
            Assert.AreEqual(dates.Count, 3);

            // первой должен быть декабрь
            Assert.AreEqual(dates[0], new DateTime(2020, 12, 1));
        }
    }
}
