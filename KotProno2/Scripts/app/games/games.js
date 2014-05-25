(function () {
    'use strict';
    var controllerId = 'games';
    angular.module('app')
    //.controller(controllerId, ['common', 'datacontext', 'breeze', function (common, datacontext, breeze) {
    .controller(controllerId, [function () {
          //var $q = common.$q;
          //var EntityQuery = breeze.EntityQuery;
          //var manager = new breeze.EntityManager('/breeze/matches');

          //var getLogFn = common.logger.getLogFn;
          //var log = getLogFn(controllerId);

          var vm = this;
          vm.title = "De matchen";
      }]);
})();