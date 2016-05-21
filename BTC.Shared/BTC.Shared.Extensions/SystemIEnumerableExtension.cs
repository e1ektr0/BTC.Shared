using System;
using System.Collections.Generic;
using System.Linq;

namespace BTC.Shared.Extensions
{
    public static class SystemIEnumerableExtension
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));
        }

        /// <summary>
        /// Возвращает разницу левого множества от правого (элементы левого множества, отсутствующие в правом)
        /// </summary>
        /// <typeparam name="TSource">Тип элементов множества</typeparam>
        /// <param name="lSet">Левое множество - объект сравнения</param>
        /// <param name="rSet">Правое множество - с чем сравниваем</param>
        public static IEnumerable<TSource> LeftDifference<TSource>(IEnumerable<TSource> lSet, IEnumerable<TSource> rSet)
        {
            return lSet.Any() ? lSet.Where(w => rSet.All(a => !a.Equals(w))) : Enumerable.Empty<TSource>();
        }
    }
}