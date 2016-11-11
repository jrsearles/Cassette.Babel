using Cassette.TinyIoC;

namespace Cassette.Babel
{
  public class BabelRegistration : IConfiguration<TinyIoCContainer>
  {
    public void Configure(TinyIoCContainer container)
    {
      container.Register<BabelSettings>().AsSingleton();
      container.Register<BabelJavaScriptEngineFactory>().AsSingleton();
    }
  }
}