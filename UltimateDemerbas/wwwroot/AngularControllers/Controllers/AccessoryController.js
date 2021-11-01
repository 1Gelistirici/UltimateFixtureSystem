﻿MainApp.controller("AccessoryController", ["$scope", "AccessoryService", "CategoryService", "AccessoryModelService", "UserService", "AssignmentService", "$http", "NgTableParams",
    function ($scope, AccessoryService, CategoryService, AccessoryModelService, UserService, AssignmentService, $http, NgTableParams) {

        $scope.test = null;

        $scope.RegisterCount = 0;

        $scope.TableCol = {
            Name: "Component Name",
            ModelNo: "Model",
            CategoryNo: "Category",
            Piece: "Piece",
            BillNo: "Bill",
        };

        $scope.GetUsers = function () {
            UserService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                        console.log($scope.Users);
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUsers();

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

        $scope.GetAccessoryModels = function () {
            AccessoryModelService.GetAccessoryModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.AccessoryModels = result.Data;
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
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
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAccessories();

        $scope.DeleteAccessory = function (data) {
            AccessoryService.DeleteAccessory(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateAccessory = function (data) {
            AccessoryService.UpdateAccessory(data,
                function success(result) {
                    if (result.IsSuccess) {
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddAccessory = function () {

            var data = {
                "Name": $scope.Pop.Name,
                "Piece": $scope.Pop.Piece,
                "BillNo": $scope.Pop.BillNo,
                "ModelNo": $scope.Pop.ModelNo,
                "CategoryNo": $scope.Pop.CategoryNo
            }

            AccessoryService.AddAccessory(data,
                function success(result) {
                    if (result.IsSuccess) {
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });

        }

        $scope.Assign = function () {

            //if (!$scope.Pop.checkRecallDate) {
            //    $scope.Pop.recallDate = null
            //}

            parameter = {
                UserId: parseInt($scope.Pop.user),
                RecallDate: $scope.Pop.recallDate,
                ItemType: 2, // ToDo : Ortak enumdan çekilecek.
                ItemId: $scope.Pop.Id
            }

            AssignmentService.AddAssignment(parameter,
                function success(result) {
                    if (result.IsSuccess) {

                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.SetPiece = function (x) {
            $scope.piece = x.Piece;
            $scope.Pop = [];
            $scope.Pop.piece = 0;
            $scope.Pop.Id = x.Id;
        }

    }]);
