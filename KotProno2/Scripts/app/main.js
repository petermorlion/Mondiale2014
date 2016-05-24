(function () {
    'use strict';

    var controllerId = 'main';
    angular.module('app').controller(controllerId, ['$stateParams', main]);

    function main($stateParams) {
        var vm = this;
        alert($stateParams.tournamentId);
    };
})();