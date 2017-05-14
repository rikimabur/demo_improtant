(function (app) {
    app.controller('revenueStatisticController', revenueStatisticController);
    revenueStatisticController.$inject = ['$scope', 'apiService', 'notificationService', '$filter'];
    function revenueStatisticController($scope, apiService, notificationService, $filter) {
        $scope.tabledata = [];
        $scope.labels = [];
        $scope.series = ['Doanh thu', 'Lợi nhuận'];
        $scope.chartdata = [];
        function getStatistic() {
            var config = {
                param: {
                    fromDate: '01/01/2016',
                    toDate:'01/01/2018'
                }
            }
            apiService.get('api/statistic/getrevenue?fromDate='+ config.param.fromDate +"&toDate="+ config.param.toDate,null, function (response) {
                $scope.tabledata = response.data;
                var labels = [];
                var chartdata = [];
                var revenues = [];
                var benefits = [];
                $.each(response.data,function(i,item){
                    labels.push($filter('date')(item.Date,'dd/MM/yyyy'));
                    revenues.push(item.Revenues);
                    benefits.push(item.Benefit);

                });
                chartdata.push(revenues);
                chartdata.push(benefits);
                $scope.labels = labels;
                $scope.chartdata = chartdata;
            }, function (response) {
                notificationService.displayError('Không thể tải dữ liệu');
            });
        }
        getStatistic();
    }
})(angular.module('PhuocConShop.statistic'));