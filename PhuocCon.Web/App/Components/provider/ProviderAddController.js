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
                    notificationService.displaySuccess(result.data.Name + 'Th�m th�nh c�ng');
                    $state.go('providers');
            }, function (error) {
                notificationService.displayError('Th�m kh�ng th�nh c�ng');
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