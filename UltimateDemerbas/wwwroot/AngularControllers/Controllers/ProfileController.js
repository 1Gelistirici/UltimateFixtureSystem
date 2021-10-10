MainApp.controller("ProfileController", ["$scope", "ProfileService", "UserService", "TaskService", "AccessoryService", "CategoryService", "AccessoryModelService", "NgTableParams", function ($scope, ProfileService, UserService, TaskService, AccessoryService, CategoryService, AccessoryModelService, NgTableParams) {

    $scope.AccessoryCount = 0;
    $scope.TableCol = {
        Name: "Component Name",
        ModelNo: "Model",
        CategoryNo: "Category",
        Piece: "Piece",
        BillNo: "Bill",
    };


    $scope.GetUser = function () {
        UserService.GetUser(
            function success(result) {
                if (result.IsSuccess) {
                    console.log(result.Data);
                    $scope.User = result.Data[0];
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetUser();

    $scope.GetTasks = function () {
        TaskService.GetTasks(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.TaskLength = result.Data.length;
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetTasks();

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

    $scope.GetAccessory = function () {
        AccessoryService.GetAccessory(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.AccessoryData = result.Data;
                    $scope.AccessoryCount = $scope.AccessoryData.length;
                    $scope.AccessoryTable = new NgTableParams({
                        sorting: { name: 'adc' },
                        count: 20
                    }, {
                        counts: [10, 20, 50],
                        dataset: $scope.AccessoryData
                    });
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetAccessory();

    $scope.ChangePassword = function () {

        var parameter = {
            "PasswordTry": $scope.PasswordTry,
            "Password": $scope.Password,
            "OldPassword": $scope.OldPassword
        }

        UserService.ChangePassword(parameter,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }


    $scope.GetAccessoryModels = function (x) {
        $scope.AccessoryModels.forEach(function (item) {
            if (item.Id==x) {
                $scope.AccessoryModelreturn = item.Name;
            }
        });
    }

    $scope.GetCategoryNo = function (x) {
        $scope.Categories.forEach(function (item) {
            if (item.Id == x) {
                $scope.CategoryNoreturn = item.Name;
            }
        });
    }





}]);
