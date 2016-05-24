(function () {
    'use strict';

    var app = angular.module('app');

    // Configure the routes and route resolvers
    app.config(['$stateProvider', '$urlRouterProvider', routeConfigurator]);

    function routeConfigurator($stateProvider, $urlRouterProvider) {
        
        $urlRouterProvider.otherwise("/tournaments");

        $stateProvider
            .state('tournaments', {
                url: "/tournaments",
                templateUrl: '/Scripts/app/tournaments/tournaments.html',
                controller: 'tournaments',
                controllerAs: 'vm'
            })
            .state('tournament', {
                url: "/tournament/:tournamentId",
                templateUrl: "/Scripts/app/tournament/tournament.html",
                controller: 'tournament',
                controllerAs: 'vm',
                abstract: true
            })
            .state('tournament.points', {
                url: "",
                templateUrl: "/Scripts/app/points/points.html",
                controller: 'points',
                controllerAs: 'vm'
            })
            .state('tournament.games', {
                url: "/games",
                templateUrl: "/Scripts/app/games/games.html",
                controller: 'tournaments',
                controllerAs: 'vm'
            })
            .state('tournament.overview', {
                url: "/overview",
                templateUrl: "/Scripts/app/overview/overview.html",
                controller: 'overview',
                controllerAs: 'vm'
            })
            .state('tournament.statistics', {
                url: "/statistics",
                templateUrl: "/Scripts/app/statistics/statistics.html",
                controller: 'statistics',
                controllerAs: 'vm'
            })
            .state('admin', {
                url: "/admin",
                templateUrl: "/Scripts/app/admin/admin.html",
                controller: 'tournaments',
                controllerAs: 'vm'
            });
    }
})();