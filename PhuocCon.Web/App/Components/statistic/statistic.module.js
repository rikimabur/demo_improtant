/// <reference path="/Assets/Admin/libs/angular/angular.js" />

(function () {
    angular.module('PhuocConShop.statistic', ['PhuocConShop.common']).config(config);
	config.$inject = ['$stateProvider', '$urlRouterProvider'];
	function config($stateProvider, $urlRouterProvider) {
	    $stateProvider.state('statistic_revenue', {
	        url: "/statistic_revenue",
	        parent: 'base',
	        templateUrl: "/App/Components/statistic/revenueStatisticView.html",
	        controller: "revenueStatisticController"
	    });
	}
})();