MainApp.controller("TaskController", ["$scope", "UserService", "EnumService", "NgTableParams", "toaster", "TaskService",
    function ($scope, UserService, EnumService, NgTableParams, toaster, TaskService) {

        //#region Parameters
        $scope.RegisterCount = 0;
        $scope.CheckActive = true;

        $scope.TableCol = {
            TaskDetail: "Detail",
            StartDate: "Start Date",
            EndDate: "End Date",
            IsActive: "Status",
            Count: "Importance Level"
        };

        $scope.Today = new Date();

        //#endregion


        //#region GETS
        $scope.GetTasks = function () {
            TaskService.GetTasks(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;

                        console.log($scope.Data);
                        $scope.RegisterCount = result.Data.length;

                        $.each($scope.Data, function (index, value) {
                            $scope.Data[index].EndDate = new Date(value.EndDate);
                            $scope.Data[index].StartDate = new Date(value.StartDate);
                        });

                        $scope.ChangeCheck();
                    } else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetTasks();

        $scope.GetImportanceLevels = function () {
            EnumService.GetImportanceLevels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.ImportanceLevels = result.Data;
                    } else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetImportanceLevels();

        $scope.GetTaskActiveStatus = function () {
            EnumService.GetTaskActiveStatus(
                function success(result) {
                    if (result.IsSuccess) {
                        console.log("GetTaskActiveStatus", result.Data);
                        $scope.TaskActiveStatus = result.Data.filter(x => x.Value != 1);
                    } else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetTaskActiveStatus();
        //#endregion

        $scope.ChangeCheck = function () {

            $scope.DataFilter = [];

            if ($scope.CheckActive) {
                $scope.DataFilter = $scope.Data.filter(x => x.IsActive === 1);
            }
            if ($scope.CheckClosed) {
                $scope.DataFilter = $scope.Data.filter(x => x.IsActive === 2).concat($scope.DataFilter);
            }
            if ($scope.CheckSolved) {
                $scope.DataFilter = $scope.Data.filter(x => x.IsActive === 4).concat($scope.DataFilter);
            }
            if ($scope.CheckUnSolved) {
                $scope.DataFilter = $scope.Data.filter(x => x.IsActive === 8).concat($scope.DataFilter);
            }


            $scope.TableParams = new NgTableParams({
                sorting: { name: 'adc' },
                count: 20
            }, {
                counts: [10, 20, 50],
                dataset: $scope.DataFilter
            });




        }


        $scope.DeleteTask = function (data) {
            TaskService.DeleteTask(data.Id,
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

        $scope.UpdateTask = function (parameter) {
            TaskService.UpdateTask(parameter,
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

        $scope.AddTask = function () {
            TaskService.AddTask($scope.Pop,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Demirbaş başarıyla güncellenmiştir.");
                        $scope.GetTasks();
                        $("#AddTaskPopup").modal("hide");
                        $scope.Pop = [];
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddStatu = function () {
            var param = {
                Note: $scope.Pop.Note,
                Id: $scope.Pop.Id,
                IsActive: $scope.Pop.IsActive
            }
            TaskService.AddStatu(param,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Demirbaş başarıyla güncellenmiştir.");
                        $scope.GetTasks();
                        $("#AddTaskStatuPopup").modal("hide");
                        $scope.Pop = [];
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }


        function RefreshData() {
            $scope.GetTasks();
        }

        $scope.OpenTaskStatuPopup = function (_) {
            $scope.Pop = [];
            $scope.Pop.Id = _.Id;
        }





    }]);
