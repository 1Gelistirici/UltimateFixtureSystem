MainApp.controller("BillController", ["$scope", "BillService", "BillTypeService", "EnumService", "CategoryService", "FixtureService", "FixtureModelService", "ComponentService", "ComponentModelService", "AccessoryService", "AccessoryModelService", "NgTableParams", "toaster", "$confirm",
    function ($scope, BillService, BillTypeService, EnumService, CategoryService, FixtureService, FixtureModelService, ComponentService, ComponentModelService, AccessoryService, AccessoryModelService, NgTableParams, toaster, $confirm) {

        $scope.RegisterCount = 0;
        $scope.Pop = [];
        $scope.Pop.BillDate = new Date();
        $scope.Added = [];
        $scope.AddedData = [];
        $scope.addPopupBillItemData = [];

        $scope.TableCol = {
            BillNo: "Bill No",
            BillDate: "Bill Date",
            InsertDate: "Insert Date",
            Price: "Price",
            Comment: "Comment",
            Department: "Department",
            Items: "Items",
        };
        $scope.PopupTableCol = {
            Name: "Name",
            Piece: "Piece",
            Price: "Price",
            ProductType: "ProductType",
            Model: "Model",
            Category: "Category",
        };
        var ProductType = { Fixture: 0, Accessory: 1, Toner: 2, Component: 3 }

        //#region Bill Events
        $scope.GetBillTypes = function () {
            BillTypeService.GetBillTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.BillTypes = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBillTypes();

        $scope.GetBills = function () {
            BillService.GetBills(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;
                        $.each($scope.Data, function (index, value) {
                            $scope.Data[index].BillDate = new Date($scope.Data[index].BillDate);
                            $scope.Data[index].InsertDate = new Date($scope.Data[index].InsertDate);
                        });

                        $scope.bills = $scope.Data;

                        $scope.RegisterCount = $scope.Data.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });
                    } else {
                        toaster.error("Başarısız", "Faturalisteleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Faturalisteleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBills();

        $scope.DeleteBill = function (data) {
            BillService.DeleteBill(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetBills();
                        toaster.success("Başarılı", "Fatura silindi.")
                    } else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateBill = function (data) {
            BillService.UpdateBill(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Fatura güncellendi.");
                    } else {
                        toaster.error("Başarısız", "Fatura güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddBill = function () {
            price = 0;
            var items = [];

            $.each($scope.AddedData, function (index, value) {
                items.push({
                    Id: value.Id
                    , Name: value.Name
                    , Piece: value.Piece
                    , Price: value.Price
                    , ProductType: value.ProductTypeNo
                    , ModelRefId: value.Model ? value.Model.Id : 0
                    , CategoryRefId: value.CategoryNo
                });

                price += value.Price * value.Piece;
            });

            var data = {
                "BillNo": $scope.Pop.BillNo,
                "BillDate": $scope.Pop.BillDate,
                "Price": price,
                "Comment": $scope.Pop.Comment,
                "Department": $scope.Pop.Department,
                "Items": items
            }

            BillService.AddBill(data,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.InsertedId = result.Data[0].Id;
                        //$scope.Save();
                        $scope.GetBills();
                        toaster.success("Başarılı", "Fatura kaydedildi.");
                        $("#AddBillDetail").modal("hide");
                        $("#AddBill").modal("hide");
                        $scope.Added = [];
                        $scope.Pop = [];
                        $scope.Pop.BillDate = new Date();
                    }
                    else {
                        toaster.error("Başarısız", "Fatura ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura ekleme işlemi yapılırken bir hata oluştu");
                });
        }
        //#endregion

        //Popup

        //#region Get Enums
        $scope.GetDepartments = function () {
            EnumService.GetDepartments(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Departments = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetDepartments();

        $scope.GetProductTypes = function () {
            EnumService.GetProductTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.ProductTypes = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetProductTypes();

        $scope.GetCategories = function () {
            CategoryService.GetCategories(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Categories = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetCategories();

        $scope.GetCategories = function () {
            CategoryService.GetCategories(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Categories = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetCategories();
        //#endregion

        //#region Get Models
        $scope.GetFixtureModels = function () {
            FixtureModelService.GetFixtureModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Models = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAccessoryModels = function () {
            AccessoryModelService.GetAccessoryModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Models = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetComponentModels = function () {
            ComponentModelService.GetComponentModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Models = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        //#endregion

        $scope.GetModal = function () {
            $scope.Models = [];

            if ($scope.Added.ProductTypeNo === 0) {
                $scope.GetFixtureModels();
            }
            else if ($scope.Added.ProductTypeNo === 1) {
                $scope.GetAccessoryModels();
            }
            else if ($scope.Added.ProductTypeNo === 2) {
                //ToDo ne yapılacağı kararlaştırılacak
            }
            else if ($scope.Added.ProductTypeNo === 4) {
                $scope.GetComponentModels();
            }
        }
        $scope.GetModalBillItem = function () {
            $scope.Models = [];

            if ($scope.addPopupBillItemData.ProductTypeNo === 0) {
                $scope.GetFixtureModels();
            }
            else if ($scope.addPopupBillItemData.ProductTypeNo === 1) {
                $scope.GetAccessoryModels();
            }
            else if ($scope.addPopupBillItemData.ProductTypeNo === 2) {
                //ToDo ne yapılacağı kararlaştırılacak
            }
            else if ($scope.addPopupBillItemData.ProductTypeNo === 4) {
                $scope.GetComponentModels();
            }
        }

        id = 0;
        $scope.AddNewItem = function () {
            id++;
            var parameter = {
                Id: id,
                Name: $scope.Added.Name,
                Piece: $scope.Added.Piece,
                Price: $scope.Added.Price,
                ProductTypeNo: $scope.Added.ProductTypeNo,
                Model: $scope.Added.Model,
                CategoryNo: $scope.Added.CategoryNo,
            };

            $scope.AddedData.push(parameter);

            $scope.PopupRegisterCount = $scope.AddedData.length;
            $scope.PopupTableParams = new NgTableParams({
                sorting: { name: 'adc' },
                count: 20
            }, {
                counts: [10, 20, 50],
                dataset: $scope.AddedData
            });

            $scope.Added = [];
        }

        function DeleteBillItem(parameter) {
            BillService.DeleteBillItem(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Silme işlemi başarıyla gerçekleştirildi.");

                        $scope.selectedBill.Price -= parameter.Price;
                        $scope.selectedBill.Items = $scope.selectedBill.Items.filter(x => x.Id !== parameter.Id);
                        loadBillItemsTable($scope.selectedBill.Items);
                    } else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmeyen bir hata oluştu.");
                });
        }

        function loadBillItemsTable(data) {

            $scope.BillItemTableCount = data.length;
            $scope.BillItemTableParams = new NgTableParams({
                sorting: { name: 'adc' },
                count: 5
            }, {
                counts: [5, 10, 50],
                dataset: data
            });
        }

        $scope.Save = function () {
            $.each($scope.AddedData, function (index, value) {

                if (value.ProductTypeNo === ProductType.Fixture) {
                    var parameter = {
                        "Name": value.Name,
                        "StatuNo": 1,
                        "UserNo": 0,
                        "Price": value.Price,
                        "BillNo": $scope.InsertedId,
                        "ModelNo": value.Model.Id,
                        "CategoryNo": value.CategoryNo
                    }

                    for (var i = 0; i < value.Piece; i++) {
                        $scope.AddFixture(parameter);
                    }
                } else if (value.ProductTypeNo === ProductType.Accessory) {
                    var parameter = {
                        "Name": value.Name,
                        "Piece": value.Piece,
                        "Price": value.Price,
                        "BillNo": $scope.InsertedId,
                        "ModelNo": value.Model.Id,
                        "CategoryNo": value.CategoryNo
                    }

                    $scope.AddAccessory(parameter);

                }
                //else if (value.ProductTypeNo === ProductType.Toner) {

                //}
                else if (value.ProductTypeNo === ProductType.Component) {
                    var parameter = {
                        "Name": value.Name,
                        "Piece": value.Piece,
                        "Price": value.Price,
                        "BillNo": $scope.InsertedId,
                        "ModelNo": value.Model.Id,
                        "CategoryNo": value.CategoryNo
                    }

                    $scope.AddComponent(parameter);
                }

                //$scope.DeleteAddedBill(value.Id);

            });
        }

        //#region Add Item
        $scope.AddFixture = function (parameter) {
            FixtureService.AddFixture(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Demirbaş Ekleme", "Demirbaş başarıyla eklenmiştir.");
                    } else {
                        toaster.error("Demirbaş Ekleme", "Demirbaş ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Demirbaş Ekleme", "Demirbaş ekleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.AddAccessory = function (parameter) {
            AccessoryService.AddAccessory(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Aksesuar Ekleme", "Aksesuar başarıyla eklendi");
                    } else {
                        toaster.error("Aksesuar Ekleme", "Aksesuar ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Aksesuar Ekleme", "Aksesuar ekleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.AddComponent = function (parameter) {
            ComponentService.AddComponent(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Component Ekleme", "Component başarıyla eklendi");
                    } else {
                        toaster.error("Component Ekleme", "Component ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Component Ekleme", "Component ekleme işlemi yapılırken bir hata oluştu");
                });
        }
        //#endregion

        //#regionAdd Bill Item
        $scope.addNewBillItem = function () {
            var parameter = {
                Name: $scope.addPopupBillItemData.Name,
                Piece: $scope.addPopupBillItemData.Piece,
                Price: $scope.addPopupBillItemData.Price,
                ProductTypeNo: $scope.addPopupBillItemData.ProductTypeNo,
                ModelRefId: $scope.addPopupBillItemData.ModelRefId,
                CategoryRefId: $scope.addPopupBillItemData.CategoryRefId,
                BillRefId: $scope.selectedBill.Id,
            };
            AddBillItem(parameter);
        }

        function AddBillItem(parameter) {
            BillService.AddBillItem(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetBills();

                        setTimeout(function () {
                            $scope.selectedBill = $scope.bills.find(x => x.Id === $scope.selectedBill.Id);
                            loadBillItemsTable($scope.selectedBill.Items);
                        }, 1000);

                        $scope.addPopupBillItemData = [];
                        toaster.success("Başarılı", "Ürün başarıyla eklendi.");
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmeyen bir hata oluştu.");
                });
        }
        //#endregion

        $scope.GetItems = function (bill) {
            $scope.selectedBill = bill;

            if (!bill.Items) {
                toaster.error("Faturaya ait bilgi bulunamadı.");
                return;
            }
            loadBillItemsTable(bill.Items);
        }

        $scope.UpdateBillConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { $scope.UpdateBill(x); });
        }
        $scope.DeleteBillConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { $scope.DeleteBill(x); });
        }
        $scope.DeleteBillItemConfirm = function (parameter) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz? Ürün silindikden sonra ürün tutarı fatura tutarından düşülecektir.", function () { DeleteBillItem(parameter); });
        }


    }]);