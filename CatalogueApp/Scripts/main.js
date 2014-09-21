require.config({
    baseUrl: '/app',
    urlArgs: 'v=1.0'
});

require(
    [
        'musicCatalogueApp/animations/listAnimations',
        'app',
        'musicCatalogueApp/services/routeResolver',
        'musicCatalogueApp/services/config',
        'musicCatalogueApp/services/recordingsService',
        'musicCatalogueApp/controllers/navbarController'
    ],
    function () {
        angular.bootstrap(document, ['musicCatalogueApp']);
    });
