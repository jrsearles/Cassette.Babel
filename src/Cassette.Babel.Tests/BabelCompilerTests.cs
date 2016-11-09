// using Cassette.Babel.Sessions;
using Cassette.Utilities;
using Microsoft.ClearScript.V8;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MsieJavaScriptEngine;

namespace Cassette.Babel.Tests
{
  [TestClass]
  public class BabelCompilerTests
  {
//    private Mock<IBabelScriptSessionProvider> _engineProviderMock;
//    private BabelScriptEngine _engine;

    //[TestInitialize]
    //public void Setup()
    //{
    //  _engineProviderMock = new Mock<IBabelScriptSessionProvider>();
    //  var engine = new V8ScriptEngine();

    //  var babelStream =
    //    typeof(IBabelScriptSessionProvider).Assembly.GetManifestResourceStream(
    //      "Cassette.Babel.Resources.babel.generated.js");

    //  engine.Execute(babelStream.ReadToEnd());

    //  _engine = new BabelScriptEngine(engine);
    //}

    //[TestCleanup]
    //public void TearDown()
    //{
    //  _engine.Dispose();
    //}

    //[TestMethod]
    //public void Can_transpile_ES6_code()
    //{
    //  var code = "let a = 1;";
    //  var compiler = new BabelScriptSession(_engine, _engineProviderMock.Object);
    //  var result = compiler.Transpile(code, new BabelConfiguration());

    //  Assert.AreEqual("\"use strict\";\n\nvar a = 1;", result);
    //}

    //[TestMethod]
    //public void Can_add_presets_to_Babel_settings()
    //{
    //  var code = "var a = 10 ** 2;";
    //  var settings = new BabelConfiguration();
    //  settings.Presets.Add("es2016");
    //  var compiler = new BabelScriptSession(_engine, _engineProviderMock.Object);

    //  var result = compiler.Transpile(code, settings);

    //  Assert.AreEqual("\"use strict\";\n\nvar a = Math.pow(10, 2);", result);
    //}

    //[TestMethod]
    //public void Can_include_options_with_presets()
    //{
    //  var settings = new BabelConfiguration();
    //  settings.Presets.Add("es2015", new {loose = true});

    //  var serialized = settings.Serialize();

    //  Assert.AreEqual("{\"presets\":[[\"es2015\",{\"loose\":true}]],\"plugins\":[]}", serialized);
    //}
//
//    [TestMethod]
//    public void IE_Test()
//    {
////      var babelSource =
////        typeof(IBabelScriptSessionProvider).Assembly.GetManifestResourceStream(
////          "Cassette.Babel.Resources.babel-standalone.min.js").ReadToEnd();
//
//      using (var engine = new MsieJsEngine())
//      {
//        engine.ExecuteResource("Cassette.Babel.Resources.babel-standalone.min.js", typeof(IBabelScriptSessionProvider).Assembly);
//        engine.Execute(@"function transform(source, config) { return Babel.transform(source, JSON.parse(config)).code; }");
//
//        var actual = engine.CallFunction<string>("transform", "let a = 1;",
//          new CassetteBabelSettings().BabelConfig.Serialize());
//        
//        Assert.AreEqual("\"use strict\";\n\nvar a = 1;", actual);
//      }
//    }
  }
}
