MainApp.controller("BillTypeController", ["$scope", "BillTypeService", "toaster", "NgTableParams", "$confirm",
    function ($scope, BillTypeService, toaster, NgTableParams, $confirm) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Bill Type Name",
        };

        $scope.GetBillTypes = function () {
            BillTypeService.GetBillTypes(
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
                        toaster.error("GetBillTypes", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetBillTypes", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBillTypes();

        $scope.DeleteBillType = function (data) {
            BillTypeService.DeleteBillType(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Bill type silme işlemi yapılırken bir hata oluştu");
                        $scope.GetBillTypes();
                    } else {
                        toaster.success("Başarısız", "Bill type silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Bill type silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateBillType = function (data) {
            BillTypeService.UpdateBillType(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Bill type güncelleme işlemi yapılırken bir hata oluştu");
                    } else {
                        toaster.success("Başarısız", "Bill type güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Bill type güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddBillType = function () {
            var data = {
                "Name": $scope.Pop.Name,
            }

            BillTypeService.AddBillType(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Bill type ekleme işlemi yapılırken bir hata oluştu");
                        $('#AddSituation').modal('hide');
                        $scope.GetBillTypes();
                        $scope.Pop = [];
                    } else {
                        toaster.success("Başarısız", "Bill type ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Bill type ekleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateBillTypeConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { $scope.UpdateBillType(x); });
        }
        $scope.DeleteBillTypeConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { $scope.DeleteBillType(x); });
        }

    }]);
