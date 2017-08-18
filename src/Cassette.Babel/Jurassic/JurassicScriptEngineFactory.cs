using System;
using System.Threading;
using Jurassic;

namespace Cassette.Babel.Jurassic
{
  /// <summary>
  /// Script engine which uses the Jurassic script interpreter to process JavaScript source.
  /// </summary>
  public class JurassicScriptEngine : IBabelScriptEngine, IDisposable
  {
    private readonly ThreadLocal<ScriptEngine> _engines;

    public JurassicScriptEngine()
    {
      _engines = new ThreadLocal<ScriptEngine>(this.CompileScript, trackAllValues: true);
    }
    
    public string Execute(string source, string babelConfig)
    {
      var engine = _engines.Value;
      engine.SetGlobalValue("source", source);
      engine.SetGlobalValue("config", babelConfig);
      return engine.Evaluate<string>("Babel.transform(source,JSON.parse(config)).code");
    }

    public ScriptEngine CompileScript()
    {
      var engine = new ScriptEngine();
      engine.Execute(new EmbeddedResourceScriptSource("Cassette.Babel.Resources.babel-standalone.min.js", this.GetType().Assembly));
      return engine;
    }

    public void Dispose()
    {
      _engines.Dispose();
    }
  }
}
