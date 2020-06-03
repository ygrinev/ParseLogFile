using System;
using System.Linq;
using System.Collections.Generic;

namespace ParseLogFile.Extensions
{
    static class LinqExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return source?.GroupBy(keySelector).Select(grp => grp.First());
        }
    }
}
