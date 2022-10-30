MainApp.controller("AccessoryModelController", ["$scope", "AccessoryModelService", "toaster", "NgTableParams",
    function ($scope, AccessoryModelService, toaster, NgTableParams) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Accessory Model Name",
        };

        $scope.GetAccessoryModels = function () {
            AccessoryModelService.GetAccessoryModels(
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
                        toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAccessoryModels();

        $scope.DeleteAccessoryModel = function (data) {
            AccessoryModelService.DeleteAccessoryModel(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Accessory model silme işlemi yapılırken bir hata oluştu");
                        $scope.GetAccessoryModels();
                    } else {
                        toaster.success("Başarısız", "Accessory model silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Accessory model silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateAccessoryModel = function (data) {
            AccessoryModelService.UpdateAccessoryModel(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Accessory model güncelleme işlemi yapılırken bir hata oluştu");
                    } else {
                        toaster.success("Başarısız", "Accessory model güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Accessory model güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddAccessoryModel = function () {
            var data = {
                "Name": $scope.Pop.Name,
            }

            AccessoryModelService.AddAccessoryModel(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Aksesuar Model", "Accessory model başarıyla eklendi");
                        $('#AddSituation').modal('hide');
                        $scope.GetAccessoryModels();
                        $scope.Pop = [];
                    } else {
                        toaster.success("Başarısız", "Accessory model ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Accessory model ekleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);
