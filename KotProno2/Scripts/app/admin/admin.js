(function () {
    'use strict';
    var controllerId = 'admin';
    angular.module('app')
    .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        var EntityQuery = breeze.EntityQuery;
        var manager = new breeze.EntityManager('/breeze/matches');

        var vm = this;
        vm.title = "Admin gedeelte";
    }]);
})();