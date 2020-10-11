const path = require('path');
const merge = require('merge');
const webpackConfig = require('./webpack.config');


module.exports = merge(webpackConfig, {

    mode: 'development',

    output: {
        path: path.resolve(__dirname, '../BrandBook.Web/Frontend/dist'),
        filename: 'bundle.js'
    }

});