﻿/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('PhuocConShop.application_users', ['PhuocConShop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
          .state('application_users', {
              url: '/application_users',
            parent:'base',
            templateUrl: '/App/Components/application_users/applicationUserListView.html',
            controller: 'applicationUserListController'
          }).state('add_application_user', {
            url: '/add_application_user',
            parent: 'base',
            templateUrl: '/App/Components/application_users/applicationUserAddView.html',
            controller: 'applicationUserAddController'
        }).state('edit_application_user', {
            url: '/edit_application_user/:id',
            parent: 'base',
            templateUrl: '/App/Components/application_users/applicationUserEditView.html',
            controller: 'applicationUserEditController'
        });
    }
})();