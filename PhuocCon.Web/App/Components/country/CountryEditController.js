(function (app) {
    app.controller(CountryEditController, 'CountryEditController');
    CountryEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];
    function CountryEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.countrys = {
            Status : true
        }
        $scope.countryDetail = [];

        $scope.UpdateCountry = UpdateCountry;
        function UpdateCountry() {
            apiService.put('/api/country/update', $scope.countrys,
            function (result) {
                notificationService.displaySuccess(result.data.Name + 'Thêm thành công');
                $state.go('countrys');
            }, function (error) {
                notificationService.displayError('Thêm không thành công');
            });
        }
        function loadProvider() {
            apiService.get('/api/country/getallparents', null, function (result) {
                $scope.ParentCountry = result.data;
            }, function () {
                console.log('cannot get list parent');
            })
        }
    }
})(angular.module('PhuocConShop.Countrys'));