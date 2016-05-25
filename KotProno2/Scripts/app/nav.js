(function () {
    'use strict';

    var controllerId = 'nav';
    angular.module('app')
        .controller(controllerId, ['$scope', '$state', function ($scope, $state) {

            var vm = this;

            updateNavigation();

            $scope.$on('$stateChangeSuccess', function () {
                updateNavigation();
            });

            function updateNavigation() {
                vm.hasTournament = $state.includes('tournament');
            }
        }]);
})();