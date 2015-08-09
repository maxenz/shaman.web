angular.module('app', [
	'ngTouch',
	'ui.grid',
	'ui.grid.selection',
	'ngRoute',
	'app.operativePanel',
	'app.home',
	'chart.js',
    'chieffancypants.loadingBar'
]).

config(['$routeProvider', function ($routeProvider) {

    $routeProvider.

	when('/panel', {
	    templateUrl: 'operativePanel/operativePanel.html',
	    controller: 'OperativePanelCtrl'
	}).
	when('/inicio', {
	    templateUrl: 'home/home.html',
	    controller: 'HomeCtrl'
	}).
	otherwise({
	    redirectTo: '/inicio'
	});
}]);