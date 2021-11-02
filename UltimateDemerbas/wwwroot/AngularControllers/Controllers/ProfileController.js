MainApp.controller("ProfileController", ["$scope", "ProfileService", "UserService", "TaskService", "AccessoryService", "CategoryService", "AccessoryModelService", "ReportService", "NgTableParams",
    function ($scope, ProfileService, UserService, TaskService, AccessoryService, CategoryService, AccessoryModelService, ReportService, NgTableParams) {

        $scope.AccessoryCount = 0;
        $scope.TableCol = {
            Name: "Component Name",
            ModelNo: "Model",
            CategoryNo: "Category",
            Piece: "Piece",
            BillNo: "Bill",
        };

        //Get User
        $scope.GetUser = function () {
            UserService.GetUser(
                function success(result) {
                    if (result.IsSuccess) {
                        console.log("GetUser", result.Data);
                        $scope.User = result.Data[0];
                        $scope.Facebook = result.Data[0].Facebook;
                        $scope.Twitter = result.Data[0].Twitter;
                        $scope.Linkedin = result.Data[0].Linkedin;
                        $scope.About = result.Data[0].About;
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUser();

        //Get Task
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

        //Get Categories
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

        //Get AccessoryModels
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

        //Get Accessory
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

        //Change Password
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

        //Update Profile
        $scope.UpdateProfile = function () {

            var parameter = {
                "About": $scope.About,
                "Facebook": $scope.Facebook,
                "Linkedin": $scope.Linkedin,
                "Twitter": $scope.Twitter
            }

            UserService.UpdateProfile(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.User.Facebook = $scope.Facebook;
                        $scope.User.Twitter = $scope.Twitter;
                        $scope.User.Linkedin = $scope.Linkedin;
                        $scope.User.About = $scope.About;
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }


        $scope.GetAccessoryModels = function (x) {
            $scope.AccessoryModels.forEach(function (item) {
                if (item.Id == x) {
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

        $scope.OpenReport = function (x) {
            $scope.Pop = [];
            $scope.Pop = x
        }

        //AddReport
        $scope.AddReport = function () {

            var parameter = {
                ReportSubject: $scope.Pop.reportSubject,
                ReportDetail: $scope.Pop.reportDetail,
                ItemId: $scope.Pop.Id,
            }

            ReportService.AddReport(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }


    }]);
