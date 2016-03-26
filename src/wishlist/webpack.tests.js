var webpack = require('webpack');

module.exports = {  
	output: {
		filename: './tests.js'
	},
	resolve: {
		extensions: ['', '.ts', '.js']
	},
	plugins: [
	
	],
	module: {
		loaders: [
			{ test: /\.ts$/, loader: 'ts-loader' }
		]
	}
}