(function () {
    'use strict';
    var controllerId = 'admin';
    angular.module('app')
    .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        var EntityQuery = breeze.EntityQuery;
        var manager = new breeze.EntityManager('/breeze/matches');

        var vm = this;
        vm.title = "Admin gedeelte";
        vm.games = [];
        vm.save = save;
        
        getGames();

        function getGames() {
            vm.isLoading = true;
            var matchesQuery = EntityQuery.from('Matches');
            return manager.executeQuery(matchesQuery).then(matchesQuerySucceeded).catch(queryFailed);
        }

        function matchesQuerySucceeded(data) {
            vm.games = data.results;
            vm.isLoading = false;
        }

        function save() {
            //TODO: async
            var newScores = [];
            for (var i = 0; i < vm.games.length; i++) {
                if (vm.games[i].HomeScore !== null && vm.games[i].AwayScore !== null) {
                    var score = {
                        matchId: vm.games[i].Id,
                        homeScore: vm.games[i].HomeScore,
                        awayScore: vm.games[i].AwayScore,
                        penaltyWinner: vm.games[i].PenaltyWinner
                    };

                    newScores.push(score);
                }
            }


            $http({
                method: 'POST',
                url: '/breeze/matches/AddScores',
                data: { newScores: newScores }
            }).success(function (data, status, headers, config) {
                toastr.info('De scores zijn opgeslaan.');
            }).error(function (data, status, headers, config) {
                toastr.error('Er is helaas een fout gebeurd.');
            });
        }

        function queryFailed(data) {
            // TODO
            toastr.error('Er is helaas een fout gebeurd.');
        };
    }]);
})();