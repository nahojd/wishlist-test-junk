var webpack = require('webpack');

module.exports = {  
	output: {
		filename: './tests.js'
	},
	resolve: {
		extensions: ['', '.ts', '.tsx', '.js']
	},
	plugins: [
	
	],
	module: {
		loaders: [
			{ test: /\.tsx?$/, loader: 'ts-loader' }
		]
	}
}