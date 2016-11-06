using System;

namespace Cassette.Babel
{
  public class CassetteBabelSettings
  {
    public CassetteBabelSettings()
    {
      this.MaxEngineCount = 20;
      this.ScriptTimeout = TimeSpan.FromSeconds(5);
      this.BabelConfig = new BabelConfiguration();
    }
    
    public BabelConfiguration BabelConfig { get; private set; }

    public int MaxEngineCount { get; set; }

    public int MaxEngineReuse { get; set; }

    public TimeSpan ScriptTimeout { get; set; }
  }
}