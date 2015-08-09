angular.module('app.operativePanel', ['ngRoute'])

.controller('OperativePanelCtrl', ['$scope', function($scope){

	$scope.gridOptions = { 
    // enableRowSelection: true,
    // enableSelectAll: true,
    //selectionRowHeaderWidth: 35
  };

    //$scope.gridOptions.multiSelect = true;

	$scope.gridOptions.data = [
		{
			"firstName" : "Maximiliano",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		},
		{
			"firstName" : "Federico",
			"lastName" : "Poggio"
		}

	];


	$scope.labels = ["January", "February", "March", "April", "May", "June", "July"];
  	$scope.series = ['Series A', 'Series B'];
  	$scope.data2 = [
    [65, 59, 80, 81, 56, 55, 40],
    [28, 48, 40, 19, 86, 27, 90]
	];

  	$scope.labels3 = ["Download Sales", "In-Store Sales", "Mail-Order Sales"];
	$scope.data3 = [300, 500, 100];

}]);


