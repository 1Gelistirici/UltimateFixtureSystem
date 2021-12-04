MainApp.controller("LicensesTypesController", ["$scope", "LicenseTypeService", "NgTableParams", "toaster",
    function ($scope, LicenseTypeService, NgTableParams, toaster) {

        $scope.RegisterCount = 0;
        $scope.TableCol = {
            Name: "License Type Name",
            Id: "Id",
        };

        $scope.UpdateLicensesTypes = function (x) {
            var data = { Id: x.Id, Name: x.Name }
            LicenseTypeService.UpdateLicensesTypes(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Lisans tipi güncellendi.");
                    } else {
                        toaster.error("Başarısız", "Lisans tipi güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Lisans tipi güncelleme işlemi yapılırken bir hata oluştu");
                });
        };

        $scope.DeleteLicensesTypes = function (x) {
            LicenseTypeService.DeleteLicensesTypes(x.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Lisans tipi silindi.");
                        $scope.GetLicensesTypes();
                    } else {
                        toaster.error("Başarısız", "Lisins tipi silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Lisins tipi silme işlemi yapılırken bir hata oluştu");
                });
        };

        $scope.AddLicenseType = function () {
            var data = { Name: $scope.popName }
            LicenseTypeService.AddLicenseType(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Lisans tipi eklendi.");
                        $("#AddLicenseType").modal("hide");
                        $scope.GetLicensesTypes();
                    } else {
                        toaster.error("Başarısız", "Lisins tipi ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Lisins tipi ekleme işlemi yapılırken bir hata oluştu");
                });
        };

        $scope.GetLicensesTypes = function () {
            LicenseTypeService.GetLicensesTypes(
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
                        toaster.error("Başarısız", "Lisans tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Lisans tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetLicensesTypes();

    }]);



