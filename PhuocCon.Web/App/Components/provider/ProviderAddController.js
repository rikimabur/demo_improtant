(function (app) {
    app.controller('ProviderAddController', ProviderAddController);

    ProviderAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];
    function ProviderAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.provider = {
            Status: true
        }

        $scope.Addprovider = Addprovider;
        function Addprovider() {
            apiService.post('api/provider/create', $scope.provider,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'Thêm thành công');
                    $state.go('providers');
            }, function (error) {
                notificationService.displayError('Thêm không thành công');
            });
        }
        function loadParentProvider() {
            apiService.get('api/provider/getallparents', null, function (result) {
                $scope.ParentProvider= result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        loadParentProvider();
    }
})(angular.module('PhuocConShop.Providers'));