/// <binding />
/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        jshint: {

            options: {
                curly: true,
                eqeqeq: true,
                eqnull: true,
                browser: true,
                globals: {
                    jQuery: true
                },
            },

            files: ['Scripts/**/*.js', 'Tests/**/*.js'],
            options: {
                globals: {
                    jQuery: true
                }
            }
        },
        jasmine: {
            Task1: {
                src: 'Scripts/**/*.js',
                options: {
                    specs: 'Tests/**/*.js'
                }
            },
            istanbul: {
                src: '<%= jasmine.Task1.src %>',
                options: {
                    specs: '<%= jasmine.Task1.options.specs %>',
                    template: require('grunt-template-jasmine-istanbul'),
                    templateOptions: {
                        coverage: 'coverage/json/coverage.json',
                        report: [
                            { type: 'html', options: { dir: 'coverage/html' } },
                            { type: 'text-summary' }
                        ]
                    }
                }
            }
        }
    });
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-jasmine');
};