MainApp.controller("ReportController", ["$scope", "ReportService", "EnumService", "UserService", "toaster",
    function ($scope, ReportService, EnumService, UserService, toaster,) {

        var nowDate = new Date();
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.GetReports = function () {
            ReportService.GetReports(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Reports = result.Data;

                        $.each($scope.Reports, function (index, value) {
                            $scope.Reports[index].InsertDate = new Date($scope.Reports[index].InsertDate).toLocaleString();
                            $scope.Reports[index].User = $scope.Users.find(x => x.Id === $scope.Reports[index].UserId);

                            const reportDate = new Date($scope.Reports[index].InsertDate);
                            const diffTime = Math.abs(nowDate - reportDate);
                            const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
                            $scope.Reports[index].DiffDate = diffDays > 30;
                        });

                    } else {
                        toaster.error("GetReports", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetReports", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.GetUsers = function () {
            UserService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                        $scope.GetReports();
                    } else {
                        toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetUsers();

        $scope.GetReportStatus = function () {
            EnumService.GetReportStatus(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.ReportStatus = result.Data.filter(x => x.Value !== 0);

                    } else {
                        toaster.error("GetReportStatus", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetReportStatus", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetReportStatus();


        $scope.OpenPopup = function (_) {
            $scope.Pop = [];
            $scope.Pop.Subject = _.ReportSubject;
            $scope.Pop.Id = _.Id;
            $scope.Pop.AssignmentId = _.AssignmentId;
        }

        $scope.Conclude = function () {

            parameter = {
                "Id": $scope.Pop.Id,
                "Statu": parseInt($scope.Pop.Statu),
                "Comment": $scope.Pop.Comment,
                "assignmentId": $scope.Pop.AssignmentId
            };

            ReportService.UpdateReportStatu(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.GetReports();
                        toaster.success("Başarılı", "Rapor başarıyla sonuçlandırıldı.");
                        $("#Conclude").modal("hide");
                    } else {
                        toaster.error("UpdateReportStatu", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("UpdateReportStatu", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);
