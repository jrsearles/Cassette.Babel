namespace Cassette.Babel.Sessions
{
  public class BabelScriptSession : IBabelScriptSession
  {
    private readonly IBabelScriptSessionProvider _provider;
    private bool _disposed;

    public BabelScriptSession(BabelScriptEngine engine, IBabelScriptSessionProvider provider)
    {
      _provider = provider;
      this.Engine = engine;
    }

    public BabelScriptEngine Engine { get; private set; }

    public string Transpile(string source, BabelConfiguration config)
    {
      return this.Engine.Transpile(source, config);
    }

    public void Dispose()
    {
      if (_disposed == false)
      {
        _disposed = true;
        _provider.ReleaseSession(this);
      }
    }
  }
}