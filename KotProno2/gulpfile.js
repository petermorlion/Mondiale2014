/// <binding BeforeBuild='less' />
var gulp = require('gulp');
var less = require('gulp-less');
var path = require('path');

gulp.task('less', function () {
    return gulp.src('./Content/Site.less')
      .pipe(less({
          paths: [path.join(__dirname, 'less', 'includes')]
      }))
      .pipe(gulp.dest('./Content/'));
});

gulp.task('watch', function() {
    gulp.watch('./Content/**/*.less', ['less']);
});