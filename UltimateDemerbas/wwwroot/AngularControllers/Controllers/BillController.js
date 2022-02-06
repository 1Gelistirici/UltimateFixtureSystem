MainApp.controller("BillController", ["$scope", "BillService", "BillTypeService", "EnumService", "CategoryService", "FixtureService", "FixtureModelService", "ComponentModelService", "AccessoryModelService", "NgTableParams", "toaster",
    function ($scope, BillService, BillTypeService, EnumService, CategoryService, FixtureService, FixtureModelService, ComponentModelService, AccessoryModelService, NgTableParams, toaster) {

        $scope.RegisterCount = 0;
        $scope.Pop = [];
        $scope.Added = [];
        $scope.AddedData = [];

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
        var ProductType = [{ Fixture=0 }, { Accessory=1 }, { Toner=2 }, { Component=3 }]

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
                        console.log($scope.Data);
                        $.each($scope.Data, function (index, value) {
                            $scope.Data[index].BillDate = new Date($scope.Data[index].BillDate);
                            $scope.Data[index].InsertDate = new Date($scope.Data[index].InsertDate);
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
                        toaster.success("Başarılı", "Fatura silindi.")
                    } else {
                        toaster.error("Başarısız", "Fatura silme işlemi yapılırken bir hata oluştu");
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

        $scope.AddBill = function (price) {
            var data = {
                "BillNo": $scope.Pop.BillNo,
                "BillDate": $scope.Pop.BillDate,
                "Price": price,
                "Comment": $scope.Pop.Comment,
                "Department": $scope.Pop.Department
            }

            BillService.AddBill(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Fatura kaydedildi.");
                    } else {
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
            } else if ($scope.Added.ProductTypeNo === 1) {
                $scope.GetAccessoryModels();
            } else if ($scope.Added.ProductTypeNo === 2) {
                //ToDo ne yapılacağı kararlaştırılacak
            } else if ($scope.ProductTypeNo === 3) {
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

            console.log($scope.AddedData);
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

        $scope.DeleteAddedBill = function (addedId) {
            $scope.AddedData = $scope.AddedData.filter(x => x.Id != addedId);

            console.log($scope.AddedData);
            $scope.PopupRegisterCount = $scope.AddedData.length;
            $scope.PopupTableParams = new NgTableParams({
                sorting: { name: 'adc' },
                count: 20
            }, {
                counts: [10, 20, 50],
                dataset: $scope.AddedData
            });
        }

        $scope.Save = function () {
            var price = 0;

            $.each($scope.AddedData, function (index, value) {
                console.log(value);

                if (value.ProductTypeNo === ProductType.Fixture) {

                } else if (value.ProductTypeNo === ProductType.Accessory) {

                } else if (value.ProductTypeNo === ProductType.Toner) {

                } else if (value.ProductTypeNo === ProductType.Component) {

                }

                price += value.Price;
            });


            return;

            $scope.AddBill(price);


        }



        $scope.AddBill = function () {
            var data = {
                "BillNo": $scope.Pop.BillNo,
                "BillDate": $scope.Pop.BillDate,
                "Price": price,
                "Comment": $scope.Pop.Comment,
                "Department": $scope.Pop.Department
            }

            console.log(data);
            return;

            BillService.AddBill(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Fatura kaydedildi.");
                    } else {
                        toaster.error("Başarısız", "Fatura ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura ekleme işlemi yapılırken bir hata oluştu");
                });
        }




    }]);