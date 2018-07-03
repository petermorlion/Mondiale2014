(function () {
    'use strict';
    var controllerId = 'points';
    angular.module('app')
        .controller(controllerId, ['$q', '$http', '$stateParams', 'alertr', function ($q, $http, $stateParams, alertr) {
        var vm = this;
        vm.title = "De stand";
        vm.points = [];
        
        getPoints();

        function getPoints() {
            vm.isLoading = true;
            $http({
                method: 'GET',
                url: '/api/points/' + $stateParams.tournamentId
            }).success(function (data, status, headers, config) {
                vm.points = data;
                vm.isLoading = false;
            }).error(function (data, status, headers, config) {
                vm.isLoading = false;
                alertr.error('Er is helaas een fout gebeurd.');
            });
        }
    }]);
})();