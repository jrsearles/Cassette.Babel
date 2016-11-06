using Microsoft.ClearScript.V8;

namespace Cassette.Babel
{
  public class BabelScriptEngineFactory : IBabelScriptEngineFactory
  {
    private readonly string _babelRuntime;

    public BabelScriptEngineFactory(string babelRuntime)
    {
      _babelRuntime = babelRuntime;
    }

    public BabelScriptEngine Create()
    {
      var engine = new V8ScriptEngine();
      engine.Execute(_babelRuntime);
      return new BabelScriptEngine(engine);
    }
  }
}