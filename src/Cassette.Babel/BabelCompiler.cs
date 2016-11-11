using System;
using System.Linq;

namespace Cassette.Babel
{
  public class BabelCompiler : ICompiler
  {
    private readonly BabelTranspiler _transpiler;

    public BabelCompiler(BabelTranspiler transpiler)
    {
      _transpiler = transpiler;
    }
    
    public CompileResult Compile(string source, CompileContext context)
    {
      try
      {
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