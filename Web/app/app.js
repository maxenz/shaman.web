angular.module('app', [
	'ngTouch',
	'ngRoute',
    'ui.grid',
    'ui.grid.selection',
    'chart.js'
]).

config(['$routeProvider', function ($routeProvider) {

    $routeProvider.

	when('/panel', {
	    templateUrl: 'app/views/operativePanel.html',
	    controller: 'OperativePanelCtrl'
	}).
	when('/inicio', {
	    templateUrl: 'app/views/home.html',
	    controller: 'HomeCtrl'
	}).
	otherwise({
	    redirectTo: '/inicio'
	});
}]);