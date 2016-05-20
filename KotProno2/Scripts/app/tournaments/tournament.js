(function () {
    'use strict';

    var controllerId = 'tournament';
    angular.module('app')
        .controller(controllerId, ['$routeParams', '$http', function ($routeParams, $http) {
        
            var vm = this;

            loadTournament();

            function loadTournament() {
                vm.isLoading = true;
                $http({
                    method: 'GET',
                    url: '/api/tournaments/' + $routeParams.tournamentId
                }).success(function (data) {
                    vm.tournament = data;
                    vm.isLoading = false;
                }).error(function () {
                    vm.isLoading = false;
                    toastr.error('Er is helaas een fout gebeurd...');
                });
            }
        
    }]);
})();