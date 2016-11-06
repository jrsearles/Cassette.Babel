using Cassette.Babel.Sessions;
using Cassette.TinyIoC;
using Cassette.Utilities;

namespace Cassette.Babel
{
  public class BabelRegistration : IConfiguration<TinyIoCContainer>
  {
    public void Configure(TinyIoCContainer container)
    {
      var babelStream = typeof(BabelRegistration).Assembly.GetManifestResourceStream("Cassette.Babel.Resources.babel.generated.js");

      container.Register<IBabelScriptEngineFactory>(new BabelScriptEngineFactory(babelStream.ReadToEnd())).AsSingleton();
      container.Register<CassetteBabelSettings>().AsSingleton();
      container.Register<IBabelScriptSessionProvider, BabelScriptSessionProvider>().AsSingleton();
    }
  }
}