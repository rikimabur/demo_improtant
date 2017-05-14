/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('PhuocConShop.Providers', ['PhuocConShop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
          .state('providers', {
            url: '/providers',
            parent:'base',
            templateUrl: '/App/Components/provider/ProviderListView.html',
            controller: 'ProviderListController'
        }).state('provider_add', {
            url: '/provider_add',
            parent: 'base',
            templateUrl: '/App/Components/provider/ProviderAddView.html',
            controller: 'ProviderAddController'
        }).state('provider_edit', {
            url: '/provider_edit/:id',
            parent: 'base',
            templateUrl: '/App/Components/provider/ProviderEditView.html',
            controller: 'ProviderEditController'
        });
    }
})();