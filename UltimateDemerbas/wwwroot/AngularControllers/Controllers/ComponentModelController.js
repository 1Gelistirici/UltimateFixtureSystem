MainApp.controller("ComponentModelController", ["$scope", "ComponentModelService", "$http", "NgTableParams", function ($scope, ComponentModelService, $http, NgTableParams) {
    $scope.RegisterCount = 0;
    $scope.Pop = [];

    $scope.TableCol = {
        Name: "Component Model Name",
    };

    $scope.GetComponentModels = function () {
        ComponentModelService.GetComponentModels(
            function success(result) {
                if (result.IsSuccess) {
                    console.log("result.Data");
                    console.log(result.Data);
                    $scope.Data = result.Data;
                    $scope.RegisterCount = $scope.Data.length;
                    $scope.TableParams = new NgTableParams({
                        sorting: { name: 'adc' },
                        count: 20
                    }, {
                        counts: [10, 20, 50],
                        dataset: $scope.Data
                    });
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetComponentModels();

    $scope.DeleteComponentModel = function (data) {
        ComponentModelService.DeleteComponentModel(data.Id,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.UpdateComponentModel = function (data) {
        ComponentModelService.UpdateComponentModel(data,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.AddComponentModel = function () {

        var data = {
            "Name": $scope.Pop.Name,
        }

        ComponentModelService.AddComponentModel(data,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });

    }

}]);
