MainApp.controller("PassiveReportController", ["$scope", "ReportService", "EnumService", "UserService", "toaster",
    function ($scope, ReportService, EnumService, UserService, toaster,) {

        var nowDate = new Date();
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.GetDetail = function (_) {
            $scope.Pop = [];
            $scope.Pop.Subject = _.Subject;
            $scope.Pop.Comment = _.Comment;
            $scope.Pop.Statu = $scope.ReportStatus.filter(x => x.Value == _.Statu)[0].Value;
        }

        $scope.GetPassiveReports = function (type) {
            ReportService.GetPassiveReports(
                function success(result) {
                    if (result.IsSuccess) {
                        console.log(result.Data);
                        $scope.Reports = result.Data.filter(x => x.Statu == type);

                        $.each($scope.Reports, function (index, value) {
                            $scope.Reports[index].InsertDate = new Date($scope.Reports[index].InsertDate).toLocaleString();
                            $scope.Reports[index].User = $scope.Users.find(x => x.Id == $scope.Reports[index].UserId);

                            const reportDate = new Date($scope.Reports[index].InsertDate);
                            const diffTime = Math.abs(nowDate - reportDate);
                            const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
                            $scope.Reports[index].DiffDate = diffDays > 30;
                        });
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
                        $scope.GetPassiveReports(0);
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUsers();

        $scope.GetReportStatus = function () {
            EnumService.GetReportStatus(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.ReportStatus = result.Data.filter(x => x.Value != 0);

                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetReportStatus();
    }
]);
