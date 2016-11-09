using System;

namespace Cassette.Babel
{
  [Serializable]
  public class BabelCompilationException : Exception
  {
    public BabelCompilationException(string message, string path, Exception innerException) : base(message, innerException)
    {
      this.SourcePath = path;
    }

    public string SourcePath { get; set; }
  }
}