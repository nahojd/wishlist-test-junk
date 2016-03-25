//var bSync = require('browser-sync');
var del = require('del');
var gulp = require('gulp');
var webpack = require('webpack-stream');

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
gulp.task('build', gulp.parallel('build-ts'));
gulp.task('default', gulp.series('clean', 'build'));
//gulp.task('watch', gulp.series('clean', 'build', 'server', 'watch-scripts', 'watch-reload'));
gulp.task('watch', gulp.series('clean', 'build', 'watch-scripts'));