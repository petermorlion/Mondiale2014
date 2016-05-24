(function () {
    'use strict';

    var controllerId = 'tournament';
    angular.module('app')
        .controller(controllerId, ['$stateParams', '$http', function ($stateParams, $http) {
        
            var vm = this;
            vm.tournamentId = $stateParams.tournamentId;

            loadTournament();

            function loadTournament() {
                vm.isLoading = true;
                $http({
                    method: 'GET',
                    url: '/api/tournaments/' + vm.tournamentId
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