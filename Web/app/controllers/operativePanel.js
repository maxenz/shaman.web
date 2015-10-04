angular.module('app')

.controller('OperativePanelCtrl', ['$scope', 'operativeFactory','mobilesFactory', function($scope, operativeFactory, mobilesFactory){

    $scope.operative = {};
    $scope.mobiles = {};
    $scope.incident = {};

    var getOperative = function () {
        operativeFactory.getAll()
            .success(function (data) {
                console.log(data);
                $scope.operative = data.Incidents;
                $scope.gridOptions.data = data.Incidents;
                $scope.gridOptionsMobile.data = data.Mobiles;
                
                $scope.labelsChartQuantity = data.QuantityChartDescriptions;
                $scope.dataChartQuantity = data.QuantityChartQuantities;

                $scope.labelsChartTimes = data.TimeChartDescriptions;
                $scope.dataChartTimes = data.TimeChartValues;

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
              { field: 'Id', name:'Id'},
              { field: 'AbreviaturaId', name: 'Gdo'},
              { field: 'Cliente'},
              { field: 'NroIncidente', name: 'Nro' },
              { field: 'Domicilio', name: 'Domicilio'},
              { field: 'Sintomas', name: 'Sintomas' },
              { field: 'Localidad', name: 'Loc' },
              { field: 'SexoEdad', name: 'SE' },
              { field: 'Movil', name: 'Mov' },
              { field: 'horLlamada', name: 'Llam' },
              { field: 'TpoDespacho', name: 'Dsp' },
              { field: 'TpoSalida', name: 'Sal' },
              { field: 'TpoDesplazamiento', name: 'Dpl' },
              { field: 'TpoAtencion', name: 'Ate' },
              { field: 'Paciente', name: 'Paciente' },
              {field : 'dmReferencia', name: 'Referencias'}

        ]
    };


    $scope.gridOptions.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
        gridApi.selection.on.rowSelectionChanged($scope, function (row) {
            $scope.incident = $scope.operative.filter(function (incident) {
                return incident.ID === row.entity.ID;
            })[0];
            
        })
    }


    $scope.gridOptionsMobile = {
        enableSorting: true,
        enableRowSelection: true,
        enableRowHeaderSelection: false,
        multiSelect: false,
        columnDefs: [
              { field: 'Movil', name: 'Mov'},
              { field: 'ZonaGeograficaId', name: 'Zona' },
              { field: 'ValorGrilla', name: 'Est' }
        ]
    };

    $scope.nextIncident = function () {
        $scope.incident = $scope.operative[getSelectedIncident() + 1];
    }

    $scope.beforeIncident = function () {
        $scope.incident = $scope.operative[getSelectedIncident() - 1];
    }

    $scope.lastIncident = function () {
        $scope.incident = $scope.operative[$scope.operative.length - 1];
    }

    $scope.firstIncident = function () {
        $scope.incident = $scope.operative[0];
    }

    var getSelectedIncident = function () {
        return arrayObjectIndexOf($scope.operative, $scope.incident.ID, "ID");
    }

    // --> Funciones genericas, seran puestas en un general luego
    var arrayObjectIndexOf = function(myArray, searchTerm, property) {
        for (var i = 0, len = myArray.length; i < len; i++) {
            if (myArray[i][property] === searchTerm) return i;
        }
        return -1;
    }


}]);


