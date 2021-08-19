using System;
using System.Collections.Generic;
using System.Linq;

namespace YahooFinance.Extensions
{
    public static class CollectionExtensions
    {
        // Ex: collection.TakeLast(5);
        public static IEnumerable<T> TakeLastOf<T>(this IEnumerable<T> source, int n)
        {
            return source.Skip(Math.Max(0, source.Count() - n));
        }

        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int n)
        {
            return source.Skip(Math.Max(0, source.Count() - n));
        }
    }
}
