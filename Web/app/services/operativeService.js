angular.module('app')

.factory('operativeFactory', ['$http', function ($http) {

    var operativeFactory = {};

    operativeFactory.getAll = function () {
        return $http.get('api/Operative');
    };

    return operativeFactory;

}]);