(function () {
    'use strict';

    var controllerId = 'nav';
    angular.module('app')
        .controller(controllerId, ['$location', '$scope', function ($location, $scope) {
        
            var vm = this;

            updateNavigation();

            $scope.$on('$locationChangeSuccess', function() {
                updateNavigation();
            });

            function updateNavigation() {
                vm.hasTournament = /tournaments\/[0-9]/.test($location.path());
            }

        }]);
})();