using System.Collections;

public class ByOneEnumerator : IEnumerator<int>, IEnumerable<int>
{
    private const int START = 1;

    private int current = START;

    public int Current => current;

    object IEnumerator.Current => Current;

    public void Dispose() => GC.SuppressFinalize(this);

    public IEnumerator<int> GetEnumerator() => this;

    public bool MoveNext()
    {
        current += 1;
        return true;
    }

    public void Reset()
    {
        current = START;
    }

    IEnumerator IEnumerable.GetEnumerator() => this;
}