﻿/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('PhuocConShop',
        ['PhuocConShop.Products',
         'PhuocConShop.Product_categories',
         'PhuocConShop.application_groups',
         'PhuocConShop.application_roles',
         'PhuocConShop.application_users',
         'PhuocConShop.statistic',
         'PhuocConShop_Orders',
         'PhuocConShop.Slide',
         'PhuocConShop.Providers',
         'PhuocConShop.Countrys',
         'PhuocConShop.common'
        ])
        .config(config)
        .config(configAuthentication);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/App/Shared/views/baseView.html',
                abstract:true
            })
            .state('login', {
                url: '/login',
                templateUrl: '/App/Components/login/loginView.html',
                controller: 'loginController'
            })
            .state('Home', {
                url: '/admin',
                parent:'base',
                templateUrl: '/App/Components/home/HomeView.html',
                controller: 'HomeController'
        });
        $urlRouterProvider.otherwise('/login');
    }
    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();
