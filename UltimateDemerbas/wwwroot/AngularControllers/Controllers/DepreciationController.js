MainApp.controller("DepreciationController", ["$scope", "DepreciationService", "toaster", "NgTableParams",
    function ($scope, depreciationService, toaster, NgTableParams) {

        $scope.RegisterCountNormalDecreasing = 0;
        $scope.RegisterCountDecreasingBalance = 0;
        $scope.TableColNormalDecreasing = {
            ApplicableValue: "Applicable Value",
            Cost: "Cost",
            DepreciationRate: "Depreciation Rate",
            PeriodDepreciation: "Period Depreciation",
            AccumulatedDepreciation: "Accumulated Depreciation",
            Year: "Year"
        };
        $scope.TableColDecreasingBalance = {
            ApplicableValue: "Applicable Value",
            Cost: "Cost",
            DepreciationRate: "Depreciation Rate",
            Year: "Year"
        };

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
        $scope.calculateNormalDepreciation = function () {

            var parameter = {
                Cost: $scope.normalDepreciation.Cost
                , Life: $scope.normalDepreciation.Life
            }

            depreciationService.NormalDepreciation(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        loadTableNormalDecreasing(result.Data);
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

        $scope.decreasingBalanceV1 = [];
        $scope.calculateDecreasingBalanceV1 = function () {

            var parameter = {
                Cost: $scope.decreasingBalanceV1.Cost
                , EconmicLife: $scope.decreasingBalanceV1.EconmicLife
            }


            depreciationService.DecreasingBalanceV1(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        loadTableDecreasingBalance(result.Data);
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


        function loadTableNormalDecreasing(data) {
            $scope.TableParams = new NgTableParams({
                sorting: { name: 'adc' },
                count: 10
            }, {
                counts: [10, 20, 50],
                dataset: data
            });
            $scope.RegisterCountNormalDecreasing = data.length;
            $scope.RegisterCountDecreasingBalance = 0;
        }
        function loadTableDecreasingBalance(data) {
            $scope.TableParams = new NgTableParams({
                sorting: { name: 'adc' },
                count: 10
            }, {
                counts: [10, 20, 50],
                dataset: data
            });
            $scope.RegisterCountDecreasingBalance = data.length;
            $scope.RegisterCountNormalDecreasing = 0;
        }


    }]);
