namespace Cassette.Babel
{
  /// <summary>
  /// Script engine to process requests to Babel.
  /// </summary>
  public interface IBabelScriptEngine
  {
    /// <summary>
    /// Processes the source code through Babel.
    /// </summary>
    /// <param name="source">The source code.</param>
    /// <param name="babelConfig">The Babel configuration.</param>
    /// <returns>The transpiled source code.</returns>
    string Execute(string source, string babelConfig);
  }
}
