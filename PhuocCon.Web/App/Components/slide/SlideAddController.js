(function (app) {
    app.controller(SlideAddController, 'SlideAddController');
    SlideAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];
    function SlideAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.slides = {
            Status : true
        };
        $scope.AddSlide = AddSlide;
        function AddSlide() {
            apiService.post('api/slide/create', $scope.slides,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'Thêm thành công');
                    $state.go('providers');
                },
                function (error) {
                    notificationService.displayError('Thêm không thành công');
                });
        }
        function loadParentSlide() {
            apiService.get('api/slide/getallparents', null, function (result) {
                $scope.ParentSlide = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        loadParentSlide();
     }
})(angular.module('PhuocConShop.Slide'));