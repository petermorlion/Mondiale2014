(function () {
    'use strict';
    var controllerId = 'admin';
    angular.module('app')
    .controller(controllerId, ['$q', 'breeze', '$http', '$stateParams', function ($q, breeze, $http, $stateParams) {
        var EntityQuery = breeze.EntityQuery;
        var manager = new breeze.EntityManager('/breeze/matches');

        var vm = this;
        vm.title = "Admin gedeelte";
        vm.games = [];
        vm.save = save;
        
        getGames();

        function getGames() {
            vm.isLoading = true;
            return $http({
                method: 'GET',
                url: '/api/match/' + $stateParams.tournamentId
            }).then(matchesQuerySucceeded).catch(queryFailed);
        }

        function matchesQuerySucceeded(response) {
            vm.games = response.data;
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