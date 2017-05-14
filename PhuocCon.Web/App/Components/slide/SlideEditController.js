(function (app) {
    app.controller(SlideEditController, 'SlideEditController');
    SlideEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];
    function SlideEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.slides = {
            Status: true
        }
        $scope.UpdataSlide = UpdataSlide;
        function loadSlideDetail() {
            apiService.get('api/slide/getbyid/' + $stateParams.id, null, function (result) {
                $scope.slides = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function UpdataSlide() {
            apiService.put('api/slide/update', $scope.slides,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'Thêm thành công');
                    $state.go('slides');
                }, function (error) {
                    notificationService.displayError('Thêm không thành công');
                });
        }
        function loadSlide() {
            apiService.get('api/slide/getallparents', null, function (result) {
                $scope.parentSlide = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        loadSlideDetail();
        loadSlide();
    }
})(angular.module('PhuocConShop.Slide'))