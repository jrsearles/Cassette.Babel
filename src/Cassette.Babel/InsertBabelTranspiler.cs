using Cassette.BundleProcessing;
using Cassette.Scripts;

namespace Cassette.Babel
{
  public class InsertBabelTranspiler : IBundlePipelineModifier<ScriptBundle>
  {
    public IBundlePipeline<ScriptBundle> Modify(IBundlePipeline<ScriptBundle> pipeline)
    {
      pipeline.Insert<TranspileJavaScript>(1);
      return pipeline;
    }
  }
}