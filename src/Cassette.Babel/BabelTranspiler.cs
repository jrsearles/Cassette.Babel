using System;

namespace Cassette.Babel
{
  public class BabelTranspiler
  {
    private readonly BabelJavaScriptEngineFactory _engineFactory;
    private readonly string _babelSettingsJson;

    public BabelTranspiler(BabelSettings babelSettings, BabelJavaScriptEngineFactory engineFactory)
    {
      _engineFactory = engineFactory;
      _babelSettingsJson = babelSettings.Serialize();
    }

    public string Transpile(string source)
    {
      var engine = _engineFactory.GetEngine();
      var output = engine.CallFunction<string>("transpile", source, _babelSettingsJson);

      if (string.IsNullOrEmpty(output) == false && output.StartsWith("ERROR:", StringComparison.Ordinal))
      {
        throw new InvalidOperationException(output.Substring(6));
      }

      return output;
    }
  }
}