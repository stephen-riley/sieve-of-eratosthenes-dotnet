public class Primes
{
    // Starting with 2, return successive integers.
    public static IEnumerator<int> ByOne()
    {
        for (int i = 2; ; i++)
        {
            yield return i;
        }
    }

    // This iterator will return any integer from the source iterator
    //  that is NOT divisible by n.  Eg. SkipNs(3) would return 2, 4, 5, 7...
    public static IEnumerator<int> SkipNs(int n, IEnumerator<int> source)
    {
        foreach (var i in source)
        {
            if (i % n != 0)
            {
                yield return i;
            }
            else
            {
                Console.WriteLine($"{"  ".Repeat(n)}SkipNth({n}) is SKIPPING {i}");
            }
        }
    }

    // Everytime this iterator finds a prime (starting with a base of 2),
    //  it adds another SkipNs(prime) to the chain of SkipNs iterators.
    //  If any integer makes it all the way through the current chain
    //  of SkipNs, it must be the next prime--at which point, a new
    //  SkipNs with that prime is added to the chain.
    // See HotSwappingEnumerator for why we need one here.
    public static IEnumerable<int> PrimesIter(int upTo)
    {
        var hotswap = new HotSwappingEnumerator<int>(ByOne());
        var lastIter = Math.Ceiling(Math.Sqrt(upTo));

        foreach (var i in hotswap)
        {
            if (i >= upTo)
            {
                yield break;
            }

            yield return i;

            hotswap.CurrentEnumerator = i <= lastIter ? SkipNs(i, hotswap.CurrentEnumerator) : hotswap.CurrentEnumerator;
        }
    }
}