MainApp.controller("AccessoryAssignmentsController", ["$scope", "AccessoryService", "AssignmentService", "NgTableParams", "toaster",
    function ($scope, AccessoryService, AssignmentService, NgTableParams, toaster,) {

        $scope.test = null;

        $scope.RegisterCount = 0;

        $scope.TableCol = {
            Name: "Component Name",
            ModelNo: "Model",
            CategoryNo: "Category",
            Piece: "Piece",
            BillNo: "Bill",
        };

        $scope.GetAssignments = function () {
            AssignmentService.GetAssignments(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Assignments = result.Data.filter(x => x.ItemType == 2);
                        console.log($scope.Assignments);

                        $scope.RegisterCount = $scope.Assignments.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Assignments
                        });
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
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

        $scope.GetAccessories = function () {
            AccessoryService.GetAccessories(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Accessories = result.Data;
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAccessories();

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
