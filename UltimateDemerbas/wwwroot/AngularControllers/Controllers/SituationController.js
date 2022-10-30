MainApp.controller("SituationController", ["$scope", "SituationService", "NgTableParams", "toaster",
    function ($scope, SituationService, NgTableParams, toaster) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Status Name",
        };

        $scope.GetSituations = function () {
            SituationService.GetSituations(
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
                    } else {
                        toaster.error("GetSituations", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetSituations", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetSituations();

        $scope.DeleteSituation = function (data) {
            SituationService.DeleteSituation(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("", "");
                    } else {
                        toaster.error("DeleteSituation", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("DeleteSituation", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateSituation = function (data) {
            SituationService.UpdateSituation(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("", "");
                    } else {
                        toaster.error("UpdateSituation", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("UpdateSituation", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddSituation = function () {
            var data = {
                "Name": $scope.Pop.Name,
            }

            SituationService.AddSituation(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("", "");
                    } else {
                        toaster.error("AddSituation", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddSituation", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });

        }

    }]);
