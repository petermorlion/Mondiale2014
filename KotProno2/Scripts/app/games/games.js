(function () {
    'use strict';

    // 1e32 is enogh for working with 32-bit
    // 1e8 for 8-bit (100000000)
    // in your case 1e4 (aka 10000) should do it
    // TODO: should be in a filters.js file
    angular.module('app').filter('numberFixedLen', function () {
        return function (a, b) {
            return (1e4 + a + "").slice(-b)
        }
    });

    var controllerId = 'games';
    angular.module('app')
    .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        var EntityQuery = breeze.EntityQuery;
        var manager = new breeze.EntityManager('/breeze/matches');

        var vm = this;
        vm.title = "De matchen";
        vm.save = save;
        vm.showOtherBettings = showOtherBettings;

        //TODO: async
        getGameBettings();

        function getGameBettings() {
            
            var promises = [getMatches(), getBettings(), getTopScorer()];

            $q.all(promises).then(gameBettingsQuerySucceeded).catch(queryFailed);
        }

        var games;
        var bettings;
        var teams = GetTeams();

        function getMatches() {
            var matchesQuery = EntityQuery.from('Matches');
            return manager.executeQuery(matchesQuery).then(matchesQuerySucceeded).catch(queryFailed);
        }

        function matchesQuerySucceeded(data) {
            games = data.results;
        }

        function getBettings() {
            var bettingsQuery = EntityQuery.from('Bettings');
            return manager.executeQuery(bettingsQuery).then(bettingsQuerySucceeded).catch(queryFailed);
        }

        function getTopScorer() {
            var topScorerQuery = EntityQuery.from('TopScorer');
            return manager.executeQuery(topScorerQuery).then(topScorerQuerySucceeded).catch(queryFailed);
        }

        function topScorerQuerySucceeded(data) {
            if (data.results.length > 0) {
                vm.topscorer = data.results[0];
                vm.topscorer.isReadOnly = true;
            } else {
                vm.topScorer = { TopScorerName : '', isReadOnly : false };
            }
        }

        function bettingsQuerySucceeded(data) {
            // TODO: vuil
            if (Object.prototype.toString.call(data.results) === '[object Array]' 
                && data.results.length > 0
                && data.results[0].toString().indexOf("<title>Log in") > 0) {
                document.location = "/Account/Login";
            } else {
                bettings = data.results;
            }
        }

        function gameBettingsQuerySucceeded(data) {
            var bettingsByGameId = {};
            for (var i = 0; i < bettings.length; i++) {
                bettingsByGameId[bettings[i].MatchId] = bettings[i];
            }

            var previousDate = '';
            var previousGameBettingGroup = null;
            vm.gameBettingGroups = [];

            for (var i = 0; i < games.length; i++) {
                var betting = bettingsByGameId[games[i].Id];
                var homeBetting = '';
                var awayBetting = '';
                var isReadOnly = false;
                if (betting) {
                    homeBetting = betting.HomeScore;
                    awayBetting = betting.AwayScore;
                    isReadOnly = true;
                }

                var currentGame = games[i];
                var currentDate = new Date(currentGame.DateTime).setUTCHours(0);
                if (!previousDate || currentDate !== previousDate) {
                    var gameBettingGroup = {
                        date: new Date(currentDate),
                        gameBettings: []
                    }

                    vm.gameBettingGroups.push(gameBettingGroup);
                    previousGameBettingGroup = gameBettingGroup;
                    previousDate = currentDate;
                }

                var gameBetting = {
                    date: currentGame.DateTime,
                    matchId: currentGame.Id,
                    homeIso: currentGame.HomeTeamIsoCode,
                    awayIso: currentGame.AwayTeamIsoCode,
                    homeDescription: teams[currentGame.HomeTeamIsoCode],
                    awayDescription: teams[currentGame.AwayTeamIsoCode],
                    homeBetting: homeBetting,
                    awayBetting: awayBetting,
                    isReadOnly: isReadOnly
                };

                previousGameBettingGroup.gameBettings.push(gameBetting);
            }
        };

        function queryFailed(data) {
            // TODO
            alert('Er is een fout gebeurd. My bad...');
        };

        function GetTeams() {
            return {
                br: 'Brazilië',
                hr: 'Kroatië',
                mx: 'Mexico',
                cm: 'Kameroen',

                es: 'Spanje',
                nl: 'Nederland',
                cl: 'Chili',
                au: 'Australië',

                co: 'Colombia',
                gr: 'Griekenland',
                ci: 'Ivoorkust',
                jp: 'Japan',

                uy: 'Uruguay',
                cr: 'Costa Rica',
                gb: 'Engeland',
                it: 'Italië',

                ch: 'Zwitserland',
                ec: 'Ecuador',
                fr: 'Frankrijk',
                hn: 'Honduras',

                ar: 'Argentinië',
                ba: 'Boznië-Herzegovina',
                ir: 'Iran',
                ng: 'Nigeria',

                de: 'Duitsland',
                pt: 'Portugal',
                gh: 'Ghana',
                us: 'USA',

                be: 'België',
                dz: 'Algerije',
                ru: 'Rusland',
                kr: 'Zuid-Korea',
            };
        }

        function save() {
            //TODO: async
            var newBettings = [];
            for (var i = 0; i < vm.gameBettingGroups.length; i++) {
                for (var j = 0; j < vm.gameBettingGroups[i].gameBettings.length; j++) {
                    var gameBetting = vm.gameBettingGroups[i].gameBettings[j];
                    if (gameBetting.homeBetting !== '' && gameBetting.awayBetting !== '' && !gameBetting.isReadOnly) {
                        newBettings.push({
                            gameBetting: gameBetting,
                            matchId: gameBetting.matchId,
                            homeBetting: gameBetting.homeBetting,
                            awayBetting: gameBetting.awayBetting
                        });
                    }
                }
            }

            $http({
                method: 'POST',
                url: '/breeze/matches/AddBettings',
                data: { newBettings: newBettings, topScorer: vm.topscorer }
            }).success(function (data, status, headers, config) {
                for (var i = 0; i < newBettings.length; i++) {
                    newBettings[i].gameBetting.isReadOnly = true;
                }
                if (vm.topscorer.TopScorerName !== '') {
                    vm.topscorer.isReadOnly = true;
                }
            }).error(function (data, status, headers, config) {
                alert('error');
            });
        }

        function showOtherBettings(matchId) {
            $http({
                method: 'GET',
                url: '/breeze/matches/MatchDetails',
                params: { matchId: matchId }
            }).success(function (data, status, headers, config) {
                vm.matchDetails = data;
            }).error(function (data, status, headers, config) {
                alert('error');
            });
        }

        function showAllTopscorers() {
            $http({
                method: 'GET',
                url: '/breeze/matches/TopScorers'
            }).success(function (data, status, headers, config) {
                vm.allTopscorers = data.results;
            }).error(function (data, status, headers, config) {
                alert('error');
            });
        }
    }]);
})();