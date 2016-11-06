using System;
using Microsoft.ClearScript;

namespace Cassette.Babel
{
  public class BabelScriptEngine : IDisposable
  {
    private readonly ScriptEngine _engine;

    public BabelScriptEngine(ScriptEngine engine)
    {
      _engine = engine;
    }

    internal int UsageCount { get; set; }

    public string Transpile(string source, BabelConfiguration config)
    {
      this.UsageCount++;
      return _engine.Script.CassetteBabel_Transpile(source, config.Serialize());
    }

    public void Dispose()
    {
      _engine.Dispose();
    }
  }
}