MainApp.controller("ReportController", ["$scope", "ReportService", "AccessoryService", "CategoryService", "AccessoryModelService", "UserService", "NgTableParams", "toaster",
    function ($scope, ReportService, AccessoryService, CategoryService, AccessoryModelService, UserService, NgTableParams, toaster,) {

        var nowDate = new Date();
        $scope.RegisterCount = 0;
        $scope.Id = 0;

        $scope.GetReports = function () {
            ReportService.GetReports(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Reports = result.Data;

                        $.each($scope.Reports, function (index, value) {
                            $scope.Reports[index].InsertDate = new Date($scope.Reports[index].InsertDate).toLocaleString();
                            $scope.Reports[index].User = $scope.Users.find(x => x.Id == $scope.Reports[index].UserId);

                            const reportDate = new Date($scope.Reports[index].InsertDate);
                            const diffTime = Math.abs(nowDate - reportDate);
                            const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
                            $scope.Reports[index].DiffDate = diffDays > 30;
                        });


                        console.log($scope.Reports);

                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }



        $scope.GetUsers = function () {
            UserService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                        console.log(result.Data);
                        $scope.GetReports();
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUsers();


        $scope.Conclude = function (id) {
            console.log($scope.Id);
        }

        //$scope.TableCol = {
        //    Name: "Component Name",
        //    ModelNo: "Model",
        //    CategoryNo: "Category",
        //    Piece: "Piece",
        //    BillNo: "Bill",
        //};

        //$scope.GetCategories = function () {
        //    CategoryService.GetCategories(
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                $scope.Categories = result.Data;
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}
        //$scope.GetCategories();

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

        //$scope.GetAccessories = function () {
        //    AccessoryService.GetAccessories(
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                $scope.Data = result.Data;
        //                $scope.RegisterCount = $scope.Data.length;
        //                $scope.TableParams = new NgTableParams({
        //                    sorting: { name: 'adc' },
        //                    count: 20
        //                }, {
        //                    counts: [10, 20, 50],
        //                    dataset: $scope.Data
        //                });
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}
        //$scope.GetAccessories();

        //$scope.DeleteAccessory = function (data) {
        //    AccessoryService.DeleteAccessory(data.Id,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                $scope.Refresh();
        //                toaster.success("Aksesuar Silindi", "Aksesuar silme işlemi başarılı")
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
        //                toaster.success("Aksesuar Ekleme", "Aksesuar başarıyla eklendi");
        //                $('#AddSituation').modal('hide');
        //                $scope.Pop = [];
        //                $scope.Refresh();
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
