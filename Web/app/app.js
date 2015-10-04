angular.module('app', [
	'ngTouch',
	'ngRoute',
    'ui.grid',
    'ui.grid.selection',
    'chart.js',
    'blockUI'
]).

config(['$routeProvider','blockUIConfig', function ($routeProvider, blockUIConfig) {

    blockUIConfig.message = 'Por favor, aguarde un instante...';

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