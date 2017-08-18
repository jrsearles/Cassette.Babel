using System.IO;
using System.Reflection;
using Jurassic;

namespace Cassette.Babel.Jurassic
{
  internal class EmbeddedResourceScriptSource : ScriptSource
  {
    private readonly string _resourceName;
    private readonly Assembly _assembly;

    public EmbeddedResourceScriptSource(string resourceName, Assembly assembly)
    {
      _resourceName = resourceName;
      _assembly = assembly;
    }

    public override string Path
    {
      get { return null; }
    }

    public override TextReader GetReader()
    {
      var stream = _assembly.GetManifestResourceStream(_resourceName);
      return new StreamReader(stream);
    }
  }
}
