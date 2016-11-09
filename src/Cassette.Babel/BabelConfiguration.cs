using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cassette.Babel
{
  public class BabelConfiguration
  {
    public BabelConfiguration()
    {
      this.Presets = new BabelConfigurationCollection();
      this.Plugins = new BabelConfigurationCollection();
      this.IgnorePatterns = new List<Regex>();

      this.Presets.Add("es2015");
      this.IgnorePatterns.Add(new Regex(@"Cassette\.Aspnet\.Resources", RegexOptions.IgnoreCase));
      this.IgnorePatterns.Add(new Regex(@"node_modules", RegexOptions.IgnoreCase));
    }

    public BabelConfigurationCollection Presets { get; private set; }

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