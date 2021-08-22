using System.Collections.Generic;

namespace StockWatcher.Models.Models.Models
{
    public class FormattedHistoricalData
    {
        public decimal PreviousClose { get; set; }

        public decimal Last { get; set; }

        public decimal Change => Last - PreviousClose;

        public decimal ChangeP => (Last - PreviousClose) / PreviousClose * 100;
        public List<FormattedQuote> Quotes { get; set; }
    }
}
