(function () {
    'use strict';
    angular.module('app')
        .factory('preventTemplateCache', function ($injector) {
            var build = '3.3.0';
            return {
                'request': function (config) {
                    if (config.url.indexOf('views') !== -1) {
                        config.url = config.url + '?t=' + build;
                    }
                    return config;
                }
            }
        })
        .config(function ($httpProvider) {
            $httpProvider.interceptors.push('preventTemplateCache');
        });
})();