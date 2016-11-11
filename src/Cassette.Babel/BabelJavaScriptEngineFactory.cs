using System;
using System.Threading;
using MsieJavaScriptEngine;

namespace Cassette.Babel
{
  public class BabelJavaScriptEngineFactory : IDisposable
  {
    private readonly ThreadLocal<MsieJsEngine> _engines;

    public BabelJavaScriptEngineFactory()
    {
      _engines = new ThreadLocal<MsieJsEngine>(this.CreateEngine, trackAllValues: true);
    }

    public MsieJsEngine GetEngine()
    {
      return _engines.Value;
    }

    private MsieJsEngine CreateEngine()
    {
      var engine = new MsieJsEngine();
      engine.ExecuteResource("Cassette.Babel.Resources.browser-shim.js", this.GetType().Assembly);
      engine.ExecuteResource("Cassette.Babel.Resources.babel-standalone.min.js", this.GetType().Assembly);
      engine.Execute(@"
function transpile(source,config){
  try {
    return Babel.transform(source,JSON.parse(config)).code;
  } catch(err) {
    return 'ERROR:' + err.message;
  }
}");
      return engine;
    }

    public void Dispose()
    {
      foreach (var engine in _engines.Values)
      {
        engine.Dispose();
      }

      _engines.Dispose();
    }
  }
}
