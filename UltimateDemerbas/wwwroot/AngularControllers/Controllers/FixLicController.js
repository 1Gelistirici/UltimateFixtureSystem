MainApp.controller("FixLicController", ["$scope", "FixLicService", "LicenseService", "FixtureService", "NgTableParams", "toaster", "$confirm",
    function ($scope, FixLicService, LicenseService, FixtureService, NgTableParams, toaster, $confirm) {
        $scope.TableCol = {
            License: "License",
            Fixture: "Fixture",
        };

        $scope.GetFixLices = function () {
            FixLicService.GetFixLices(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;
                        $scope.RegisterCount = $scope.Data.length;

                        //$.each(result.Data, function (index, value) {
                        //    $scope.Data.find(x => x.Id == value.Id).FixtureId = 34;
                        //    $scope.Data.find(x => x.Id == value.Id).LicanseId = 3;
                        //});
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });
                    } else {
                        toaster.error("Başarısız", "Assigned licanse listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Assigned licanse listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetFixLices();

        $scope.GetLicenses = function () {
            LicenseService.GetLicenses(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Licenses = result.Data;
                    } else {
                        toaster.error("GetLicenses", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetLicenses", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetLicenses();

        $scope.GetFixtures = function () {
            FixtureService.GetFixtures(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Fixtures = result.Data;
                    } else {
                        toaster.error("GetFixtures", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetFixtures", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetFixtures();

        function DeleteFixLic(data) {
            var parameter = {
                Id: data.Id
            }

            FixLicService.DeleteFixLic(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "FixLic silme işlemi başarılı");
                        $scope.GetFixLices();
                    } else {
                        toaster.error("Başarısız", "FixLic silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "FixLic silme işlemi yapılırken bir hata oluştu");
                });
        }




        $scope.DeleteFixLicConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { DeleteFixLic(x); });
        }

        //$scope.UpdateLicense = function (data) {
        //    LicenseService.UpdateLicense(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Update License", "Lisans güncelleme işlemi başarılı");

        //            } else {
        //                toaster.error("Update License", "Lisans güncelleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Update License", "Lisans güncelleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

        //$scope.AddLicense = function () {
        //    var data = {
        //        "Name": $scope.Pop.Name,
        //        "TypeNo": $scope.Pop.TypeNo,
        //        "Piece": $scope.Pop.Piece,
        //    }

        //    LicenseService.AddLicense(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //                $("#AddLicense").modal("hide");
        //                $scope.GetLicenses();
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });

        //}

        //$scope.SetAssign = function (x) {
        //    $scope.Assign = x;
        //}

        //$scope.GetFixtures = function () {
        //    FixtureService.GetFixtures(
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                $scope.Fixtures = result.Data.filter(x => x.CategoryNo == 1);
        //                console.log($scope.Fixtures);
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}
        //$scope.GetFixtures();

        //$scope.AddFixLic = function () {
        //    var parameter = {
        //        LicanseId: parseInt($scope.Assign.Id),
        //        FixtureId: parseInt($scope.Assign.FixturId)
        //    }

        //    FixLicService.AddFixLic(parameter,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Başarılı", "Lisans atama işlemi yapılırken bir hata oluştu");
        //                $('#LicenseAssignmentPartial').modal('hide');
        //                $scope.Data.find(x => x.Id == $scope.Assign.Id).Piece = ($scope.Assign.Piece - 1)
        //            } else {
        //                toaster.error("Başarısız", "Lisans atama işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Başarısız", "Lisans atama işlemi yapılırken bir hata oluştu");
        //        });
        //}
    }]);
