using System;
using System.Linq;

namespace Cassette.Babel
{
  public class BabelCompiler : ICompiler
  {
    private readonly BabelCompilerQueue _queue;
    private readonly BabelTranspiler _transpiler;

    public BabelCompiler(BabelCompilerQueue queue, BabelTranspiler transpiler)
    {
      _queue = queue;
      _transpiler = transpiler;
    }
    
    public CompileResult Compile(string source, CompileContext context)
    {
      // var task = _queue.Enqueue(source);
      try
      {
        // var output = task.AwaitResult();
        var output = _transpiler.Transpile(source);
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