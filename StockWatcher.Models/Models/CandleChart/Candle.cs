using FancyCandles;
using System;

namespace StockWatcher.Models.Models.CandleChart
{
    public class Candle : ICandle
    {
        public DateTime t { get; }
        public double O { get; }
        public double H { get; }
        public double L { get; }
        public double C { get; }
        public double V { get; }

        public Candle(DateTime t, double o, double h, double l, double c, double v)
        {
            this.t = t;
            O = o;
            H = h;
            L = l;
            C = c;
            V = v;
        }
    }
}
