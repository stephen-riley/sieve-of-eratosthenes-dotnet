public class Primes
{
    public static IEnumerable<int> ByOne()
    {
        Console.WriteLine("* Entering ByOne()");
        int current = 2;
        while (true)
        {
            Console.WriteLine($"ByOne() yields {current}");
            yield return current;
            current++;
        }
    }

    public static IEnumerable<int> SkipNth(int n, IEnumerable<int> source = null!)
    {
        Console.WriteLine($"Entering SkipNth with {n}, {source.GetType()}");

        source ??= ByOne();

        foreach (var i in source)
        {
            if (i % n != 0)
            {
                Console.WriteLine($"SkipNth({n}) yields {i}");
                yield return i;
            }
            else
            {
                Console.WriteLine($"SkipNth({n}) divisible by {n}, skipping.");
            }
        }
    }

    public static IEnumerable<int> PrimesIter(int upTo)
    {
        var hotswap = new HotSwappingEnumerable<int>(ByOne());

        foreach (var i in hotswap)
        {
            if (i >= upTo)
            {
                yield break;
            }

            Console.WriteLine($"PrimesIter() yields {i}");
            yield return i;
            hotswap.CurrentEnumerable = SkipNth(i, hotswap.CurrentEnumerable);
        }
    }
}