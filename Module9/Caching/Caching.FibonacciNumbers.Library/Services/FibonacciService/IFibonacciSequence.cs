using System.Collections.Generic;

namespace Caching.FibonacciNumbers.Core.Services.FibonacciService
{
    public interface IFibonacciSequence
    {
        IEnumerable<int> GetNumbers(int count);
    }
}
