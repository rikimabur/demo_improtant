/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('PhuocConShop.Countrys', ['PhuocConShop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('countrys', {
            url: '/countrys',
            parent: 'base',
            templateUrl: '/App/Components/country/CountryListView.html',
            controller: 'CountryListController'
        }).state('country_edit', {
            url: '/country_edit',
            parent: 'base',
            templateUrl: '/App/Components/country/CountryEditView.html',
            controller: 'CountryEditController'
        }).state('country_add', {
            url: '/country_add',
            parent: 'base',
            templateUrl: '/App/Components/country/CountryAddView.html',
            controller: 'CountryAddController'
        })
    }
})();