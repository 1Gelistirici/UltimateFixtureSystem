MainApp.controller("TonerController", ["$scope", "TonerService", "UsedTonerService", "DepartmentService", "NgTableParams", "toaster", "$confirm",
    function ($scope, TonerService, UsedTonerService, DepartmentService, NgTableParams, toaster, $confirm) {

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
                            $scope.Data.filter(x => x.Id === value.Id)[0].InsertDate = new Date(value.InsertDate).toLocaleString();
                        });

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

        function deleteUsedToner(data) {
            UsedTonerService.DeleteUsedToner(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetUsedToner();
                        $scope.GetToners();
                        toaster.success("Başarılı", "Toner silindi.");
                    } else {
                        toaster.error("Başarısız", "Toner silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Toner silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddUsedToner = function () {

            if ($scope.Pop.AssignPiece > $scope.Toners.filter(x => x.Id === $scope.Pop.TonerId)[0].NewPiece) {
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
                        $scope.GetToners();
                        toaster.success("Başarılı", "UsedToner  eklendi.");
                    } else {
                        toaster.error("Başarısız", "UsedToner ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "UsedToner  ekleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateUsedToner = function (data) {

            var piece = data.NewPiece - data.Piece;

            if (!Number.isInteger(piece)) {
                piece = data.Piece;
            }
            if (data.NewPiece === undefined) {
                data.NewPiece = data.Piece;
            }

            if (piece > $scope.Toners.filter(x => x.Id === data.TonerNo)[0].Piece) {
                toaster.warning("Başarısız", "Toner sayısı yetersiz");
                return;
            }

            var parameter = {
                Id: data.Id,
                Piece: parseInt(data.NewPiece),
                DepartmentNo: data.DepartmentNo,
                TonerNo: data.TonerNo
            }

            UsedTonerService.UpdateUsedToner(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetUsedToner();
                        $scope.GetToners();
                        toaster.success("Başarılı", "UsedToner  eklendi.");
                    } else {
                        toaster.error("Başarısız", "UsedToner ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "UsedToner  ekleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.deleteUsedTonerConfirm = function (parameter) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz? Ürün silindikden sonra ürün tutarı fatura tutarından düşülecektir.", function () { deleteUsedToner(parameter); });
        }

    }]);