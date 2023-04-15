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
                        console.table("calculateFixedAnnualAmount", result.Data);
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
                ValueReceived: $scope.valueReceived
                , Scrapvalue: $scope.scrapvalue
                , Life: $scope.life
                , NumberOfLastMonth: $scope.numberOfLastMonth
            }


            depreciationService.DecreasingBalance(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        console.table("calculateDecreasingBalance", result.Data);
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
                        console.table("calculateDepreciationByProductionAmount", result.Data);
                    }
                    else {
                        toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetDepartments", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }



    }]);
