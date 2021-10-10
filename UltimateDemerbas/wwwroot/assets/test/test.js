MainApp.controller("TestController", ["$scope", "LicenseTypeService", "$http", "NgTableParams", function ($scope, LicenseTypeService, $http, NgTableParams) {

    $scope.RegisterCount = 0;
    $scope.TableCol = {
        Name: "License Type Name",
        Id: "Id",
    };

    $scope.UpdateLicensesTypes= function (x) {
        var data = {Id:x.Id,Name:x.Name}
        LicenseTypeService.UpdateLicensesTypes(data,
            function success(result) {
                if (result.IsSuccess) {

                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    };

    $scope.DeleteLicensesTypes = function (x) {
        LicenseTypeService.DeleteLicensesTypes(x.Id,
                function success(result) {
                    if (result.IsSuccess) {

                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
    };

    $scope.AddLicenseType = function () {
        var data = { Name: $scope.popName }
        LicenseTypeService.AddLicenseType(data,
            function success(result) {
                if (result.IsSuccess) {

                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    };

    $scope.GetLicensesTypes = function () {
        LicenseTypeService.GetLicensesTypes(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.Data = result.Data;
                    $scope.RegisterCount = $scope.Data.length;
                    console.log("$scope.Data");
                    console.log($scope.Data);
                    $scope.TableParams = new NgTableParams({
                        sorting: {name:'adc'},
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

    $scope.GetLicensesTypes();




}]);



