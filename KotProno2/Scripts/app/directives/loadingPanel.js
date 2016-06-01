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
                    '<span class="loading-panel-icon glyphicon glyphicon-refresh"></span>' +
                    '</div>'
            };
        });
})();