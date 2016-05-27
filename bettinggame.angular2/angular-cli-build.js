/* global require, module */

var Angular2App = require('angular-cli/lib/broccoli/angular2-app');

module.exports = function (defaults) {
  return new Angular2App(defaults, {
    vendorNpmFiles: [
      'systemjs/dist/system-polyfills.js',
      'systemjs/dist/system.src.js',
      'zone.js/dist/**/*.+(js|js.map)',
      'es6-shim/es6-shim.js',
      'reflect-metadata/**/*.+(js|js.map)',
      'rxjs/**/*.+(js|js.map)',
      '@angular/**/*.+(js|js.map)',

      'moment/min/moment-with-locales.min.js',
      'angular2-jwt/**/*.+(js|js.map)',
      'underscore/underscore*.+(js|map)',

      'bootstrap/dist/js/bootstrap.min.js',
      'bootstrap/dist/css/bootstrap.min.css',

      'flag-icon-css/flags/**/*.svg',
      'flag-icon-css/css/flag-icon.min.css'
    ]
  });
};
