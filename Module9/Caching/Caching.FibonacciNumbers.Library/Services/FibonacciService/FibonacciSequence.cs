using System.Collections.Generic;

namespace Caching.FibonacciNumbers.Core.Services.FibonacciService
{
    public class FibonacciSequence
    {
        public IEnumerable<int> GetNumbers(int count)
        {
            var firstEl = 0;
            var secondEl = 1;
            int value;
            yield return secondEl;

            while (count-- > 1)
            {
                value = firstEl + secondEl;
                yield return value;
                firstEl = secondEl;
                secondEl = value;
            }
        }
    }
}
