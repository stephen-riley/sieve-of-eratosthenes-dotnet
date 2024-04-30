using System.Collections;

// This class allows us to change the enumerator that a foreach loop is
//  using without having to exit the loop.  It's just a proxy that passes
//  calls on to the crrently assigned enumerator.
public class HotSwappingEnumerator<T> : IEnumerator<T>
{
    public IEnumerator<T> CurrentEnumerator { get; set; }

    public HotSwappingEnumerator(IEnumerator<T> enumerator) => CurrentEnumerator = enumerator;

    public T Current => CurrentEnumerator.Current;

    public bool MoveNext()
    {
        CurrentEnumerator.MoveNext();
        return true;
    }

    object IEnumerator.Current => throw new NotSupportedException();
    public void Reset() => throw new NotSupportedException();
    public void Dispose() => GC.SuppressFinalize(this);
}