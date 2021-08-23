using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockWatcher.Models.Factories.Yahoo;
using System.Linq;
using YahooFinance;

namespace StockWatcher.Tests
{
    [TestClass]
    public class FormatExtensionsTests
    {
        [TestMethod]
        [DataRow("MSFT")]
        public void FormattedGeneralInformationTest(string symbol)
        {
            // arrange
            var service = new YahooService();

            var information = service.GetGeneralInformationAsync(symbol).Result;

            var result = information.QuoteSummary.Result.First();

            var price = result.Price;
            var summaryProfile = result.SummaryProfile;

            // test
            var formattedGeneralInformation = YahooFactory.BuildGeneralInformation(summaryProfile, price);

            // assert
            Assert.IsNotNull(formattedGeneralInformation.ShortName);
            Assert.IsNotNull(formattedGeneralInformation.RegularMarketPreviousClose);
            Assert.IsNotNull(formattedGeneralInformation.RegularMarketOpen);
        }
    }
}
