using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using StockWatcher.Services.Services;

namespace YahooFinance.Tests
{
    [TestClass]
    public class YahooServiceTests
    {
        [TestMethod]
        [DataRow("MSFT")]
        public void GetGeneralInformationTest(string symbol)
        {
            // arrange
            var service = new YahooService();

            // test
            var profile = service.GetGeneralInformationAsync(symbol).Result;

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

            //Assert.AreEqual(numOfDays, data.ToList().Count);
        }

        [TestMethod]
        [DataRow("MSFT")]
        public void GetSummaryDetailsTest(string symbol)
        {
            // arrange
            var service = new YahooService();

            // test
            var data = service.GetSummaryDetailsAsync(symbol).Result;

            // assert
            Assert.IsNotNull(data);
        }

        [TestMethod]
        [DataRow("MSFT")]
        public void GetGenericHistoricalDataTest(string symbol)
        {
            // arrange
            var service = new YahooService();

            // test
            var data = service.GetHistoricalDataAsync(symbol).Result;

            // assert
            Assert.IsNotNull(data);
        }

        [TestMethod]
        [DataRow("MSFT")]
        public void GetHistoricalSummaryDetails(string symbol)
        {
            // arrange
            var service = new YahooService();

            // test
            var data = service.GetHistoricalDataAsync(symbol).Result;

            // assert
            Assert.IsNotNull(data);
        }
    }
}
