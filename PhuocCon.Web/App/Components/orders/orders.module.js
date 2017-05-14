/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('PhuocConShop_Orders', ['PhuocConShop.common']).config(config);
	config.$inject = ['$stateProvider', '$urlRouterProvider'];
	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('orders', {
			url: '/orders',
			parent: 'base',
			templateUrl: '/App/Components/orders/OrderListView.html',
			controller: 'OrderListController'
		}).state('order_add', {
			url: '/order_add',
			parent: 'base',
			templateUrl: '/App/Components/orders/OrderAddView.html',
			controller: 'OrderAddController'
		}).state('order_edit', {
			url: '/order_edit',
			parent: 'base',
			templateUrl: '/App/Components/orders/OrderEditView.html',
			controller: 'OrderEditController'
		});
	}
})();