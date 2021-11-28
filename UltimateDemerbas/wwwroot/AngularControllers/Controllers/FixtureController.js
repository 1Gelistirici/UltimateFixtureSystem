﻿MainApp.controller("FixtureController", ["$scope", "CategoryService", "FixtureModelService", "FixtureService", "BillService", "AssignmentService", "UserService", "NgTableParams", "toaster",
    function ($scope, CategoryService, FixtureModelService, FixtureService, BillService, AssignmentService, UserService, NgTableParams, toaster,) {

        $scope.test = null;

        $scope.RegisterCount = 0;

        $scope.TableCol = {
            Name: "Fixture Name",
            Model: "Model",
            Category: "Category",
            Bill: "Bill",
            Statu: "Statu",
            User: "User",
        };

        // ToDo : Enumdan çekilecek
        $scope.ItemStatus = [
            { Name: 'Ready', Id: 1 },
            { Name: 'NotReady', Id: 2 },
            { Name: 'Assigned', Id: 3 }
        ]

        $scope.GetCategories = function () {
            CategoryService.GetCategories(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Categories = result.Data;
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetCategories();

        $scope.GetFixtureModels = function () {
            FixtureModelService.GetFixtureModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.FixtureModels = result.Data;
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetFixtureModels();

        $scope.GetBills = function () {
            BillService.GetBills(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Bills = result.Data;
                        console.log($scope.Bills);
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBills();

        $scope.GetUsers = function () {
            UserService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUsers();

        $scope.GetFixtures = function () {
            FixtureService.GetFixtures(
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
        $scope.GetFixtures();

        $scope.DeleteFixture = function (data) {
            FixtureService.DeleteFixture(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        RefreshData();
                        toaster.success("Başarlı", "Demirbaş başarıyla silinmiştir.");
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateFixture = function (parameter) {
            FixtureService.UpdateFixture(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Demirbaş başarıyla güncellenmiştir.");
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddFixture = function () {
            var parameter = {
                "Name": $scope.Pop.Name,
                "ModelNo": $scope.Pop.ModelNo,
                "BillNo": $scope.Pop.BillNo,
                "StatuNo": $scope.Pop.StatuNo,
                "CategoryNo": $scope.Pop.CategoryNo,
                "UserNo": $scope.Pop.UserNo
            }

            FixtureService.AddFixture(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data.push(parameter);
                        RefreshData();
                        toaster.success("Başarılı", "Demirbaş başarıyla eklenmiştir.");
                        $("#AddFixturePopup").modal("hide");
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        RefreshData = function () {
            $scope.GetFixtures();
        }

        $scope.SetAssign = function (x) {
            $scope.Assign = x;
            $scope.Assign.Id = x.Id;
            $scope.Assign.UserName = x.Name;
        }

        $scope.Assign = function () {
            if ($scope.Pop.checkRecallDate === undefined) {
                $scope.Pop.checkRecallDate = false;
            }

            var parameter = {
                UserId: parseInt($scope.Pop.user),
                RecallDate: $scope.Pop.recallDate,
                ItemType: 4, // ToDO : Enumdan çekilebilir
                ItemId: $scope.Assign.Id,
                IsRecall: $scope.Pop.checkRecallDate,
            }

            AssignmentService.AddAssignment(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                        $('#AddAssignment').modal('hide');
                        $scope.$parent.Refresh();
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);