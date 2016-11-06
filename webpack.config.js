var webpack = require("webpack");

module.exports = {
  entry: "./babel.js",
  output: {
    path: "src/Cassette.Babel/Resources/",
    filename: "babel.generated.js",
    libraryTarget: "this"
  },
  module: {
    loaders: [
      {
        exclude: /node_modules/,
        test: /\.js$/,
        loader: "babel",
        query: {
          presets: ["es2015"]
        }
      },
    ]
  },
  plugins: [
    new webpack.DefinePlugin({
      "process.env.NODE_ENV": '"production"'
    }),
    new webpack.optimize.OccurenceOrderPlugin(),
    new webpack.optimize.DedupePlugin(),
    new webpack.optimize.UglifyJsPlugin()
  ]
};