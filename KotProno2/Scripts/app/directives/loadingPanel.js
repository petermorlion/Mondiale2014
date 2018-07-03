(function () {
    'use strict';

    var directiveId = 'loadingPanel';
    angular.module('app')
        .directive(directiveId, function() {
            return {
                restrict: 'E',
                scope: {
                    show: '=show'
                },
                template: '<div class="loading-panel" ng-show="show">' +
                    '<i class="loading-panel-icon fas fa-spinner"></i>' +
                    '</div>'
            };
        });
})();