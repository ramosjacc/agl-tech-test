/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    sass = require('gulp-sass')
notify = require("gulp-notify")

// other content removed
var config = {

    sassPath: './Content/sass'
}

//gulp.task('bower', function () {
//    return bower()
//        .pipe(gulp.dest(config.bowerDir))
//});

//gulp.task('icons', function () {

//    return gulp.src(config.bowerDir + '/font-awesome/fonts/**.*')
//        .pipe(gulp.dest('./wwwroot/fonts'));

//});

gulp.task('css', function () {

    return gulp.src(config.sassPath + '/*.scss')
        .pipe(sass({
            style: 'compressed',
            loadPath: ['./Content/sass']
        }).on("error", notify.onError(function (error) {
            return "Error: " + error.message;
        })))
        .pipe(gulp.dest('./Content/css'));
});


gulp.task('watch', function () {
    gulp.watch(config.sassPath + '/**/*.scss', ['css']);
});



gulp.task('default', ['css']);