MainApp.controller("FixtureController", ["$scope", "CategoryService", "FixtureModelService", "FixtureService", "BillService", "AssignmentService", "UserService", "EnumService", "NgTableParams", "toaster", "$confirm",
    function ($scope, CategoryService, FixtureModelService, FixtureService, BillService, AssignmentService, UserService, EnumService, NgTableParams, toaster, $confirm,) {

        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Fixture Name",
            Model: "Model",
            Category: "Category",
            Bill: "Bill",
            Statu: "Statu",
            User: "User",
            SerialNumber: "Serial Number",
        };

        $scope.openPopup = function () {
            $scope.Pop = [];
            $scope.Pop.recallDate = new Date();
        }

        $scope.viewItem = function (id) {
            var url = `/Fixture/ViewItem?id= + ${id}`;
            window.open(url, "_blank");
        }

        $scope.ItemStatus = [];
        $scope.ItemStatusFilter = [];
        //Enum ItemStatu
        $scope.GetItemStatuTypes = function () {
            EnumService.GetItemStatuTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.ItemStatus = result.Data;
                        $scope.ItemStatus = $scope.ItemStatus.filter(_ => _.Value !== 0);

                        $.each($scope.ItemStatus, function (index, value) {
                            var parameter = { id: value.Value, title: value.Text };
                            $scope.ItemStatusFilter.push(parameter);
                        });
                    } else {
                        toaster.error("GetItemStatuTypes", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetItemStatuTypes", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetItemStatuTypes();

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

        $scope.GetFixtureModels = function () {
            FixtureModelService.GetFixtureModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.FixtureModels = result.Data;
                    } else {
                        toaster.error("GetFixtureModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetFixtureModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetFixtureModels();

        $scope.GetBills = function () {
            BillService.GetBills(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Bills = result.Data;
                    } else {
                        toaster.error("GetBills", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetBills", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBills();

        $scope.GetUsers = function () {
            UserService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                    } else {
                        toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUsers();

        $scope.GetFixtureByCompanyRefId = function () {
            FixtureService.GetFixtureByCompanyRefId(
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
                        toaster.error("GetFixtures", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetFixtures", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetFixtureByCompanyRefId();

        function DeleteFixture(data) {
            FixtureService.DeleteFixture(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        RefreshData();
                        toaster.success("Başarlı", "Demirbaş başarıyla silinmiştir.");
                    } else {
                        toaster.error("DeleteFixture", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("DeleteFixture", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        function UpdateFixture(parameter) {
            FixtureService.UpdateFixture(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Demirbaş başarıyla güncellenmiştir.");
                    } else {
                        toaster.error("UpdateFixture", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("UpdateFixture", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddFixture = function () {
            var parameter = {
                "Name": $scope.Pop.Name,
                "ModelNo": $scope.Pop.ModelNo,
                "BillNo": $scope.Pop.BillNo,
                "StatuNo": $scope.Pop.StatuNo,
                "CategoryNo": $scope.Pop.CategoryNo,
                "UserNo": $scope.Pop.UserNo,
                "SerialNumber": $scope.Pop.SerialNumber
            }

            FixtureService.AddFixture(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        //$scope.Data.push(parameter);
                        if ($scope.Pop.StatuNo === 3) {
                            var parameter = {
                                UserId: $scope.Pop.UserNo,
                                RecallDate: $scope.Pop.recallDate,
                                ItemType: 4, // ToDo : Enumdan çekilebilir
                                ItemId: result.Data,
                                IsRecall: $scope.Pop.checkRecallDate,
                            }

                            addAssignment(parameter);
                        }

                        RefreshData();
                        toaster.success("Başarılı", "Demirbaş başarıyla eklenmiştir.");
                        $("#AddFixturePopup").modal("hide");
                        $scope.Pop = [];
                    } else {
                        toaster.error("AddFixture", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddFixture", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        RefreshData = function () {
            $scope.GetFixtures();
        }

        $scope.SetAssign = function (x) {
            $scope.Assign = x;
            $scope.Assign.recallDate = new Date();
        }

        $scope.AssignFixture = function () {
            if ($scope.Assign.checkRecallDate === undefined) {
                $scope.Assign.checkRecallDate = false;
            }

            var parameter = {
                UserId: parseInt($scope.Assign.user),
                RecallDate: $scope.Assign.recallDate,
                ItemType: 4, // ToDo : Enumdan çekilebilir
                ItemId: $scope.Assign.Id,
                IsRecall: $scope.Assign.checkRecallDate,
            }

            addAssignment(parameter);

        }

        function addAssignment(parameter) {
            AssignmentService.AddAssignment(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $('#FixtureAssignmentPopup').modal('hide');
                        RefreshData();
                    } else {
                        toaster.error("AddAssignment", result.Message);
                    }
                }, function error() {
                    toaster.error("AddAssignment", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.Refresh = function () {
            $scope.GetFixtures();
        }


        $scope.UpdateFixtureConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { UpdateFixture(x); });
        }
        $scope.DeleteFixtureConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { DeleteFixture(x); });
        }

    }]);
