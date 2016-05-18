(function () {
    'use strict';

    var controllerId = 'tournaments';
    angular.module('app')
        .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        
            var vm = this;
            vm.title = 'Toernooien';

            loadTournaments();

            function loadTournaments() {
            vm.isLoading = true;
                $http({
                    method: 'GET',
                    url: '/api/tournaments'
                }).success(function (data) {

                    vm.isLoading = false;
                    toastr.info('Succes');
                }).error(function () {
                    vm.isLoading = false;
                    toastr.error('Er is helaas een fout gebeurd...');
                });
            }
        
    }]);
})();