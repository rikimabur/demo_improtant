(function (app) {
    app.controller('ProviderEditController', ProviderEditController);
    ProviderEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];
    function ProviderEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.providers = {
            Status: true
        }
        $scope.UpdateProvider = UpdateProvider;
        function loadProviderDetail() {
            apiService.get('api/Provider/getbyid/' + $stateParams.id, null, function (result) {
                $scope.providers = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function UpdateProvider() {
            apiService.put('api/provider/update', $scope.providers,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'Thêm thành công');
                    $state.go('providers');
                }, function (error) {
                    notificationService.displayError('Thêm không thành công');
           });
        }
        function loadProvider() {
            apiService.get('api/provider/getallparents', null, function (result) {
                $scope.parentProvider = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        loadProvider();
        loadProviderDetail();
    }
})(angular.module('PhuocConShop.Providers'));