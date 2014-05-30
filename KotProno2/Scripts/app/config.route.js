﻿(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
        	$routeProvider.when(r.url, { templateUrl: r.templateUrl });
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
            	url: '/',
            	templateUrl: '/Scripts/app/main/main.html'
            }, {
            	url: '/games',
            	templateUrl: '/Scripts/app/games/games.html'
            }
        ];
    }
})();