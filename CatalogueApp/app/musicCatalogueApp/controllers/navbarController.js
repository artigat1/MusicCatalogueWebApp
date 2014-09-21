'use strict';

define(['app'], function (app) {
    var injectParams = ['$scope', '$location', 'config'];

    var NavbarController = function ($scope, $location, config) {
        var appTitle = "Steve's Music Catalogue";
        $scope.isCollapsed = false;
        $scope.appTitle = appTitle;

        $scope.highlight = function (path) {
            return $location.path().substr(0, path.length) == path;
        };

    };

    NavbarController.$inject = injectParams;

    //Loaded normally since the script is loaded upfront 
    //Dynamically loaded controller use app.register.controller
    app.controller('NavbarController', NavbarController);

});