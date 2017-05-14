(function (app) {
    app.controller('ProductAddController', ProductAddController);
    ProductAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];
    function ProductAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.originalPrice = null;
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.CkeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.AddProduct = AddProduct;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }
   
        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post('api/product/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'Thêm thành công');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Thêm không thành công');
                });
        }
        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        function loadProvider() {
            apiService.get('api/provider/getallparents', null, function (result) {
                $scope.providers = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.moreImages = [];

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }
       
        loadProductCategory();
        loadProvider();
    }
})(angular.module('PhuocConShop.Products'))