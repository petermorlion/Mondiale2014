(function () {
    'use strict';

    var controllerId = 'overview';
    angular.module('app')
        .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        
            var vm = this;
            vm.title = 'Een overzicht';

            vm.isLoading = true;

            $http({
                method: 'GET',
                url: '/breeze/matches/Overview'
            }).success(function (data, status, headers, config) {
                vm.overview = data;
                vm.isLoading = false;
            }).error(function (data, status, headers, config) {
                alert('error');
            });
        
    }]);
})();