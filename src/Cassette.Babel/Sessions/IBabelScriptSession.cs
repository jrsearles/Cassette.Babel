using System;

namespace Cassette.Babel.Sessions
{
  public interface IBabelScriptSession : IDisposable
  {
    BabelScriptEngine Engine { get; }

    string Transpile(string source, BabelConfiguration config);
  }
}