MainApp.controller("FixtureModelController", ["$scope", "FixtureModelService", "toaster", "NgTableParams", "$confirm",
    function ($scope, FixtureModelService, toaster, NgTableParams, $confirm) {
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
                        toaster.error("GetFixtureModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetFixtureModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetSituations();

        $scope.DeleteFixtureModel = function (data) {
            FixtureModelService.DeleteFixtureModel(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Fixture model silme işlemi yapılırken bir hata oluştu");
                        $scope.GetSituations();
                    } else {
                        toaster.success("Başarısız", "Fixture model silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Fixture model silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateFixtureModel = function (data) {
            FixtureModelService.UpdateFixtureModel(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Fixture model güncelleme işlemi yapılırken bir hata oluştu");
                    } else {
                        toaster.error("Başarısız", "Fixture model güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fixture model güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddFixtureModel = function () {

            var data = {
                "Name": $scope.Pop.Name,
            }

            FixtureModelService.AddFixtureModel(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Fixture model ekleme işlemi yapılırken bir hata oluştu");
                        $('#AddSituation').modal('hide');
                        $scope.GetSituations();
                    } else {
                        toaster.error("Başarısız", "Fixture model ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fixture model ekleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.openAddPopup = function () {
            $scope.Pop = [];
        }

        $scope.UpdateFixtureModelConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { $scope.UpdateFixtureModel(x); });
        }
        $scope.DeleteFixtureModelConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { $scope.DeleteFixtureModel(x); });
        }

    }]);
