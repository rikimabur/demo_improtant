(function (app) {
    app.filter('statusFilterOrder', function () {
        return function (input) {
            if (input == true)
                return 'Đã Thanh Toán';
            else
                return 'Chưa Thanh Toán';
        }
    });
})(angular.module('PhuocConShop.common'));