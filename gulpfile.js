//var bSync = require('browser-sync');
var autoprefixer = require('gulp-autoprefixer');
var cleanCSS = require('gulp-clean-css');
var del = require('del');
var gulp = require('gulp');
var sass = require("gulp-sass");
var sourcemaps = require("gulp-sourcemaps");
var webpack = require('webpack-stream');

gulp.task('build-styles', done => {
    return gulp.src('Styles/main.scss')
        .pipe(sourcemaps.init())
        .pipe(sass().on('error', sass.logError))
        .pipe(autoprefixer({ browsers: ['last 2 versions'] }))
        .pipe(cleanCSS({ debug: true }, details => {
            console.log(details.name + ': ' + details.stats.originalSize);
            console.log(details.name + ': ' + details.stats.minifiedSize);
        }))
        .pipe(sourcemaps.write('maps'))
        .pipe(gulp.dest('wwwroot/dist'));
});

gulp.task('watch-styles', done => {
    return gulp.watch('Styles/**/*.*', gulp.parallel('build-styles')); 
});

gulp.task('build-ts', done => {
    return gulp.src('Scripts/app.ts')
        .pipe(webpack(require('./webpack.config.js')))
        .pipe(gulp.dest('wwwroot/dist/'));
});

gulp.task('watch-scripts', done => {
    return gulp.watch('Scripts/**/*.*', gulp.parallel('build-ts'));
});

//Browser-sync does not currently work with Kestrel, so we can't use it for now... 
/*gulp.task('watch-reload', done => {
     return gulp.watch('wwwroot/dist/*.*', bSync.reload);
});*/

/*gulp.task('server', done => {
    bSync({
        proxy: {
            target: "http://127.0.0.1:5000",
            middleware: function (req, res, next) {
                console.log(req.url);
                next();
            }
        }
    });
    done();
});*/

gulp.task('clean', done => del(['wwwroot/dist'], done));
gulp.task('build', gulp.parallel('build-ts', 'build-styles'));
gulp.task('default', gulp.series('clean', 'build'));
//gulp.task('watch', gulp.series('clean', 'build', 'server', 'watch-scripts', 'watch-reload'));
gulp.task('watch', gulp.series('clean', 'build', gulp.parallel('watch-scripts', 'watch-styles')));