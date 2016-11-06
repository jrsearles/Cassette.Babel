using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Cassette.Babel
{
  internal class ConcurrentSet<T> : IEnumerable<T>
  {
    private readonly ConcurrentDictionary<T, byte> _items;

    public ConcurrentSet()
    {
      _items = new ConcurrentDictionary<T, byte>();
    }

    public int Count
    {
      get { return _items.Count; }
    }

    public void Clear()
    {
      _items.Clear();
    }
    
    public bool TryAdd(T item)
    {
      return _items.TryAdd(item, 1);
    }

    public bool TryRemove(T item)
    {
      byte ignored;
      return _items.TryRemove(item, out ignored);
    }

    public IEnumerator<T> GetEnumerator()
    {
      return _items.Keys.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _items.Keys.GetEnumerator();
    }
  }
}