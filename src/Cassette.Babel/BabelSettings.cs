using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cassette.Babel
{
  public class BabelSettings
  {
    public BabelSettings()
    {
      this.Presets = new BabelConfigurationCollection();
      this.Plugins = new BabelConfigurationCollection();
      this.IgnorePatterns = new List<Regex>();

      this.Presets.Add("es2015");
      this.IgnorePatterns.Add(new Regex(@"Cassette\.Aspnet\.Resources", RegexOptions.IgnoreCase));
      this.IgnorePatterns.Add(new Regex(@"node_modules", RegexOptions.IgnoreCase));
    }

    /// <summary>
    /// Gets the presets that are configured. The "es2015" preset is applied by default.
    /// </summary>
    /// <value>
    /// The presets.
    /// </value>
    public BabelConfigurationCollection Presets { get; private set; }

    /// <summary>
    /// Gets the plugins to be used when transpiling.
    /// </summary>
    /// <value>
    /// The plugins.
    /// </value>
    public BabelConfigurationCollection Plugins { get; private set; }

    [JsonIgnore]
    public ICollection<Regex> IgnorePatterns { get; private set; }

    public string Serialize()
    {
      return JsonConvert.SerializeObject(this, new JsonSerializerSettings
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      });
    }
  }
}