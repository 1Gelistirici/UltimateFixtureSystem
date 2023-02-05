MainApp.controller("LicenseController", ["$scope", "LicenseService", "LicenseTypeService", "FixtureService", "FixLicService", "NgTableParams", "toaster",
    function ($scope, LicenseService, LicenseTypeService, FixtureService, FixLicService, NgTableParams, toaster) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "License Name",
            Type: "Type",
            Piece: "Piece"
        };
        //toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");

        $scope.GetLicenses = function () {
            LicenseService.GetLicenses(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;
                        $scope.tt = "1";
                        $scope.RegisterCount = $scope.Data.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });
                    } else {
                        toaster.error("GetLicenses", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetLicenses", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetLicenses();

        $scope.DeleteLicense = function (data) {
            LicenseService.DeleteLicense(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Delete License", "Lisans silme işlemi başarılı");
                        $scope.GetLicenses();
                    } else {
                        toaster.error("Delete License", "Lisans silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Delete License", "Lisans silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateLicense = function (data) {
            LicenseService.UpdateLicense(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Update License", "Lisans güncelleme işlemi başarılı");

                    } else {
                        toaster.error("Update License", "Lisans güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Update License", "Lisans güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddLicense = function () {
            var data = {
                "Name": $scope.Pop.Name,
                "TypeNo": $scope.Pop.TypeNo,
                "Piece": $scope.Pop.Piece,
            }

            LicenseService.AddLicense(data,
                function success(result) {
                    if (result.IsSuccess) {
                        //toaster.success("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                        $("#AddLicense").modal("hide");
                        $scope.GetLicenses();
                    } else {
                        toaster.error("AddLicense", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddLicense", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });

        }

        $scope.GetLicensesTypes = function () {
            LicenseTypeService.GetLicensesTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.LicenseTypes = result.Data;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });
                    } else {
                        toaster.error("GetLicensesTypes", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetLicensesTypes", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetLicensesTypes();

        $scope.SetAssign = function (x) {
            $scope.Assign = x;
        }

        $scope.GetFixtures = function () {
            FixtureService.GetFixtures(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Fixtures = result.Data.filter(x => x.CategoryNo == 1);
                    } else {
                        toaster.error("GetFixtures", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetFixtures", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetFixtures();

        $scope.AddFixLic = function () {
            var parameter = {
                LicanseId: parseInt($scope.Assign.Id),
                FixtureId: parseInt($scope.Assign.FixturId)
            }

            FixLicService.AddFixLic(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Lisans atama işlemi yapılırken bir hata oluştu");
                        $('#LicenseAssignmentPartial').modal('hide');
                        $scope.Data.find(x => x.Id == $scope.Assign.Id).Piece = ($scope.Assign.Piece - 1)
                    } else {
                        toaster.error("Başarısız", "Lisans atama işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Lisans atama işlemi yapılırken bir hata oluştu");
                });
        }
    }]);
