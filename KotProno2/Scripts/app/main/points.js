(function () {
    'use strict';
    var controllerId = 'points';
    angular.module('app')
    .controller(controllerId, ['$q', '$http', function ($q, $http) {
        var vm = this;
        vm.title = "De onderlinge stand";
        vm.points = [];
        
        getPoints();

        function getPoints() {
            vm.isLoading = true;
            $http({
                method: 'GET',
                url: '/breeze/matches/points'
            }).success(function (data, status, headers, config) {
                vm.points = data;
                vm.isLoading = false;
            }).error(function (data, status, headers, config) {
                vm.isLoading = false;
                toastr.error('Er is helaas een fout gebeurd.');
            });
        }
    }]);
})();