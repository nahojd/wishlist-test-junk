var webpack = require('webpack');

module.exports = {  
  output: {
    filename: './bundle.js',
    sourceMapFilename: './maps/bundle.js.map'
  },
  devtool: 'source-map',
  resolve: {
    extensions: ['', '.webpack.js', '.web.js', '.ts', '.js']
  },
  plugins: [
    new webpack.optimize.UglifyJsPlugin()  
  ],
  module: {
    loaders: [
      { test: /\.ts$/, loader: 'ts-loader' }
    ]
  }
}