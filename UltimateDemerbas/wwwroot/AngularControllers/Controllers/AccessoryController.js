MainApp.controller("AccessoryController", ["$scope", "AccessoryService", "CategoryService", "AccessoryModelService", "BillService", "NgTableParams", "toaster", "$confirm",
    function ($scope, AccessoryService, CategoryService, AccessoryModelService, BillService, NgTableParams, toaster, $confirm) {

        $scope.RegisterCount = 0;
        $scope.TableCol = {
            Name: "Component Name",
            ModelNo: "Model",
            CategoryNo: "Category",
            Piece: "Piece",
            Price: "Price",
            BillNo: "Bill",
        };

        $scope.GetBills = function () {
            BillService.GetBills(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Bills = result.Data;
                    } else {
                        toaster.error("GetCategories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetCategories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBills();

        $scope.GetCategories = function () {
            CategoryService.GetCategories(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Categories = result.Data;
                    } else {
                        toaster.error("GetCategories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetCategories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetCategories();

        $scope.GetAccessoryModels = function () {
            AccessoryModelService.GetAccessoryModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.AccessoryModels = result.Data;
                    } else {
                        toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAccessoryModels();

        $scope.GetAccessories = function () {
            AccessoryService.GetAccessories(
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
                        toaster.error("GetAccessories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetAccessories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAccessories();

        $scope.DeleteAccessory = function (data) {
            AccessoryService.DeleteAccessory(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Refresh();
                        toaster.success("Aksesuar Silindi", "Aksesuar silme işlemi başarılı")
                    } else {
                        toaster.error("DeleteAccessory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("DeleteAccessory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateAccessory = function (data) {
            AccessoryService.UpdateAccessory(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Kayıt güncellendi.");
                    }
                    else {
                        toaster.error("UpdateAccessory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("UpdateAccessory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddAccessory = function () {
            var data = {
                "Name": $scope.Pop.Name,
                "Piece": $scope.Pop.Piece,
                "Price": $scope.Pop.Price,
                "BillNo": $scope.Pop.BillNo,
                "ModelNo": $scope.Pop.ModelNo,
                "CategoryNo": $scope.Pop.CategoryNo
            }

            AccessoryService.AddAccessory(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Aksesuar Ekleme", "Aksesuar başarıyla eklendi");
                        $('#AddSituation').modal('hide');
                        $scope.Pop = [];
                        $scope.Refresh();
                    } else {
                        toaster.error("AddAccessory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddAccessory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.Refresh = function () {
            $scope.GetAccessories();
        }

        $scope.SetPiece = function (x) {
            $scope.piece = x.Piece;
            $scope.Pop = [];
            $scope.Pop.piece = 0;
            $scope.Pop.Price = 0;
            $scope.Pop.Id = x.Id;
            $scope.Pop.UserName = x.Name;
            $scope.Pop.ItemType = 2; // ToDO : Enumdan çekilebilir
        }

        $scope.UpdateAccessoryConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { $scope.UpdateAccessory(x); });
        }
        $scope.DeleteAccessoryConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { $scope.DeleteAccessory(x); });
        }

    }]);
