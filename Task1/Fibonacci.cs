using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// Provides functionality for working with Fibonacci numbers
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Returns consistently Fibonacci numbers
        /// </summary>
        /// <param name="amount">Amount of numbers to return</param>
        /// <returns>Next Fibonacci number on each call</returns>
        public static IEnumerable<int> Take(int amount)
        {
            var previous = 1;
            var current = 1;

            yield return previous;
            yield return current;

           for (int i = 0; i < amount - 2; i++)
            {
                var next = previous + current;
                yield return next;
                previous = current;
                current = next;
            }
        }
    }
}
