(function (app) {
    app.controller(CountryAddController, 'CountryAddController');
    CountryAddController.$inject = ['$scope', 'apiSerice', 'notificationSerice', '$location', 'commonService'];
    function CountryAddController($scope, apiSerice, notificationSerice, $location, commonService) {
        $scope.countrys = {
            Status : true
        };
        $scope.countrysDetail = [];
        $scope.AddCountry = AddCountry;
        function AddCountry() {
            apiSerice.put('api/country/create', $scope.countrys, function (result) {
                notificationService.displaySuccess(result.data.Name + 'Thêm thành công');
                $state.go('providers');
            }, function (error) {
                notificationService.displayError('Thêm không thành công');
            });
        }
        function loadParentCountry() {
            apiService.get('api/country/getallparents', null, function (result) {
                $scope.ParentCountry = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        loadParentCountry();
    }
})(angular.module('PhuocConShop.Countrys'));