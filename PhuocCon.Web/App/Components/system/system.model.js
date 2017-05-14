/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
	angular.module('PhuocConShop.System', ['PhuocConShop.Common']).config(config);
	config.$inject = ['$stateProvider', '$urlRouterProvider'];
	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('footer', {
			url: '/footer',
			parent: 'base',
			templateUrl: "/App/Components/system/systemView.html",
			controller: 'systemController'
		});
	}

})();