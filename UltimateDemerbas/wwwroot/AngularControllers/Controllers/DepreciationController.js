MainApp.controller("DepreciationController", ["$scope", "DepreciationService", "toaster",
    function ($scope, depreciationService, toaster) {

        $scope.calculateFixedAnnualAmount = function () {

            var parameter = {
                Cost: $scope.cost
                , RecoveryValue: $scope.recoveryValue
                , EconomicSpine: $scope.economicSpine
            }

            depreciationService.FixedAnnualAmount(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        console.log("calculateFixedAnnualAmount", result.Data);
                    }
                    else {
                        toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.calculateDecreasingBalance = function () {

            var parameter = {
                TotalDepreciation: $scope.totalDepreciation
            }

            depreciationService.DecreasingBalance(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        console.log("calculateDecreasingBalance", result.Data);
                    }
                    else {
                        toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.calculateDepreciationByProductionAmount = function () {

            var parameter = {
                AssetCost: $scope.assetCost
                , SalvageValue: $scope.salvageValue
                , ProductionCapacity: $scope.productionCapacity
                , ProductionAmount: $scope.productionAmount
                , LifeSpanInYears: $scope.lifeSpanInYears
            }

            depreciationService.DepreciationByProductionAmount(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        console.log("calculateDepreciationByProductionAmount", result.Data);
                    }
                    else {
                        toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }



    }]);
