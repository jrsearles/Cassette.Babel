using System;
using System.Linq;

namespace Cassette.Babel
{
  public class BabelCompiler : ICompiler
  {
    private readonly BabelCompilerQueue _queue;

    public BabelCompiler(BabelCompilerQueue queue)
    {
      _queue = queue;
    }

    public CompileResult Compile(string source, CompileContext context)
    {
      var task = _queue.Enqueue(source);
      try
      {
        var output = task.AwaitResult();
        return new CompileResult(output, Enumerable.Empty<string>());
      }
      catch (Exception ex)
      {
        var message = ex.Message + " in " + context.SourceFilePath;
        throw new BabelCompilationException(message, context.SourceFilePath, ex);
      }
    }
  }
}