using System.Collections;
using System.Diagnostics;

[DebuggerDisplay("HotSwap: {Current}")]
public class HotSwappingEnumerable<T> : IEnumerator<T>, IEnumerable<T>
{
    private IEnumerator<T> currentEnumerator = null!;
    private IEnumerable<T> currentEnumerable = null!;

    public IEnumerable<T> CurrentEnumerable
    {
        get { return currentEnumerable; }
        set
        {
            currentEnumerable = value;
            currentEnumerator = value.GetEnumerator();
        }
    }

    public HotSwappingEnumerable(IEnumerable<T> enumerable)
    {
        CurrentEnumerable = enumerable;
    }

    public T Current => currentEnumerator.Current;
    object IEnumerator.Current => currentEnumerator.Current is not null ? currentEnumerator.Current : null!;

    public bool MoveNext() => currentEnumerator.MoveNext();
    public void Reset() => currentEnumerator.Reset();
    public void Dispose() => GC.SuppressFinalize(this);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => this;
    IEnumerator IEnumerable.GetEnumerator() => this;
}