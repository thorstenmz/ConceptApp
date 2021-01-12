using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TG.ConceptApp.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items) action(item);
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> items, Func<T, Task> asyncAction)
        {
            foreach (T item in items) await asyncAction(item);
        }
    }
}
