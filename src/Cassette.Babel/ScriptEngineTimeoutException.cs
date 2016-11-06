using System;

namespace Cassette.Babel
{
  [Serializable]
  public class ScriptEngineTimeoutException : Exception
  {
    public ScriptEngineTimeoutException(string message) : base(message)
    {
    }
  }
}