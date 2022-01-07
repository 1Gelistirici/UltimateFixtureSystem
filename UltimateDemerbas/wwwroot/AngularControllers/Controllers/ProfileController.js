MainApp.controller("ProfileController", ["$scope", "UserService", "TaskService", "CategoryService", "AccessoryModelService", "ReportService", "AssignmentService", "EnumService", "NgTableParams", "toaster",
    function ($scope, UserService, TaskService, CategoryService, AccessoryModelService, ReportService, AssignmentService, EnumService,NgTableParams, toaster) {


        //Get User
        $scope.GetIsActiveTypes = function () {
            EnumService.GetIsActiveTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        console.log(result.Data);
                    } else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetIsActiveTypes();






















        $scope.ItemTypesFilter = [];
        $scope.AccessoryCount = 0;
        $scope.TableCol = {
            Name: "Component Name",
            ItemType: "Item Type",
            ModelNo: "Model",
            CategoryNo: "Category",
            Piece: "Piece",
            BillNo: "Bill",
            Recall: "Recall",
        };

        // ToDo : Enumdan çekilecek.
        $scope.ItemTypes = [
            {
                Text: "Bill",
                Value: 1
            },
            {
                Text: "Accessory",
                Value: 2
            },
            {
                Text: "Companent",
                Value: 3
            },
            {
                Text: "Fixture",
                Value: 4
            },
            {
                Text: "Licence",
                Value: 5
            },
            {
                Text: "Toner",
                Value: 6
            }
        ]

        $.each($scope.ItemTypes, function (index, value) {
            var parameter = { id: value.Value, title: value.Text };
            $scope.ItemTypesFilter.push(parameter);
        });

        //GetAssignmentUser
        $scope.GetAssignmentUser = function () {
            AssignmentService.GetAssignmentUser(
                function success(result) {
                    if (result.IsSuccess) {
                        //$scope.AccessoryData = result.Data.filter(x => x.Accessories != null);
                        $scope.AccessoryData = result.Data;
                        $.each($scope.AccessoryData, function (index, value) {

                            $scope.AccessoryData[index].RecallDate = new Date($scope.AccessoryData[index].RecallDate).toLocaleString();

                            //ItemType texti bulunur.
                            $scope.AccessoryData[index].ItemType = $scope.ItemTypes.find(x => x.Value == value.ItemType);
                            //Servisden datalar ayrıştırılarak geliyor. Herbiri için farklı tab açmak yerine aynı tab altında toplanılacağı için uı da Accessories içerisinde toplanıyor.
                            if ($scope.AccessoryData[index].Components != null) {
                                $scope.AccessoryData[index].Accessories = $scope.AccessoryData[index].Components;
                            }
                            else if ($scope.AccessoryData[index].Bills != null) {
                                $scope.AccessoryData[index].Accessories = $scope.AccessoryData[index].Bills;
                            }
                            else if ($scope.AccessoryData[index].Licences != null) {
                                $scope.AccessoryData[index].Accessories = $scope.AccessoryData[index].Licences;
                            }
                            else if ($scope.AccessoryData[index].Toners != null) {
                                $scope.AccessoryData[index].Accessories = $scope.AccessoryData[index].Toners;
                            }
                            else if ($scope.AccessoryData[index].Fixtures != null) {
                                $scope.AccessoryData[index].Accessories = $scope.AccessoryData[index].Fixtures;
                            }
                        });

                        RefreshAccessoryTable();
                    } else {
                        toaster.error("GetAssignmentUser", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetAssignmentUser", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        //Get User
        $scope.GetUser = function () {
            UserService.GetUser(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.User = result.Data[0];
                        $scope.Facebook = result.Data[0].Facebook;
                        $scope.Twitter = result.Data[0].Twitter;
                        $scope.Linkedin = result.Data[0].Linkedin;
                        $scope.About = result.Data[0].About;
                    } else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
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
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
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
                        toaster.error("GetCategories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetCategories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetCategories();

        //Get AccessoryModels
        $scope.GetAccessoryModels = function () {
            AccessoryModelService.GetAccessoryModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.AccessoryModels = result.Data;
                        $scope.GetAssignmentUser();
                    } else {
                        toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAccessoryModels();

        //Get Accessory
        //$scope.GetAccessory = function () {
        //AccessoryService.GetAccessory(
        //    function success(result) {
        //        if (result.IsSuccess) {
        //            $scope.AccessoryData = result.Data;
        //            $scope.AccessoryCount = $scope.AccessoryData.length;


        //$scope.AccessoryTable = new NgTableParams({
        //    sorting: { name: 'adc' },
        //    count: 20
        //}, {
        //    counts: [10, 20, 50],
        //    dataset: $scope.AccessoryData
        //});
        //    } else {
        //        toaster.error("GetAccessory", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //    }
        //}, function error() {
        //    toaster.error("GetAccessory", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //});
        //}
        //$scope.GetAccessory();

        function RefreshAccessoryTable() {
            $scope.AccessoryTable = new NgTableParams({
                sorting: { name: 'adc' },
                count: 20
            }, {
                counts: [10, 20, 50],
                dataset: $scope.AccessoryData
            });
        }

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
            $scope.Pop = x.Accessories
            $scope.AssignmentId = x.Id;
        }

        //AddReport
        $scope.AddReport = function () {
            $scope.AccessoryData.find(x => x.Id == $scope.AssignmentId).Report = true;

            var parameter = {
                ReportSubject: $scope.Pop.reportSubject,
                ReportDetail: $scope.Pop.reportDetail,
                ItemId: $scope.Pop.Id,
                Id: $scope.AssignmentId
            }

            ReportService.AddReport(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Rapor Oluşturuldu.", "En kısa zamanda yetkililer sizinler iletişime geçecektir.");
                        $("#ReportPopup").modal("hide");
                    } else {
                        toaster.error("Rapor Oluşturulamadı", "Teknik bir hata yüzünden rapor oluşturulamadı.");
                    }
                }, function error() {
                    toaster.error("Rapor Oluşturulamadı", "Teknik bir hata yüzünden rapor oluşturulamadı.");
                });
        }

        $scope.CheckRecallDate = function (recalDate) {
            return new Date(recalDate).toLocaleString() > new Date().toLocaleString() ? false : true;
        }

    }]);
