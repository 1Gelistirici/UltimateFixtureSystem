
MainApp.controller("DepozitFormPageController", ["$scope", "AssignmentService", "UserService", "toaster", "EnumService", "NgTableParams", "AccessoryModelService", "CategoryService", "$confirm",
    function ($scope, AssignmentService, UserService, toaster, enumService, NgTableParams, AccessoryModelService, categoryService, $confirm) {

        $scope.todayDate = formatDate(new Date);
        $scope.registerCount = 0;
        $scope.ItemTypesFilter = [];
        $scope.assignmentData = [];
        $scope.TableCol = {
            Name: "Component Name",
            ItemType: "Item Type",
            ModelNo: "Model",
            CategoryNo: "Category",
            Piece: "Piece",
            BillNo: "Bill",
            Recall: "Recall",
            UserName: "User Name"
        };

        $scope.GetAssignmentsByCompany = function () {
            AssignmentService.GetAssignmentsByCompany(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.assignmentData = result.Data;

                        $.each($scope.assignmentData, function (index, value) {

                            $scope.assignmentData[index].User = $scope.Users.find(x => x.Id === value.UserId);
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
                        refreshAssignmentTable();

                    } else {
                        toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        function refreshAssignmentTable() {
            $scope.TableParams = new NgTableParams({
                sorting: { name: 'adc' },
                count: 20
            }, {
                counts: [10, 20, 50],
                dataset: $scope.assignmentData
            });
            $scope.registerCount = $scope.assignmentData.length;
        }

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

        $scope.GetItemTypeTypes = function () {
            enumService.GetItemTypeTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.ItemTypes = result.Data;

                        $.each($scope.ItemTypes, function (index, value) {
                            var parameter = { id: value.Value, title: value.Text };
                            $scope.ItemTypesFilter.push(parameter);
                        });

                        $scope.GetAssignmentsByCompany();
                    } else {
                        toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetItemTypeTypes();

        $scope.Assign = function () {

            if ($scope.Pop.checkRecallDate === undefined) {
                $scope.Pop.checkRecallDate = false;
            }

            var parameter = {
                UserId: parseInt($scope.Pop.user),
                RecallDate: $scope.Pop.recallDate,
                ItemType: $scope.Pop.ItemType,
                ItemId: $scope.Pop.Id,
                Piece: $scope.Pop.piece,
                IsRecall: $scope.Pop.checkRecallDate,
            }

            AssignmentService.AddAssignment(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        //toaster.success("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                        $('#AddAssignment').modal('hide');
                        $scope.$parent.Refresh();
                    } else {
                        toaster.error("AddAssignment", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddAssignment", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

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

        function deleteAssignment(item) {
            var parameter = {
                Id: item.Id
                , ItemType: item.ItemType
                , ItemId: item.ItemId
                , Piece: item.Piece
            };

            AssignmentService.DeleteAssignment(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Atama geri alındı.");
                        $scope.GetAssignmentsByCompany();
                    }
                    else {
                        toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetAccessoryModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

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

        $scope.CheckRecallDate = function (recalDate) {
            return new Date(recalDate).toLocaleString() > new Date().toLocaleString() ? false : true;
        }

        $scope.undoConfirm = function (item) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { deleteAssignment(item) });
        }

    }]);
