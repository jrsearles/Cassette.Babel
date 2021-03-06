﻿using Cassette.Babel.Jurassic;
using Cassette.TinyIoC;

namespace Cassette.Babel
{
  public class BabelRegistration : IConfiguration<TinyIoCContainer>
  {
    public void Configure(TinyIoCContainer container)
    {
      container.Register<BabelSettings>().AsSingleton();
      container.Register<IBabelScriptEngine, JurassicScriptEngine>().AsSingleton();
    }
  }
}