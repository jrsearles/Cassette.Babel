# Cassette.Babel

A plugin for the [Cassette](http://getcassette.net/) bundling library for ASP.Net which pipes JavaScript files through the [Babel](https://babeljs.io/) transpiler.

## Setup

Like Babel itself, this plugin does not make any assumptions about what presets or plugins you want to use. In your Cassette bundling config you will need to specify your Babel configurations.

```csharp
public class CassetteConfiguration : IConfiguration<BundleCollection>
{
  public CassetteConfiguration(BabelSettings babelSettings)
  {
    // to setup presets
    babelSettings.Presets.Add("es2015");

    // to add individual plugins
    babelSettings.Plugins.Add("es2015-arrow-functions");

    // if you need to pass configuration options to the preset/plugin you can pass an anonymous object 
    // with the desired options
    babelSettings.Presets.Add("es2015", { Loose = true });

    // to bypass certain files from being processed, you can use the `IgnorePatterns` collection of Regex patterns
    // by default "node_modules" and the Cassette diagnostic page are ignored for processing
    babelSettings.IgnorePatterns.Add(new Regex(@"ignore\\path"));
  }
}
```

## Technical Details

The plugin uses an embedded version of [babel-standalone](https://github.com/babel/babel-standalone), currently using version 6.24.2. Files are processed using the local installation of Edge or Internet Explorer via the library [MsieJavaScriptEngine](https://github.com/Taritsyn/MsieJavaScriptEngine).

## Caveats

Currently all files are processed when the plugin is installed. There is no way to target a particular bundle without leveraging the `IgnorePatterns` property.

Only the plugins and presets included within the babel-standalone library are available for use. You can deduce the plugins available by reviewing the libraries [package.json](https://github.com/babel/babel-standalone/blob/release-6.24.2/package.json) file. (Though technically feasible there is currently not a way to include custom Babel plugins.)

`.babelrc` or `package.json` files cannot be used to supply configuration information. All configuration details will need to be supplied directly to the plugins and presets.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details