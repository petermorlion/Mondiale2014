(function () {
    'use strict';

    // 1e32 is enogh for working with 32-bit
    // 1e8 for 8-bit (100000000)
    // in your case 1e4 (aka 10000) should do it
    // TODO: should be in a filters.js file
    angular.module('app').filter('numberFixedLen', function () {
        return function (a, b) {
            return (1e4 + a + "").slice(-b);
        }
    });

    var controllerId = 'games';
    angular.module('app')
    .controller(controllerId, ['$q', '$http', '$stateParams', 'alertr', function ($q, $http, $stateParams, alertr) {
        var vm = this;
        vm.title = "Pronostieken";
        vm.save = save;
        vm.showOtherBettings = showOtherBettings;
        vm.showAllTopscorers = showAllTopscorers;
        vm.showStage = showStage;
        vm.isActiveStage = isActiveStage;
        vm.stageFilter = { stage: 'EighthFinals' };

        //TODO: async
        getGameBettings();

        function getGameBettings() {
            vm.isLoading = true;
            var promises = [getMatches(), getBettings(), getTopScorer()];
            $q.all(promises).then(gameBettingsQuerySucceeded).catch(queryFailed);
        }

        var games;
        var bettings;
        var teams = GetTeams();

        function getMatches() {
            return $http({
                method: 'GET',
                url: '/api/match/' + $stateParams.tournamentId
            }).then(matchesQuerySucceeded).catch(queryFailed);
        }

        function matchesQuerySucceeded(response) {
            games = response.data;
        }

        function getBettings() {
            return $http({
                method: 'GET',
                url: '/api/bettings/'
            }).then(bettingsQuerySucceeded).catch(queryFailed);
        }

        function getTopScorer() {
            return $http({
                method: 'GET',
                url: '/api/topscorer/' + $stateParams.tournamentId
            }).then(topScorerQuerySucceeded).catch(queryFailed);
        }

        function topScorerQuerySucceeded(response) {
            if (response.data) {
                vm.topscorer = response.data;
                vm.topscorer.isReadOnly = true;
            } else {
                vm.topscorer = { TopScorerName : '', isReadOnly : false };
            }
        }

        function bettingsQuerySucceeded(response) {
            if (typeof response.data === "string") {
                document.location = "/Account/Login";
            }

            bettings = response.data;
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
                
                if (betting) {
                    homeBetting = betting.HomeScore;
                    awayBetting = betting.AwayScore;
                }

                var currentGame = games[i];
                var currentDate = new Date(currentGame.DateTime).setUTCHours(0);
                if (!previousDate || currentDate !== previousDate) {
                    var gameBettingGroup = {
                        date: new Date(currentDate),
                        gameBettings: [],
                        stage: currentGame.Stage
                    }

                    vm.gameBettingGroups.push(gameBettingGroup);
                    previousGameBettingGroup = gameBettingGroup;
                    previousDate = currentDate;
                }

                var gameBetting = {
                    date: new Date(currentGame.DateTime),
                    matchId: currentGame.Id,
                    homeIso: currentGame.HomeTeamIsoCode,
                    awayIso: currentGame.AwayTeamIsoCode,
                    homeDescription: teams[currentGame.HomeTeamIsoCode],
                    awayDescription: teams[currentGame.AwayTeamIsoCode],
                    homeBetting: homeBetting,
                    awayBetting: awayBetting,
                    isReadOnly: currentGame.IsReadOnly,
                    stage: currentGame.Stage,
                    hasError: function () {
                        return this.stage !== 'GroupStage'
                            && this.homeBetting !== ''
                            && this.homeBetting === this.awayBetting;
                    }
                };

                previousGameBettingGroup.gameBettings.push(gameBetting);
            }

            vm.isLoading = false;
        };

        function queryFailed(data) {
            // TODO
            alertr.error('Er is helaas een fout gebeurd.');
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

                ro: 'Roemenië',
                al: 'Albanië',
                _Wales: 'Wales',
                sk: 'Slovakije',
                _England: 'Engeland',
                tr: 'Turkije',
                pl: 'Polen',
                _Northern_Ireland: 'Noord-Ierland',
                ua: 'Oekraïne',
                cz: 'Tsjechië',
                ie: 'Ierland',
                se: 'Zweden',
                at: 'Oostenrijk',
                hu: 'Hongarije',
                is: 'Ijsland',
                eg: 'Egypte',
                sa: 'Saoedi-Arabië',
                ma: 'Marokko',
                pe: 'Peru',
                dk: 'Denemarken',
                rs: 'Serbia',
                pa: 'Panama',
                sn: 'Senegal',
                tn: 'Tunesië'
            };
        }

        function save() {
            //TODO: async
            var newBettings = [];
            var hasError = false;
            for (var i = 0; i < vm.gameBettingGroups.length; i++) {
                var gameBettingGroup = vm.gameBettingGroups[i];
                if (gameBettingGroup.stage != vm.stageFilter.stage) {
                    continue;
                }

                for (var j = 0; j < gameBettingGroup.gameBettings.length; j++) {
                    var gameBetting = gameBettingGroup.gameBettings[j];
                    if (gameBetting.hasError()) {
                        hasError = true;
                        continue;
                    }

                    if (gameBetting.homeBetting === '' || gameBetting.awayBetting === '') {
                        continue;
                    }

                    if (gameBetting.isReadOnly) {
                        continue;
                    }

                    newBettings.push({
                        gameBetting: gameBetting,
                        matchId: gameBetting.matchId,
                        homeBetting: gameBetting.homeBetting,
                        awayBetting: gameBetting.awayBetting
                    });
                }
            }

            $http({
                method: 'POST',
                url: '/api/Bettings',
                data: { newBettings: newBettings, topScorer: { TopScorerName: vm.topscorer.TopScorerName, TournamentId: $stateParams.tournamentId } }
            }).success(function (data, status, headers, config) {
                if (vm.topscorer.TopScorerName !== '') {
                    vm.topscorer.isReadOnly = true;
                }

                if (hasError) {
                    alertr.warning('Je kan enkel gelijkspel invullen in de groepsfase. Gelieve de rood gemarkeerde pronostieken te corrigeren.');
                } else {
                    alertr.info('De scores werden opgeslagen.');   
                }
            }).error(function (data, status, headers, config) {
                alertr.error('Er is helaas een fout gebeurd...');
            });
        }

        function showOtherBettings(matchId) {
            vm.matchDetails = null;
            $http({
                method: 'GET',
                url: '/api/MatchDetails/' + matchId
            }).success(function (data, status, headers, config) {
                vm.matchDetails = data;
                vm.allTopscorers = null;
            }).error(function (data, status, headers, config) {
                alertr.error('Er is helaas een fout gebeurd...');
            });
        }

        function showAllTopscorers() {
            vm.allTopscorers = null;

            return $http({
                method: 'GET',
                url: '/api/TopScorers/' + $stateParams.tournamentId
            }).success(function (data) {
                vm.allTopscorers = data;
                vm.matchDetails = null;
            }).error(queryFailed);
        }

        function showStage(stage) {
            vm.stageFilter.stage = stage;
        }

        function isActiveStage(stage) {
            return stage === vm.stageFilter.stage;
        }
    }]);
})();