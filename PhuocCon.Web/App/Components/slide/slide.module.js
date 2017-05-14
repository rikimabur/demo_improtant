/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
	angular.module('PhuocConShop.Slide', ['PhuocConShop.common']).config(config);
	config.$inject = ['$stateProvider', '$urlRouterProvider'];
	function config($stateProvider, $urlRouterProvider) {
	    $stateProvider
          .state('slides', {
			url: '/slides',
			parent: 'base',
			templateUrl: '/App/Components/slide/SlideListView.html',
			controller: 'SlideListController'
		}).state('slide_add', {
			url: '/slide_add',
			parent: 'base',
			templateUrl: '/App/Components/slide/SlideAddView.html',
			controller: 'SlideAddController'
		}).state('slide_edit', {
			url: '/slide_edit',
			parent: 'base',
			templateUrl: '/App/Components/slide/SlideEditView.html',
			controller: 'SlideEditController'
		});
	}
})();