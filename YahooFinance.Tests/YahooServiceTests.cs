using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace YahooFinance.Tests
{
    [TestClass]
    public class YahooServiceTests
    {
        [TestMethod]
        [DataRow("MSFT")]
        public void GetProfileTest(string symbol)
        {
            // arrange
            var service = new YahooService();

            // test
            var profile = service.GetProfileAsync(symbol).Result;

            // assert
            Assert.IsNotNull(profile.QuoteSummary.Result.FirstOrDefault());

            var summaryProfile = profile.QuoteSummary.Result.First();

            Assert.IsNotNull(summaryProfile);
        }

        [TestMethod]
        [DataRow("MSFT", 10)]
        public void GetHistoricalDataTest(string symbol, int numOfDays)
        {
            // arrange
            var service = new YahooService();

            // test
            var data = service.GetHistoricalDataAsync(symbol, numOfDays).Result;

            // assert
            Assert.IsNotNull(data);

            Assert.AreEqual(numOfDays, data.ToList().Count);
        }

    }
}
