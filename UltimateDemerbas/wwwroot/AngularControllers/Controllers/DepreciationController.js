MainApp.controller("DepreciationController", ["$scope", "DepartmentService", "toaster", "NgTableParams", "$confirm",
    function ($scope, DepartmentService, toaster, NgTableParams, $confirm) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Departman Name",
        };

        $scope.GetDepartments = function () {
            DepartmentService.GetDepartments(
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
                        toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetDepartments();

        $scope.DeleteDepartment = function (data) {
            DepartmentService.DeleteDepartment(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Departman silme işlemi yapılırken bir hata oluştu");
                        $scope.GetDepartments();
                    } else {
                        toaster.error("Başarısız", "Departman silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Departman silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateDepartment = function (data) {
            DepartmentService.UpdateDepartment(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Departman güncelleme işlemi yapılırken bir hata oluştu");
                    } else {
                        toaster.error("Başarısız", "Departman güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Departman güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddDepartment = function () {
            var data = {
                "Name": $scope.Pop.Name,
            }

            DepartmentService.AddDepartment(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Departman ekleme işlemi yapılırken bir hata oluştu");
                        $('#AddDepartment').modal('hide');
                        $scope.GetDepartments();
                        $scope.Pop = [];
                    } else {
                        toaster.error("Başarısız", "Departman ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Departman ekleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.openAddPopup = function () {
            $scope.Pop = [];
        }

        $scope.UpdateDepartmentConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { $scope.UpdateDepartment(x); });
        }
        $scope.DeleteDepartmentConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { $scope.DeleteDepartment(x); });
        }

    }]);
