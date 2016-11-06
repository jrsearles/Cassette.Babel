using System.Linq;
using Cassette.Babel.Sessions;

namespace Cassette.Babel
{
  public class BabelCompiler : ICompiler
  {
    private readonly CassetteBabelSettings _babelSettings;
    private readonly BabelScriptSessionProvider _scriptEngineProvider;

    public BabelCompiler(CassetteBabelSettings babelSettings, BabelScriptSessionProvider scriptEngineProvider)
    {
      _babelSettings = babelSettings;
      _scriptEngineProvider = scriptEngineProvider;
    }

    public CompileResult Compile(string source, CompileContext context)
    {
      using (var session = _scriptEngineProvider.GetSession())
      {
        var output = session.Transpile(source, _babelSettings.BabelConfig);
        return new CompileResult(output, Enumerable.Empty<string>());
      }
    }
  }
}