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

      this.Presets.Add("es2015");
    }

    public BabelConfigurationCollection Presets { get; private set; }

    public BabelConfigurationCollection Plugins { get; private set; }

    public string Serialize()
    {
      return JsonConvert.SerializeObject(this, new JsonSerializerSettings
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      });
    }
  }
}