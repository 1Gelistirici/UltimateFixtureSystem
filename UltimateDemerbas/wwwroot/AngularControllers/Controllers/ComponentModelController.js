MainApp.controller("ComponentModelController", ["$scope", "ComponentModelService", "toaster", "NgTableParams", "$confirm",
    function ($scope, ComponentModelService, toaster, NgTableParams, $confirm) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Component Model Name",
        };

        $scope.GetComponentModels = function () {
            ComponentModelService.GetComponentModels(
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
                        toaster.error("GetComponentModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetComponentModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetComponentModels();

        $scope.DeleteComponentModel = function (data) {
            ComponentModelService.DeleteComponentModel(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Component model silme işlemi başarılı");
                        $scope.GetComponentModels();
                    } else {
                        toaster.success("Başarısız", "Component model silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Component model silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateComponentModel = function (data) {
            ComponentModelService.UpdateComponentModel(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Component model güncelleme işlemi başarılı");
                    } else {
                        toaster.success("Başarısız", "Component model güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Component model güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddComponentModel = function () {
            var data = {
                "Name": $scope.Pop.Name,
            }

            ComponentModelService.AddComponentModel(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Component model ekleme işlemi başarılı");
                        $('#AddSituation').modal('hide');
                        $scope.GetComponentModels();
                        $scope.Pop = [];
                    } else {
                        toaster.success("Başarısız", "Component model ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Component model ekleme işlemi yapılırken bir hata oluştu");
                });
        }


        $scope.UpdateComponentModelConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { $scope.UpdateComponentModel(x); });
        }
        $scope.DeleteComponentModelConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { $scope.DeleteComponentModel(x); });
        }

    }]);
