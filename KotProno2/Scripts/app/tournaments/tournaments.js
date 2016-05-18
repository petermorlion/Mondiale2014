(function () {
    'use strict';

    var controllerId = 'tournaments';
    angular.module('app')
        .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        
            var vm = this;
            vm.title = 'Toernooien';
        
    }]);
})();