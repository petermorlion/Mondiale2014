(function () {
    'use strict';

    var controllerId = 'main';
    angular.module('app').controller(controllerId,
        ['$rootScope', main]);

    function main($rootScope) {
        var vm = this;
        vm.something = 'something';
    };
})();