﻿using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Cassette.Interop;
using Cassette.Utilities;

namespace Cassette.Babel
{
  public class BabelCompilerQueue : IDisposable
  {
    private readonly string _settingsJson;
    private readonly BlockingCollection<CompileTask> _taskQueue = new BlockingCollection<CompileTask>();

    public BabelCompilerQueue(BabelConfiguration settings)
    {
      _settingsJson = settings.Serialize();
    }

    public void Start()
    {
      Task.Factory.StartNew(this.Loop);
    }

    internal CompileTask Enqueue(string source)
    {
      var task = new CompileTask(source, _settingsJson);
      _taskQueue.Add(task);
      return task;
    }

    private void Loop()
    {
      using (var engine = this.CreateEngine())
      {
        foreach (var task in _taskQueue.GetConsumingEnumerable())
        {
          task.Compile(engine);
        }
      }
    }

    private IEJavaScriptEngine CreateEngine()
    {
      var engine = new IEJavaScriptEngine();
      engine.Initialize();
      engine.LoadLibrary(this.GetType().Assembly.GetManifestResourceStream("Cassette.Babel.Resources.babel-standalone.min.js").ReadToEnd());
      engine.LoadLibrary(@"
function transpile(source,config){
  try {
    return Babel.transform(source,JSON.parse(config)).code;
  } catch(err) {
    return 'ERROR:' + err.message;
  }
}
");

      return engine;
    }

    public void Dispose()
    {
      _taskQueue.CompleteAdding();
    }

    internal class CompileTask
    {
      private readonly string _source;
      private readonly string _config;
      private readonly ManualResetEventSlim _gate = new ManualResetEventSlim();
      private string _result;
      private Exception _exception;

      public CompileTask(string source, string config)
      {
        _source = source;
        _config = config;
      }

      public string AwaitResult()
      {
        _gate.Wait();

        if (_exception != null)
        {
          throw _exception;
        }

        return _result;
      }

      public void Compile(IEJavaScriptEngine engine)
      {
        try
        {
          _result = engine.CallFunction<string>("transpile", _source, _config);
          if (string.IsNullOrEmpty(_result) == false && _result.StartsWith("ERROR:", StringComparison.Ordinal))
          {
            _exception = new Exception(_result.Substring(6));
          }
        }
        catch (Exception ex)
        {
          _exception = ex;
        }
        finally
        {
          _gate.Set();
        }
      }
    }
  }
}