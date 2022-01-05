MainApp.controller("TonerController", ["$scope", "TonerService", "UsedTonerService", "DepartmentService", "NgTableParams", "toaster",
    function ($scope, TonerService, UsedTonerService, DepartmentService, NgTableParams, toaster) {

        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Piece: "Piece",
            Toner: "Toner",
            Department: "Department",
            InsertDate: "Insert Date",
        };

        $scope.GetToners = function () {
            TonerService.GetToners(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Toners = result.Data;
                    } else {
                        toaster.error("Toner listeleme", "Toner listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Toner listeleme", "Toner listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetToners();

        $scope.GetUsedToner = function () {
            UsedTonerService.GetUsedToner(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;

                        $.each($scope.Data, function (index, value) {
                            $scope.Data.filter(x => x.Id == value.Id)[0].InsertDate = new Date(value.InsertDate).toLocaleString();
                        });
                        console.log($scope.Data);

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
        $scope.GetUsedToner();

        $scope.GetDepartments = function () {
            DepartmentService.GetDepartments(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Departments = result.Data;
                    } else {
                        toaster.error("Toner listeleme", "Toner listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Toner listeleme", "Toner listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetDepartments();

        $scope.DeleteUsedToner = function (data) {
            UsedTonerService.DeleteUsedToner(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetUsedToner();
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

        $scope.AddUsedToner = function () {

            if ($scope.Pop.AssignPiece > $scope.Toners.filter(x => x.Id == $scope.Pop.TonerId)[0].Piece) {
                toaster.warning("Başarısız", "Toner sayısı yetersiz");
                return;
            }

            var parameter = {
                Piece: $scope.Pop.AssignPiece,
                DepartmentNo: $scope.Pop.DepartmentId,
                TonerNo: $scope.Pop.TonerId
            }

            UsedTonerService.AddUsedToner(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $('#AddUsedTonerPopup').modal('hide');
                        $scope.Pop = [];
                        $scope.GetUsedToner();
                        toaster.success("Başarılı", "UsedToner  eklendi.");
                    } else {
                        toaster.error("Başarısız", "UsedToner ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "UsedToner  ekleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);