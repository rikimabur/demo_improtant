(function(app){
    app.controller('SlideListController', SlideListController);
    SlideListController.$inject = ['$scope', 'apiService', 'notificationService'];
    function SlideListController($scope, apiService, notificationService) {
        $scope.slide = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.keyword = '';
        $scope.getSlide = getSlide;
    //    $scope.search = search;

    //    $scope.deleteSlide = deleteSlide;
    //    $scope.selectAll = selectAll;
        //    $scope.deleteMultiple = deleteMultiple;
        function getSlide(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page:page,
                    pageSize: 10,
                }
            }
            apiService.get('api/slide/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.slide = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product failed.');
            });
        }
        $scope.getSlide();
    }
})(angular.module('PhuocConShop.Slide'));