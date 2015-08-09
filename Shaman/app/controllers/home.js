angular.module('app.home', [
	'ngRoute'
])

.controller('HomeCtrl', ['$scope', function($scope){

	$scope.name = 'Maxo';

}]);