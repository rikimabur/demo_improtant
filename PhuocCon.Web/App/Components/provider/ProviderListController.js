(function (app) {
    app.controller('ProviderListController', ProviderListController);
    ProviderListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function ProviderListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.providers = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getproviders = getproviders;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProvider = deleteProvider;
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;


        function deleteMultiple() {
            var listID = [];
            $.each($scope.selected, function (i, item) {
                listID.push(item.ID);
            });
            var config = {
                params: {
                    checkedproviders: JSON.stringify(listID)
                }
            }
            apiService.del('api/provider/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công' + result.data + 'bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError("Xóa không thành công!");
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.providers, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.providers, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("providers", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProvider(id) {
            $ngBootbox.confirm('Bạn có muốn xóa ?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/provider/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                })
            });
        }

        function search() {
            getproviders();
        }

        function getproviders(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('api/provider/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.providers = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load provider failed.');
            });
        }
        $scope.getproviders(); // call controller inital 
    }
})(angular.module('PhuocConShop.Providers'));