using System;
using System.Collections;
using System.Collections.Generic;

namespace Cassette.Babel
{
  public class BabelConfigurationCollection : IEnumerable<object>
  {
    private readonly IDictionary<string, object[]> _entries = new Dictionary<string, object[]>(StringComparer.Ordinal);

    public void Clear()
    {
      _entries.Clear();
    }

    public void Add(string name, params object[] options)
    {
      _entries[name] = options;
    }

    public void Remove(string name)
    {
      _entries.Remove(name);
    }

    private IEnumerable<object> GetEntries()
    {
      // this wlll give Json.Net what it needs to serialize the configuration as needed
      foreach (var entry in _entries)
      {
        if (entry.Value == null || entry.Value.Length == 0)
        {
          // just the key, ie ["es2015"]
          yield return entry.Key;
        }
        else
        {
          // options included, ie [["es2015",{"loose":true}]]
          var options = new List<object> {entry.Key};
          options.AddRange(entry.Value);
          yield return options;
        }
      }
    }

    public IEnumerator<object> GetEnumerator()
    {
      return this.GetEntries().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEntries().GetEnumerator();
    }
  }
}