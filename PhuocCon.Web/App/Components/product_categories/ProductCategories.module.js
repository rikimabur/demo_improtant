/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('PhuocConShop.Product_categories', ['PhuocConShop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
          .state('product_categories', {
            url: '/product_categories',
            parent:'base',
            templateUrl: '/App/Components/product_categories/ProductCategoryListView.html',
            controller: 'ProductCategoryListController'
        }).state('product_category_add', {
            url: '/product_category_add',
            parent: 'base',
            templateUrl: '/App/Components/product_categories/ProductCategoryAddView.html',
            controller:'ProductCategoryAddController'
        }).state('product_category_edit', {
            url: '/product_category_edit/:id',
            parent: 'base',
            templateUrl: '/App/Components/product_categories/ProductCategoryEditView.html',
            controller: 'ProductCategoryEditController'
        });
    }
})();