angular.module('app')

.controller('HomeCtrl', ['$scope','dispatchFactory', function($scope, dispatchFactory){

    $scope.name = 'Maxo';

    getDispatch();

    function getDispatch() {
        dispatchFactory.getAll()
            .success(function (dispatch) {
                $scope.dispatch = dispatch;
            })
            .error(function (error) {
                $scope.dispatch = error.message;
            })
    }

}]);