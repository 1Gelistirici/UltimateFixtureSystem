MainApp.controller("LicenseController", ["$scope", "LicenseService", "LicenseTypeService", "$http", "NgTableParams", "toaster",
    function ($scope, LicenseService, LicenseTypeService, $http, NgTableParams, toaster) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "License Name",
            Type: "Type",
            Piece: "Piece"
        };
        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");

        $scope.GetLicenses = function () {
            LicenseService.GetLicenses(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;
                        $scope.tt = "1";
                        $scope.RegisterCount = $scope.Data.length;
                        console.log("$scope.Data");
                        console.log($scope.Data);
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

        $scope.DeleteLicense = function (data) {

            console.log(data);
            console.log(data.Id);

            LicenseService.DeleteLicense(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateLicense = function (data) {

            console.log(data);
            console.log(data.Id);

            LicenseService.UpdateLicense(data,
                function success(result) {
                    if (result.IsSuccess) {
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddLicense = function () {
            console.log($scope.Pop);

            var data = {
                "Name": $scope.Pop.Name,
                "TypeNo": $scope.Pop.TypeNo,
                "Piece": $scope.Pop.Piece,
            }

            LicenseService.AddLicense(data,
                function success(result) {
                    if (result.IsSuccess) {
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });

        }

        $scope.GetLicenses();


        $scope.GetLicensesTypes = function () {
            LicenseTypeService.GetLicensesTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.LicenseTypes = result.Data;
                        console.log("$scope.LicenseTypes");
                        console.log($scope.LicenseTypes);
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

        $scope.GetLicensesTypes();


























    }]);
