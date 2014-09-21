'use strict';

define(['musicCatalogueApp/services/routeResolver'], function() {

    var app = angular.module('musicCatalogueApp', [
        'ngRoute', 'ngAnimate',
        'routeResolverServices', 'wc.directives', 'wc.animations', 'ui.bootstrap']);

    app.config([
        '$routeProvider', 'routeResolverProvider', '$controllerProvider',

        function($routeProvider, routeResolverProvider, $controllerProvider) {

            app.register = {
                controller: $controllerProvider.register
            }

            //Define routes - controllers will be loaded dynamically
            var route = routeResolverProvider.route;

            $routeProvider
                //route.resolve() now accepts the convention to use (name of controller & view) as well as the 
                //path where the controller or view lives in the controllers or views folder if it's in a sub folder. 
                //For example, the controllers for recordings live in controllers/recordings and the views are in views/recordings.
                //The controllers for artists live in controllers/artists and the views are in views/artists
                //The second parameter allows for putting related controllers/views into subfolders to better organize large projects
                //Thanks to Ton Yeung for the idea and contribution
                .when('/recordings', route.resolve('Recordings', 'recordings/'))
                .when('/recording/:recordingId', route.resolve('Recording', 'recordings/'))
                .when('/recordingedit/:recordingId', route.resolve('RecordingEdit', 'recordings/', true))
                .when('/artists', route.resolve('Artists', 'artists/'))
                .when('/about', route.resolve('About'))
                .when('/login/:redirect*?', route.resolve('Login'))
                .otherwise({ redirectTo: '/recordings' });
        }
    ]);

    return app;
});