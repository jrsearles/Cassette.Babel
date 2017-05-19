using System;
using System.Runtime.Serialization;

namespace Cassette.Babel
{
  [Serializable]
  public class BabelCompilationException : Exception
  {
    protected BabelCompilationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public BabelCompilationException(string message, string path, Exception innerException) : base(message, innerException)
    {
      this.SourcePath = path;
    }

    public string SourcePath { get; set; }
  }
}