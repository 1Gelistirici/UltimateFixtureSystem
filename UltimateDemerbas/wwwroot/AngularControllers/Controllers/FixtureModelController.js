MainApp.controller("FixtureModelController", ["$scope", "FixtureModelService", "$http", "NgTableParams", function ($scope, FixtureModelService, $http, NgTableParams) {
    $scope.RegisterCount = 0;
    $scope.Pop = [];

    $scope.TableCol = {
        Name: "Fixture Model Name",
    };

    $scope.GetSituations = function () {
        FixtureModelService.GetFixtureModels(
            function success(result) {
                if (result.IsSuccess) {
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
    $scope.GetSituations();

    $scope.DeleteFixtureModel = function (data) {
        FixtureModelService.DeleteFixtureModel(data.Id,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.UpdateFixtureModel = function (data) {
        FixtureModelService.UpdateFixtureModel(data,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.AddFixtureModel = function () {

        var data = {
            "Name": $scope.Pop.Name,
        }

        FixtureModelService.AddFixtureModel(data,
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
