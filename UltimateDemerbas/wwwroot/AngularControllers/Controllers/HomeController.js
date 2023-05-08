MainApp.controller("HomeController", ["$scope", "LogService", "MessageService", "TaskService", "UserService", "TonerService", "ReportService", "AssignmentService", "toaster", "$confirm",
    function ($scope, LogService, MessageService, TaskService, UserService, TonerService, ReportService, assignmentService, toaster, $confirm) {

        $scope.Pop = [];
        $scope.Messages = [];
        $scope.MessageDetail = '';
        $scope.lateTask = 0;
        $scope.TonerAlert = 0;
        $scope.totalActiveReport = 0;
        $scope.totalAsset = 0;

        $scope.Tasks = [];
        $scope.Pop.startDate = new Date();
        $scope.Pop.endDate = new Date();
        $scope.Pop.count = 0;

        $scope.openInsertTaskPopup = function () {
            $scope.Pop.taskDetail = "";
            $scope.Pop.startDate = new Date();
            $scope.Pop.endDate = new Date();
            $scope.Pop.count = 0;
        }

        $scope.DateCalc = function (startDate, endDate) {
            var MS_one_day = 1000 * 60 * 60 * 24;
            var x = new Date();
            var y = new Date(endDate);

            var date1 = Date.UTC(x.getFullYear(), x.getMonth(), x.getDate());
            var date2 = Date.UTC(y.getFullYear(), y.getMonth(), y.getDate());

            var result = Math.floor((date2 - date1) / MS_one_day);

            return result;
        }

        $scope.GetReportsByStatu = function () {
            ReportService.GetReportsByStatu(0,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.totalActiveReport = result.Data.length;
                    } else {
                        toaster.error("GetReportsByStatu", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetReportsByStatu", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetReportsByStatu();

        $scope.GetLogs = function () {
            LogService.GetLogByCompanyRefId(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Logs = result.Data;
                        $.each(result.Data, function (index, value) {
                            $scope.Logs[index].Time = new Date(value.Time).toLocaleString();
                        });

                        //Down Scrool
                        var bottomCoord = $('.downScrool')[0].scrollHeight;
                        $('.downScrool').slimScroll({ scrollTo: bottomCoord });
                    } else {
                        toaster.error("GetLogs", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetLogs", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetLogs();

        $scope.GetMessages = function () {
            MessageService.GetMessageByCompanyRefId(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Messages = result.Data;
                        $.each(result.Data, function (index, value) {
                            $scope.Messages[index].Time = new Date(value.Time).toLocaleString();
                        });
                    } else {
                        toaster.error("GetMessages", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetMessages", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetMessages();

        $scope.GetToners = function () {
            TonerService.GetToners(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.TonerAlert = 0;

                        result.Data.forEach(function (x) {
                            if (x.Piece <= x.MinStock) {
                                $scope.TonerAlert++;
                            }
                        });
                    } else {
                        toaster.error("GetToners", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetToners", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetToners();

        $scope.GetTasks = function () {
            TaskService.GetTasks(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Tasks = [];
                        $scope.lateTask = 0;
                        $scope.Tasks = result.Data;

                        result.Data.forEach(function (x) {
                            x.StartDateString = formatDate($scope.Tasks.StartDate);
                            x.EndDateString = formatDate($scope.Tasks.EndDate);
                            var dateResult = $scope.DateCalc(x.StartDate, x.EndDate);

                            if (dateResult < 0) {
                                $scope.lateTask = $scope.lateTask + 1;
                            }
                        });
                    } else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetTasks();

        $scope.GetUser = function () {
            UserService.GetUser(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.NowUser = result.Data;
                        $scope.UserId = result.Data.Id;
                    } else {
                        toaster.error("GetUser", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUser", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUser();

        $scope.GetAssignmentUser = function () {
            assignmentService.GetAssignmentUser(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.totalAsset = result.Data.length;
                    } else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmeyen bir hata ile karşılaşıldı.");
                });
        }
        $scope.GetAssignmentUser();

        //$scope.GetTask = function (Id) {
        //    TaskService.GetTask(Id,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                $scope.Task = result.Data[0];
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

        $scope.GetTask = function (task) {
            $scope.Task.startDate = new Date(task.StartDate);
            $scope.Task.endDate = new Date(task.EndDate);
            $scope.Task.taskDetail = task.TaskDetail;
            $scope.Task.count = task.Count;
            $scope.Task.id = task.Id;
            $scope.Task.isActive = task.IsActive;
        }

        const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:5001/chathub")
            .withAutomaticReconnect()
            .build();

        jQuery(document).ready(function () {
            connection.start();
        });

        connection.on("receiveMessageOther", (message, id, nickName) => {
            var d = new Date();
            var data = { "UserId": parseInt(id), "MessageDetail": message.toString(), "Time": d.toUTCString(), "UserName": nickName.toString() };

            $scope.$apply(function () {
                $scope.Messages.push(data);
            });
        });

        $scope.AddMessage = function () {
            var d = new Date();
            var data = { "UserId": $scope.UserId, "MessageDetail": $scope.MessageDetail, "Time": d.toUTCString(), "UserName": $scope.NowUser.UserName };
            $scope.Messages.push(data);
            connection.invoke("SendAllMessageAsync", $scope.MessageDetail.toString(), parseInt($scope.UserId), $scope.NowUser.UserName.toString());

            var parameter = {
                "MessageDetail": $scope.MessageDetail,
            }
            MessageService.AddMessage(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetMessages();
                        $scope.MessageDetail = '';
                    } else {
                        toaster.error("AddMessage", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddMessage", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });


            //Down Scrool
            var bottomCoord = $('.downScrool')[0].scrollHeight;
            $('.downScrool').slimScroll({ scrollTo: bottomCoord });
        }


        function updateTask() {

            var parameter = {
                "TaskDetail": $scope.Task.taskDetail,
                "Id": $scope.Task.id,
                "StartDate": $scope.Task.startDate,
                "EndDate": $scope.Task.endDate,
                "Count": $scope.Task.count,
            }

            TaskService.UpdateTask(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetTasks();
                        toaster.success("Başarılı", "Güncelleme gerçekleştirildi.");

                        $("#UpdateTask").modal("hide");
                    } else {
                        toaster.error("UpdateTask", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("UpdateTask", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddTask = function () {

            var parameter = {
                "StartDate": $scope.Pop.startDate,
                "EndDate": $scope.Pop.endDate,
                "TaskDetail": $scope.Pop.taskDetail,
                "Count": $scope.Pop.count
            }

            TaskService.AddTask(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetTasks();

                        $("#AddTask").modal("hide");
                    } else {
                        toaster.error("AddTask", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddTask", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        function deleteTask(Id) {
            TaskService.DeleteTask(Id,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetTasks();
                    } else {
                        toaster.error("DeleteTask", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("DeleteTask", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }


        $scope.GetDetail = function (x) {
            $scope.TaskDetail = x;
        }








        $scope.DeleteTaskConfirm = function (parameter) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz? Ürün silindikden sonra ürün tutarı fatura tutarından düşülecektir.", function () { deleteTask(parameter); });
        }
        $scope.UpdateTaskConfirm = function (parameter) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { updateTask(parameter); });
        }

    }]);