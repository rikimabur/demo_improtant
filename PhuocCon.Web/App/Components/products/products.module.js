/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('PhuocConShop.Products', ['PhuocConShop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
          .state('products', {
            url: '/products',
            parent: 'base',
            templateUrl: '/App/Components/products/ProductListView.html',
            controller: 'ProductListController'
        }).state('product_add', {
            url: '/product_add',
            parent: 'base',
            templateUrl: '/App/Components/products/ProductAddView.html',
            controller: 'ProductAddController'
        }).state('product_import', {
            url: '/product_import/:id',
            parent: 'base',
            templateUrl: '/App/Components/products/ProductImportView.html',
            controller: 'ProductImportController'
        }).state('product_edit', {
            url: '/product_edit/:id',
            parent: 'base',
            templateUrl: '/App/Components/products/ProductEditView.html',
            controller: 'ProductEditController'
        });
    }
})();
