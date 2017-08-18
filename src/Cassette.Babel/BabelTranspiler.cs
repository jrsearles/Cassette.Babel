namespace Cassette.Babel
{
  public class BabelTranspiler
  {
    private readonly IBabelScriptEngine _engineFactory;
    private readonly string _babelSettingsJson;

    public BabelTranspiler(BabelSettings babelSettings, IBabelScriptEngine engineFactory)
    {
      _engineFactory = engineFactory;
      _babelSettingsJson = babelSettings.Serialize();
    }

    public string Transpile(string source)
    {
      return _engineFactory.Execute(source, _babelSettingsJson);
    }

    public static string Version
    {
      get { return "6.26.0"; }
    }
  }
}