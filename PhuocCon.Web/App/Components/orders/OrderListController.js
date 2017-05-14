(function (app) {
    app.controller('OrderListController', OrderListController);

    OrderListController.$inject = ['$scope', 'apiService', '$ngBootbox', 'notificationService'];
    function OrderListController($scope, apiService, $ngBootbox, notificationService) {
     
        $scope.gridOptions = {
            paginationPageSizes: [15,25,50,100],
            paginationPageSize: 15,
            enableSorting: true,
            enableFiltering: true,
            enableColumnMenus: false,
            //modifierKeysToMultiSelect: false,
            //enableRowHeaderSelection: true,
            //enableRowSelection: true,
            //enableSelectAll: true,
            rowHeight: 50,
            columnDefs: [
              { field: 'ID', displayName: 'ID' },
              { field: 'CustomerName', displayName: 'Tên khách hàng', pinnedLeft: true },
              { field: 'CustomerAdress',displayName: 'Địa chỉ' },
              { field: 'CustomerEmail', displayName:'Email', cellTemplate: '<div>{{row.entity.CustomerEmail}}</div><div ng-if="row.entity.CustomerEmail == null" style="color:red">Email id not available</div>' },
              { field: 'CustomerMobile', displayName: 'SĐT' },
              { field: 'CreatedDate', displayName: 'Ngày mua', type: 'date', cellFilter: 'date:"MM/dd/yyyy"' },
              { field: 'Status', displayName: 'Tình trạng', enableFiltering: false },
              { field: 'BankCode', displayName: 'HT Thanh toán' },
               {
                   name: ' ',
                   enableSorting: false,
                   enableFiltering: false,
                   cellTemplate: '<div><button ng-click="grid.appScope.deleteOrder(row)">Delete</button></div>'
               }
              ]
        };
        $scope.getOrders = getOrders;
        $scope.deleteOrder = deleteOrder;
        function getOrders() {
            apiService.get('/api/order/getallparents', null, function (result) {
                $scope.gridOptions.data = result.data;
            }, function () {
                console.log('Load product failed.');
            });
        }
        function deleteOrder(row) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: row.entity.ID
                    }
                }
                apiService.del('api/order/delete', config, function () {
                    // return number row
                    var index = $scope.gridOptions.data.indexOf(row.entity);
                    $scope.gridOptions.data.splice(index, 1);
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            }); 
          
        }

        $scope.getOrders();
    }

})(angular.module('PhuocConShop_Orders'));