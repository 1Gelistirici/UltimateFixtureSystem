﻿MainApp.controller("AccessoryAssignmentsController", ["$scope", "AccessoryService", "AssignmentService", "UserService", "NgTableParams", "toaster",
    function ($scope, AccessoryService, AssignmentService, UserService, NgTableParams, toaster,) {

        $scope.test = null;

        $scope.RegisterCount = 0;

        $scope.TableCol = {
            User: "User",
            Accessory: "Accessory",
        };

        $scope.GetAssignments = function () {
            AssignmentService.GetAssignments(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Assignments = result.Data.filter(x => x.ItemType == 2);
                        $scope.RegisterCount = $scope.Assignments.length;

                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Assignments
                        });
                    } else {
                        toaster.error("GetAssignments", "Assignment listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetAssignments", "Assignment listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAssignments();

        //$scope.GetAccessoryModels = function () {
        //    AccessoryModelService.GetAccessoryModels(
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                $scope.AccessoryModels = result.Data;
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}
        //$scope.GetAccessoryModels();

        $scope.GetUsers = function () {
            UserService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                    }
                }, function error() {
                    toaster.error("GetUsers", "User listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUsers();

        $scope.DeleteAssignment = function (x) {
            var parameter = {
                Id: x.Id,
                ItemType: x.ItemType,
                ItemId: x.ItemId
            }
            console.log(x);
            console.log(parameter);
            AssignmentService.DeleteAssignment(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetAssignments();
                        toaster.success("DeleteAssignment", "User listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("DeleteAssignment", "User listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        //$scope.DeleteAccessory = function (data) {
        //    AccessoryService.DeleteAccessory(data.Id,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

        //$scope.UpdateAccessory = function (data) {
        //    AccessoryService.UpdateAccessory(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

        //$scope.AddAccessory = function () {
        //    var data = {
        //        "Name": $scope.Pop.Name,
        //        "Piece": $scope.Pop.Piece,
        //        "BillNo": $scope.Pop.BillNo,
        //        "ModelNo": $scope.Pop.ModelNo,
        //        "CategoryNo": $scope.Pop.CategoryNo
        //    }

        //    AccessoryService.AddAccessory(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

        //$scope.Refresh = function () {
        //    $scope.GetAccessories();
        //}

        //$scope.SetPiece = function (x) {
        //    $scope.piece = x.Piece;
        //    $scope.Pop = [];
        //    $scope.Pop.piece = 0;
        //    $scope.Pop.Id = x.Id;
        //    $scope.Pop.UserName = x.Name;
        //    $scope.Pop.ItemType = 2; // ToDO : Enumdan çekilebilir
        //}

    }]);
