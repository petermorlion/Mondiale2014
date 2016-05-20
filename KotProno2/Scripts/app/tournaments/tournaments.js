(function () {
    'use strict';

    var controllerId = 'tournaments';
    angular.module('app')
        .controller(controllerId, ['$http', function ($http) {
        
            var vm = this;
            vm.title = 'Toernooien';

            loadTournaments();

            function loadTournaments() {
            vm.isLoading = true;
                $http({
                    method: 'GET',
                    url: '/api/tournaments'
                }).success(function (data) {
                    vm.tournaments = data;
                    vm.isLoading = false;
                }).error(function () {
                    vm.isLoading = false;
                    toastr.error('Er is helaas een fout gebeurd...');
                });
            }
        
    }]);
})();