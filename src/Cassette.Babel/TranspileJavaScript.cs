using System.Linq;
using Cassette.BundleProcessing;
using Cassette.Scripts;

namespace Cassette.Babel
{
  public class TranspileJavaScript : IBundleProcessor<ScriptBundle>
  {
    private readonly CassetteSettings _settings;
    private readonly BabelConfiguration _babelSettings;
    private readonly BabelCompiler _babelCompiler;

    public TranspileJavaScript(CassetteSettings settings, BabelConfiguration babelSettings, BabelCompiler babelCompiler)
    {
      _settings = settings;
      _babelSettings = babelSettings;
      _babelCompiler = babelCompiler;
    }

    public void Process(ScriptBundle bundle)
    {
      foreach (var asset in bundle.Assets)
      {
        if (_babelSettings.IgnorePatterns.Any(x => x.IsMatch(asset.Path)) == false)
        {
          asset.AddAssetTransformer(new CompileAsset(_babelCompiler, _settings.SourceDirectory));
        }
      }
    }
  }
}