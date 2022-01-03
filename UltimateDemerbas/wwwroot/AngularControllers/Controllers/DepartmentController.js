MainApp.controller("DepartmentController", ["$scope", "DepartmentService", "toaster", "NgTableParams",
    function ($scope, DepartmentService, toaster, NgTableParams) {
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
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
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

        //$scope.UpdateBillType = function (data) {
        //    DepartmentService.UpdateBillType(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Başarılı", "Bill type güncelleme işlemi yapılırken bir hata oluştu");
        //            } else {
        //                toaster.success("Başarısız", "Bill type güncelleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.success("Başarısız", "Bill type güncelleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

        //$scope.AddBillType = function () {
        //    var data = {
        //        "Name": $scope.Pop.Name,
        //    }

        //    DepartmentService.AddBillType(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Başarılı", "Bill type ekleme işlemi yapılırken bir hata oluştu");
        //                $('#AddSituation').modal('hide');
        //                $scope.GetBillTypes();
        //            } else {
        //                toaster.success("Başarısız", "Bill type ekleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.success("Başarısız", "Bill type ekleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

    }]);
