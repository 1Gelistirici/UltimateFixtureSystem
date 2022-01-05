MainApp.controller("TonerController", ["$scope", "TonerService", "UsedTonerService", "DepartmentService", "NgTableParams", "toaster",
    function ($scope, TonerService, UsedTonerService, DepartmentService, NgTableParams, toaster) {

        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Model Name",
            Piece: "Piece",
            Boundary: "Boundary",
            Price: "Price",
            MinStock: "Min Stock",
        };

        $scope.GetToners = function () {
            TonerService.GetToners(
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
                        toaster.error("Toner listeleme", "Toner listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Toner listeleme", "Toner listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetToners();

        $scope.GetDepartments = function () {
            DepartmentService.GetDepartments(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Departments = result.Data;
                        console.log("123", $scope.Departments);
                    } else {
                        toaster.error("Toner listeleme", "Toner listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Toner listeleme", "Toner listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetDepartments();

        $scope.DeleteToner = function (data) {
            TonerService.DeleteToner(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Toner silindi.");
                    } else {
                        toaster.error("Başarısız", "Toner silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Toner silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateToner = function (data) {
            TonerService.UpdateToner(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Toner güncellendi.");
                    } else {
                        toaster.error("Başarısız", "Toner güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Toner güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddToner = function () {
            var data = {
                "Name": $scope.Pop.Name,
                "Piece": $scope.Pop.Piece,
                "Boundary": $scope.Pop.Boundary,
                "Price": $scope.Pop.Price
            }

            TonerService.AddToner(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Toner eklendi.");
                    } else {
                        toaster.error("Başarısız", "Toner ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Toner ekleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.SetAssign = function (data) {
            $scope.Pop = data;
        }

        $scope.AddUsedToner = function () {
            var parameter = {
                TonerNo: $scope.Pop.Id,
                DepartmentNo: $scope.Pop.DepartmentId,
                Piece: $scope.Pop.AssignPiece
            }

            UsedTonerService.AddUsedToner(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $('#AddUsedTonerPopup').modal('hide');
                        $scope.Pop = [];
                        $scope.GetToners();
                        toaster.success("Başarılı", "UsedToner  eklendi.");
                    } else {
                        toaster.error("Başarısız", "UsedToner ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "UsedToner  ekleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);