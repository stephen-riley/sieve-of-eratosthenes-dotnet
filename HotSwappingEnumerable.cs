using System.Collections;
using System.Diagnostics;

[DebuggerDisplay("HotSwap: {Current}")]
public class HotSwappingEnumerable<T> : IEnumerator<T>
{
    public IEnumerator<T> CurrentEnumerator { get; set; }

    public HotSwappingEnumerable(IEnumerator<T> enumerator)
    {
        CurrentEnumerator = enumerator;
    }

    public T Current => CurrentEnumerator.Current;
    object IEnumerator.Current => CurrentEnumerator.Current is not null ? CurrentEnumerator.Current : null!;

    public bool MoveNext()
    {
        CurrentEnumerator.MoveNext();
        return true;
    }

    public void Reset() => CurrentEnumerator.Reset();
    public void Dispose() => GC.SuppressFinalize(this);
}