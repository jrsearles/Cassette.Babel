using System.Linq;
using Cassette.BundleProcessing;
using Cassette.Scripts;

namespace Cassette.Babel
{
  public class TranspileJavaScript : IBundleProcessor<ScriptBundle>
  {
    private readonly CassetteSettings _settings;
    private readonly BabelSettings _babelSettings;
    private readonly BabelCompiler _babelCompiler;

    public TranspileJavaScript(CassetteSettings settings, BabelSettings babelSettings, BabelCompiler babelCompiler)
    {
      _settings = settings;
      _babelSettings = babelSettings;
      _babelCompiler = babelCompiler;
    }

    public void Process(ScriptBundle bundle)
    {
      if (_babelSettings.IgnorePatterns.Any(x => x.IsMatch(bundle.Path)))
      {
        return;
      }

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