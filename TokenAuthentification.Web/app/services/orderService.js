'use strict';
app.factory('orderService', ['$http', function ($http) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
    var serviceBase = 'http://localhost:50590/';

    var _getOrders = function () {

        return $http.get(serviceBase + 'api/order').then(function (results) {
            return results;
        });
    };

    return {
        getOrders: _getOrders
    };

}]);