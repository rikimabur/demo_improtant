(function (app) {
    app.controller('OrderEditController', OrderEditController);
    OrderEditController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function OrderEditController($scope, apiService, notificationService, $ngBootbox, $filter) {

    }
})(angular.module('PhuocConShop_orders'));