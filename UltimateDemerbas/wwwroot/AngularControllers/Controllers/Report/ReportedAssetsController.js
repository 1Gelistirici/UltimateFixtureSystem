MainApp.controller("ReportedAssetsController", ["$scope", "ReportService", "toaster", "NgTableParams", "$confirm",
    function ($scope, reportService, toaster, NgTableParams, $confirm) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Component Model Name",
        };

        $scope.GetReportedAssetsByCompany = function () {
            reportService.GetReportedAssetsByCompany(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;
                        $scope.RegisterCount = $scope.Data.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });
                    }
                    else {
                        toaster.error("GetComponentModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetComponentModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetReportedAssetsByCompany();

    }]);
