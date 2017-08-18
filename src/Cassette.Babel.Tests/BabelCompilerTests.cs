using Cassette.Babel.Jurassic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cassette.Babel.Tests
{
  [TestClass]
  public class BabelCompilerTests
  {
    [TestMethod]
    public void TestTranspile()
    {
      var settings = new BabelSettings();
      settings.Plugins.Add("transform-es2015-arrow-functions");

      var engine = new JurassicScriptEngine();
      var transpiler = new BabelTranspiler(settings, engine);

      var result = transpiler.Transpile("var noop = () => {};");

      Assert.AreEqual("var noop = function () {};", result);
    }
  }
}
