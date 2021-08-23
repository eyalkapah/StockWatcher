using FancyCandles;
using System.Collections.ObjectModel;

namespace StockWatcher.Models.Models.CandleChart
{
    public class CandlesSource : ObservableCollection<ICandle>, ICandlesSource
    {
        public CandlesSource(TimeFrame timeFrame)
        {
            TimeFrame = timeFrame;
        }

        public TimeFrame TimeFrame { get; }
    }
}
