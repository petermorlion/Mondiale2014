(function () {
    'use strict';

    var controllerId = 'tournament';
    angular.module('app')
        .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        
            var vm = this;
            vm.title = 'Toernooi';
        
    }]);
})();