MainApp.controller("HomeController", ["$scope", "$http", "$window", "LogService", "MessageService", "TaskService", "UserService", function ($scope, $http, $window, LogService, MessageService, TaskService, UserService) {

    $scope.Pop = [];
    $scope.Messages = [];
    $scope.UserId = Cookies.get('id');
    $scope.MessageDetail = '';
    $scope.lateTask = 0;

    $scope.Tasks = [];
    $scope.Pop.startDate = new Date();
    $scope.Pop.endDate = new Date();
    $scope.Pop.count = 0;

    $scope.GetLogs = function () {
        LogService.GetLogs(
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
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetLogs();

    $scope.GetMessages = function () {
        MessageService.GetMessages(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.Messages = result.Data;
                    $.each(result.Data, function (index, value) {
                        $scope.Messages[index].Time = new Date(value.Time).toLocaleString();
                    });
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetMessages();

    $scope.GetTasks = function () {
        TaskService.GetTasks(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.Tasks = [];
                    $scope.lateTask = 0;
                    $scope.Tasks = result.Data;

                    result.Data.forEach(function (x) {
                        $scope.Tasks = result.Data;
                        var dateResult = $scope.DateCalc(x.StartDate, x.EndDate);

                        if (dateResult < 0) {
                            $scope.lateTask = $scope.lateTask + 1;
                        }
                    });
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetTasks();

    $scope.GetUser = function () {
        UserService.GetUser(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.NowUser = result.Data;
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetUser();

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
        .build();

    connection.start();

    connection.on("receiveMessageOther", (message, id, nickName) => {
        var d = new Date();
        var data = { "UserId": id, "MessageDetail": message, "Time": d.toUTCString(), "UserName": nickName };

        $scope.$apply(function () {
            $scope.Messages.push(data);
        });
    });

    $scope.AddMessage = function () {
        var d = new Date();
        var data = { "UserId": $scope.UserId, "MessageDetail": $scope.MessageDetail, "Time": d.toUTCString(), "UserName": $scope.NowUser[0].UserName };
        $scope.Messages.push(data);
        connection.invoke("SendAllMessageAsync", $scope.MessageDetail, $scope.UserId, $scope.NowUser[0].UserName);

        var parameter = {
            "MessageDetail": $scope.MessageDetail,
        }
        MessageService.AddMessage(parameter,
            function success(result) {
                if (result.IsSuccess) {
                    $scope.GetMessages();
                    $scope.MessageDetail = '';
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });


        //Down Scrool
        var bottomCoord = $('.downScrool')[0].scrollHeight;
        $('.downScrool').slimScroll({ scrollTo: bottomCoord });
    }


    $scope.UpdateTask = function () {

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
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
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
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.DeleteTask = function (Id) {
        TaskService.DeleteTask(Id,
            function success(result) {
                if (result.IsSuccess) {
                    $scope.GetTasks();
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }


    $scope.GetDetail = function (x) {
        $scope.TaskDetail = x;
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

}]);