'use strict';
app.controller('ordersController', ['$scope', 'orderService', function ($scope, orderService) {

    $scope.orders = [];

    orderService.getOrders().then(function (results) {

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);