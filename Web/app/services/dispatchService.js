angular.module('app')

.factory('dispatchFactory', ['$http', function ($http) {

    var dispatchFactory = {};

    dispatchFactory.getAll = function () {
        return $http.get('http://demo.ckan.org/api/3/action/group_list');
    };

    return dispatchFactory;

}]);