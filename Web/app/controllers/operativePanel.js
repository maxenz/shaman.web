angular.module('app')

.controller('OperativePanelCtrl', ['$scope', 'operativeFactory', function($scope, operativeFactory){

    $scope.operative = {};

    var getOperative = function () {
        operativeFactory.getAll()
            .success(function (operative) {
                console.log(operative);
                $scope.operative = operative;
                $scope.gridOptions.data = operative;
                $scope.incident = operative[0];
            })
            .error(function (error) {

            })
    }

    getOperative();

    $scope.gridOptions = {
        enableSorting: true,
        enableRowSelection: true,
        enableRowHeaderSelection: false,
        multiSelect: false,
        columnDefs: [
              { field: 'GradoOperativoId', name: 'Grado'},
              { field: 'Cliente'},
              { field: 'NroIncidente', name: 'Nro' },
              { field: 'Sintomas', name: 'Sintomas' },
              { field: 'Localidad', name: 'Loc' },
              { field: 'Paciente', name: 'Paciente'}
        ]
    };

    

	$scope.labels = ["January", "February", "March", "April", "May", "June", "July"];
  	$scope.series = ['Series A', 'Series B'];
  	$scope.data2 = [
    [65, 59, 80, 81, 56, 55, 40],
    [28, 48, 40, 19, 86, 27, 90]
	];

  	$scope.labels3 = ["Download Sales", "In-Store Sales", "Mail-Order Sales"];
  	$scope.data3 = [300, 500, 100];


}]);


