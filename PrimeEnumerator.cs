using System.Collections;

public class PrimeEnumerator : IEnumerator<int>, IEnumerable<int>
{
    private IEnumerator<int> source;
    private readonly int upTo;

    public PrimeEnumerator(int upTo)
    {
        this.upTo = upTo;
        source = new ByOneEnumerator();
    }

    void IEnumerator.Reset() => source.Reset();
    int IEnumerator<int>.Current => source.Current;
    object IEnumerator.Current => source.Current;
    bool IEnumerator.MoveNext()
    {
        source.MoveNext();
        if (source.Current > upTo)
        {
            return false;
        }

        if (source.Current <= upTo / 2)
        {
            source = new SkipNthEnumerator(source.Current, source);
        }
        return true;
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => this;
    IEnumerator IEnumerable.GetEnumerator() => this;

    void IDisposable.Dispose() => GC.SuppressFinalize(this);
}