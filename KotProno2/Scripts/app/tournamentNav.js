(function () {
    'use strict';

    var controllerId = 'tournamentNav';
    angular.module('app')
        .controller(controllerId, ['$routeParams', function ($location, $routeParams) {
        
            var vm = this;

            vm.tournamentId = $routeParams.tournamentId;
        }]);
})();