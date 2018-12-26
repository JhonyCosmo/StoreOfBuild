var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');
//Tarefa para carregar todas as dependencias de arquivos js
gulp.task('js', function () {
    return gulp.src([
        './Js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        './Js/site.js',
    ]).pipe(gulp.dest('wwwroot/js/'));
});
//Tarefa para carregar todas as dependencias de arquivos css
//Por motivo de compatibilidade com o projeto, coloquei o css do bootstrap
//nessa pasta, pois so o mesmo funciona corretamente com essa versao do aspnet core

gulp.task('css', function () {
    return gulp.src([
        './Styles/bootstrap.css',
        './Styles/site.css',
    ])
        //Concatenando arquivos css em um único arquivo
        .pipe(concat('site.min.css'))
        //Minificando o arquivo gerado
        .pipe(cssmin())
        //Removendo do css do bootstrap todas as classes que não
        //são utilizadas
        .pipe(uncss({ html: ['Views/**/*.cshtml'] }))
        //Movendo arquivos para a pasta css
        .pipe(gulp.dest('wwwroot/css'));
});