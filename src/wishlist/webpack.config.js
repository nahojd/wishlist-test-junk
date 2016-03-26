var webpack = require('webpack');

module.exports = {
	cache: true,
	output: {
		filename: './bundle.js',
		sourceMapFilename: './maps/bundle.js.map'
	},
	devtool: 'source-map',
	resolve: {
		extensions: ['', '.ts', '.tsx', '.js']
	},
	plugins: [
		new webpack.optimize.UglifyJsPlugin()  
	],
	module: {
		loaders: [
			{ test: /\.tsx?$/, loader: 'ts-loader' }
		]
	}
}