using System.Text;

public static class Extensions
{
    // This extension lets IEnumerators pretend to be IEnumerables for the
    //  purposes of foreach() loops.  Foreach doesn't look for IEnumerables
    //  specifically; rather, it is checking at compile time if the iterated
    //  object can have GetEnumerator() called.
    public static IEnumerator<T> GetEnumerator<T>(this IEnumerator<T> self) => self;

    // Utility extension for logging purposes.
    public static string Repeat(this string self, int n)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(self);
        }
        return sb.ToString();
    }
}