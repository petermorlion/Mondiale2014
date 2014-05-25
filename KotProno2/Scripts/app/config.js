(function () {
    'use strict';

    var app = angular.module('app');

    // For use with the HotTowel-Angular-Breeze add-on that uses Breeze
    var remoteServiceName = 'breeze/matches';
    
    var config = {
    };

    app.value('config', config);
})();