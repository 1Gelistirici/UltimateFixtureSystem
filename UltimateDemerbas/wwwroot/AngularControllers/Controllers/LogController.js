MainApp.controller("LogController", ["$scope", "LogService", "EnumService", "NgTableParams", "toaster", "$confirm",
    function ($scope, logService, enumService, NgTableParams, toaster, $confirm) {

        $scope.registerCount = 0;
        $scope.TableCol = {
            Detail: "Detail",
            Time: "Time",
            Type: "Log Type",
        };

        $scope.logTypeFilter = [];

        $scope.GetLogs = function () {
            logService.GetLogs(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;

                        $scope.Data = $scope.Data.map((item) => {
                            return { ...item, Time: formatDate(new Date(item.Time)) };
                        });

                        $scope.registerCount = $scope.Data.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 10
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });
                    } else {
                        toaster.error("Başarısız", "Lisans tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Lisans tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetLogs();

        $scope.GetLogTypes = function () {
            enumService.GetLogTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.logTypeList = result.Data;

                        $.each($scope.logTypeList, function (index, value) {
                            var parameter = { id: value.Value, title: value.Text };
                            $scope.logTypeFilter.push(parameter);
                        });

                    } else {
                        toaster.error("Başarısız", "Lisans tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Lisans tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetLogTypes();
    }]);



