using System.Collections.Concurrent;

namespace Cassette.Babel.Sessions
{
  public class BabelScriptSessionProvider : IBabelScriptSessionProvider
  {
    private readonly CassetteBabelSettings _settings;
    private readonly IBabelScriptEngineFactory _scriptEngineFactory;

    private readonly BlockingCollection<BabelScriptEngine> _availableEngines = new BlockingCollection<BabelScriptEngine>();
    private readonly ConcurrentSet<BabelScriptEngine> _usedEngines = new ConcurrentSet<BabelScriptEngine>();
    private readonly object _createEngineLock = new object();
    
    public BabelScriptSessionProvider(CassetteBabelSettings settings, IBabelScriptEngineFactory scriptEngineFactory)
    {
      _settings = settings;
      _scriptEngineFactory = scriptEngineFactory;
    }

    private int EngineCount
    {
      get { return _availableEngines.Count + _usedEngines.Count; }
    }
    
    public IBabelScriptSession GetSession()
    {
      BabelScriptEngine engine;
      if (_availableEngines.TryTake(out engine))
      {
        return this.CreateSession(engine);
      }

      if (this.EngineCount < _settings.MaxEngineCount)
      {
        lock (_createEngineLock)
        {
          if (this.EngineCount < _settings.MaxEngineCount)
          {
            engine = _scriptEngineFactory.Create();
            return this.CreateSession(engine);
          }
        }
      }

      if (_availableEngines.TryTake(out engine, _settings.ScriptTimeout))
      {
        return this.CreateSession(engine);
      }

      throw new ScriptEngineTimeoutException("Unable to acquire script engine within alloted time.");
    }

    private BabelScriptSession CreateSession(BabelScriptEngine engine)
    {
      _usedEngines.TryAdd(engine);
      return new BabelScriptSession(engine, this);
    }

    public void ReleaseSession(IBabelScriptSession session)
    {
      _usedEngines.TryRemove(session.Engine);

      if (_settings.MaxEngineReuse == 0 || _settings.MaxEngineReuse > session.Engine.UsageCount)
      {
        _availableEngines.Add(session.Engine);
      }
      else
      {
        session.Engine.Dispose();
      }
    }

    public void Dispose()
    {
      BabelScriptEngine engine;
      while (_availableEngines.TryTake(out engine))
      {
        engine.Dispose();
      }

      foreach (var usedEngine in _usedEngines)
      {
        usedEngine.Dispose();
      }

      _usedEngines.Clear();
    }
  }
}