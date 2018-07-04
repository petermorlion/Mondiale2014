/// <binding BeforeBuild='less' />
var gulp = require('gulp');
var less = require('gulp-less');
var path = require('path');
var headerComment = require('gulp-header-comment');

gulp.task('less', function () {
    return gulp.src('./Content/Site.less')
      .pipe(less({
          paths: [path.join(__dirname, 'less', 'includes')]
        }))
      .pipe(headerComment('This file was generated. Edit the source file for any changes or they will be overwritten.'))
      .pipe(gulp.dest('./Content/'));
});

gulp.task('watch', function() {
    gulp.watch('./Content/**/*.less', ['less']);
});