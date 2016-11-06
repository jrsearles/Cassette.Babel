using System;

namespace Cassette.Babel.Sessions
{
  public interface IBabelScriptSessionProvider : IDisposable
  {
    IBabelScriptSession GetSession();

    void ReleaseSession(IBabelScriptSession engine);
  }
}