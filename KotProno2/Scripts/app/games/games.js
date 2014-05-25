(function () {
    'use strict';
    var controllerId = 'games';
    angular.module('app')
    //.controller(controllerId, ['common', 'datacontext', 'breeze', function (common, datacontext, breeze) {
    .controller(controllerId, ['$q', 'breeze', function ($q, breeze) {
        //var $q = common.$q;
        //var EntityQuery = breeze.EntityQuery;
        //var manager = new breeze.EntityManager('/breeze/matches');

        //var getLogFn = common.logger.getLogFn;
        //var log = getLogFn(controllerId);

        var EntityQuery = breeze.EntityQuery;
        var manager = new breeze.EntityManager('/breeze/matches');

        var vm = this;
        vm.title = "De matchen";

        //TODO: async
        getGameBettings();

        function getGameBettings() {
            
            var promises = [getMatches(), getBettings()];

            $q.all(promises).then(gameBettingsQuerySucceeded).catch(queryFailed);
            //manager.executeQuery(matchesQuery).then(matchesQuerySucceeded).catch(queryFailed);
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

        function bettingsQuerySucceeded(data) {
            bettings = data.results;
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

                var currentDate = games[i].DateTime;
                if (!previousDate || currentDate.setHours(0, 0, 0, 0) !== previousDate.setHours(0, 0, 0, 0)) {
                    var gameBettingGroup = {
                        date: currentDate,
                        gameBettings: []
                    }

                    vm.gameBettingGroups.push(gameBettingGroup);
                    previousGameBettingGroup = gameBettingGroup;
                    previousDate = currentDate;

                }

                var gameBetting = {
                    date: currentDate,
                    homeIso: games[i].HomeTeamIsoCode,
                    awayIso: games[i].AwayTeamIsoCode,
                    homeDescription: teams[games[i].HomeTeamIsoCode],
                    awayDescription: teams[games[i].AwayTeamIsoCode],
                    homeBetting: homeBetting,
                    awayBetting: awayBetting
                };

                previousGameBettingGroup.gameBettings.push(gameBetting);
            }
        };

        function queryFailed(data) {
            // TODO
            alert('error!');
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
                en: 'Engeland',
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
    }]);
})();