using System.Collections;

public class SkipNthEnumerator : IEnumerator<int>, IEnumerable<int>
{
    private readonly int n;
    private readonly IEnumerator<int> source;

    public SkipNthEnumerator(int n, IEnumerator<int> source = null!)
    {
        this.n = n;
        this.source = source ?? new ByOneEnumerator();
    }

    public int Current => source.Current;
    object IEnumerator.Current => Current;
    public void Dispose() => GC.SuppressFinalize(this);
    public IEnumerator<int> GetEnumerator() => this;

    public bool MoveNext()
    {
        source.MoveNext();
        if (source.Current % n == 0)
        {
            source.MoveNext();
        }
        return true;
    }

    public void Reset() => source.Reset();

    IEnumerator IEnumerable.GetEnumerator() => this;
}