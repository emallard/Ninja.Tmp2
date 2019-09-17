var path = require('path')
var webpack = require('webpack')

module.exports = {
    /*
    entry: './src/index.ts',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js']
    },
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'dist')
    },
    */
    devServer: {
        contentBase: path.join(__dirname, 'src'),
        compress: true,
        port: 8000,
        historyApiFallback: {
            historyApiFallback: {
                index: 'src/index.html'
            }
        },
        noInfo: false
    },
    performance: {
        hints: false
    },
    devtool: '#eval-source-map'
}