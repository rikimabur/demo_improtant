(function (app) {
    app.controller('CountryListController', CountryListController);
    CountryListController.$inject = ['$scope', 'apiService'];
    function CountryListController($scope, apiService) {

       function getCountrys() {
           apiService.get('api/country/getallparents', null, function (result) {
               $scope.CountryID = result.data.ID;
               $scope.CountryName = result.data.Name;
               $scope.data = {
                   id: [$scope.CountryID],
                   name: [$scope.CountryName]
               }
            }, function () {
                console.log('Load country failed.');
            });
       }
       function getProvinces() {
           apiService.get('api/province/getallparents', null, function (result) {
               $scope.province = result.data;
           }, function () {
               console.log('Load province failed.');
           });
       }
       getCountrys(); // call controller inital
       getProvinces();
       $scope.remove = function (scope) {
           scope.remove();
       };

       $scope.toggle = function (scope) {
           scope.toggle();
       };

       $scope.moveLastToTheBeginning = function () {
           var a = $scope.data.pop();
           $scope.data.splice(0, 0, a);
       };

       $scope.newSubItem = function (scope) {
           var nodeData = scope.$modelValue;
           nodeData.nodes.push({
               id: nodeData.id * 10 + nodeData.nodes.length,
               title: nodeData.title + '.' + (nodeData.nodes.length + 1),
               nodes: []
           });
       };

       $scope.collapseAll = function () {
           $scope.$broadcast('angular-ui-tree:collapse-all');
       };

       $scope.expandAll = function () {
           $scope.$broadcast('angular-ui-tree:expand-all');
       }
    }

})(angular.module("PhuocConShop.Countrys"));