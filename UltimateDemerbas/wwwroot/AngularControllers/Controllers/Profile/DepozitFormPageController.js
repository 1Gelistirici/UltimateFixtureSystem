
MainApp.controller("DepozitFormPageController", ["$scope", "AssignmentService", "UserService", "toaster", "EnumService", "NgTableParams", "AccessoryModelService", "CategoryService", "$confirm",
    function ($scope, AssignmentService, UserService, toaster, enumService, NgTableParams, AccessoryModelService, categoryService, $confirm) {

        $scope.todayDate = formatDate(new Date);
        $scope.assignmentData = [];

        $scope.GetAssignmentsByCompany = function () {
            AssignmentService.GetAssignmentsByCompany(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.assignmentData = result.Data;

                        $.each($scope.assignmentData, function (index, value) {

                            $scope.assignmentData[index].RecallDate = new Date($scope.assignmentData[index].RecallDate).toLocaleString();
                            $scope.assignmentData[index].TypeItem = $scope.ItemTypes.find(x => x.Value === value.ItemType);

                            if ($scope.assignmentData[index].Components !== null) {
                                $scope.assignmentData[index].Item = $scope.assignmentData[index].Components;
                            }
                            else if ($scope.assignmentData[index].Bills !== null) {
                                $scope.assignmentData[index].Item = $scope.assignmentData[index].Bills;
                            }
                            else if ($scope.assignmentData[index].Licences !== null) {
                                $scope.assignmentData[index].Item = $scope.assignmentData[index].Licences;
                            }
                            else if ($scope.assignmentData[index].Toners !== null) {
                                $scope.assignmentData[index].Item = $scope.assignmentData[index].Toners;
                            }
                            else if ($scope.assignmentData[index].Fixtures !== null) {
                                $scope.assignmentData[index].Item = $scope.assignmentData[index].Fixtures;
                            }
                            else if ($scope.assignmentData[index].Accessories !== null) {
                                $scope.assignmentData[index].Item = $scope.assignmentData[index].Accessories
                            }
                        });
                        console.log("$scope.assignmentData", $scope.assignmentData);

                    } else {
                        toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.GetUser = function () {
            UserService.GetUser(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.User = result.Data;
                        console.log("user", result.Data);
                    }
                    else {
                        toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUser();

        $scope.GetItemTypeTypes = function () {
            enumService.GetItemTypeTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.ItemTypes = result.Data;

                        $scope.GetAssignmentsByCompany();
                    } else {
                        toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetItemTypeTypes();

        $scope.GetAccessoryModels = function () {
            AccessoryModelService.GetAccessoryModels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.AccessoryModels = result.Data;
                    } else {
                        toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetAccessoryModels();

        $scope.GetCategoryNo = function (x) {
            $scope.Categories.forEach(function (item) {
                if (item.Id === x) {
                    $scope.CategoryNoreturn = item.Name;
                }
            });
        }

        $scope.GetAccessoryModels = function (x) {
            $scope.AccessoryModels.forEach(function (item) {
                if (item.Id === x) {
                    $scope.AccessoryModelreturn = item.Name;
                }
            });
        }

        $scope.GetCategories = function () {
            categoryService.GetCategories(
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
    }]);
