MainApp.controller("ComponentController", ["$scope", "CategoryService", "ComponentModelService", "ComponentService", "BillService", "$http", "NgTableParams", "toaster", "$confirm",
    function ($scope, CategoryService, ComponentModelService, ComponentService, BillService, $http, NgTableParams, toaster, $confirm) {

        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Component Name",
            ModelNo: "Model",
            CategoryNo: "Category",
            Piece: "Piece",
            Price: "Price",
            BillNo: "Bill",
        };

        $scope.GetCategorys = function () {
            CategoryService.GetCategories(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Categorys = result.Data;
                    } else {
                        toaster.error("GetCategorys", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetCategorys", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetCategorys();

        $scope.GetBills = function () {
            BillService.GetBills(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Bills = result.Data;
                    } else {
                        toaster.error("GetCategorys", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetCategorys", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBills();

        $scope.GetComponentModels = function () {
            ComponentModelService.GetComponentModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Models = result.Data;
                    } else {
                        toaster.error("GetComponentModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetComponentModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetComponentModels();

        $scope.GetComponentByCompanyRefId = function () {
            ComponentService.GetComponentByCompanyRefId(
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
                        toaster.error("GetComponents", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetComponents", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetComponentByCompanyRefId();

        $scope.DeleteComponent = function (data) {
            ComponentService.DeleteComponent(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Delete", "Silme işlemi başarılıyla gerçekleşti.");
                        $scope.GetComponents();
                    } else {
                        toaster.error("DeleteComponent", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("DeleteComponent", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateComponent = function (data) {
            ComponentService.UpdateComponent(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Update", "Günvelleme işlemi başarılıyla gerçekleşti.");
                    } else {
                        toaster.error("UpdateComponent", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("UpdateComponent", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddComponent = function () {
            var data = {
                "Name": $scope.Pop.Name,
                "Piece": $scope.Pop.Piece,
                "Price": $scope.Pop.Price,
                "BillNo": $scope.Pop.BillNo,
                "ModelNo": $scope.Pop.ModelNo,
                "CategoryNo": $scope.Pop.CategoryNo
            }

            ComponentService.AddComponent(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Component", "Component başarıyla eklendi");
                        $scope.Pop = [];
                        $('#AddSituation').modal('hide');
                        $scope.GetComponents();
                    } else {
                        toaster.error("AddComponent", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddComponent", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.Refresh = function () {
            $scope.GetComponents();
        }

        $scope.SetPiece = function (x) {
            $scope.piece = x.Piece;
            $scope.Pop = [];
            $scope.Pop.piece = 0;
            $scope.Pop.Id = x.Id;
            $scope.Pop.UserName = x.Name;
            $scope.Pop.ItemType = 3; // ToDO : Enumdan çekilebilir
            $scope.Pop.recallDate = new Date();
        }

        $scope.generateQRCode = function (id) {
            downloadQRCodeV1(id, 3);
        }

        $scope.UpdateComponentConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { $scope.UpdateComponent(x); });
        }
        $scope.DeleteComponentConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { $scope.DeleteComponent(x); });
        }

    }]);
