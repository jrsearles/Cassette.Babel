using Cassette.BundleProcessing;
using Cassette.Scripts;

namespace Cassette.Babel
{
  public class TranspileJavaScript : IBundleProcessor<ScriptBundle>
  {
    private readonly CassetteSettings _settings;
    private readonly BabelCompiler _babelCompiler;

    public TranspileJavaScript(CassetteSettings settings, BabelCompiler babelCompiler)
    {
      _settings = settings;
      _babelCompiler = babelCompiler;
    }

    public void Process(ScriptBundle bundle)
    {
      foreach (var asset in bundle.Assets)
      {
        asset.AddAssetTransformer(new CompileAsset(_babelCompiler, _settings.SourceDirectory));
      }
    }
  }
}