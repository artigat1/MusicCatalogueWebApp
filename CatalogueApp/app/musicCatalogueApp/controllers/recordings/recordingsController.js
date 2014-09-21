'use strict';

define(['app'], function (app) {

    var RecordingsController = function ($scope, $location, $window, recordingsService) {

        $scope.recordings = [];
        $scope.orderBy = 'title';
        $scope.cardAnimationClass = 'card-animation';

        $scope.DisplayModeEnum = {
            Card: 0,
            List: 1
        };

        $scope.changeDisplayMode = function (displayMode) {
            switch (displayMode) {
                case $scope.DisplayModeEnum.Card:
                    $scope.listDisplayModeEnabled = false;
                    break;
                case $scope.DisplayModeEnum.List:
                    $scope.listDisplayModeEnabled = true;
                    break;
            }
        };

        $scope.navigate = function (url) {
            $location.path(url);
        };

        function init() {
            getRecordings();
        }

        function getRecordings() {
            $scope.recordings = recordingsService.getRecordings();
            $scope.totalRecords = $scope.recordings.length;
            $scope.filteredCount = $scope.totalRecords;
        }

        init();
    }

    app.register.controller("RecordingsController", RecordingsController);
});