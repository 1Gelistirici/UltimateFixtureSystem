MainApp.service("DepreciationService", ["$http",
    function ($http) {

        this.FixedAnnualAmount = function (parameter, success, error) {
            $http.post('/Depreciation/FixedAnnualAmount', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };
        
        this.NormalDepreciation = function (parameter, success, error) {
            $http.post('/Depreciation/NormalDepreciation', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DecreasingBalance = function (parameter, success, error) {
            $http.post('/Depreciation/DecreasingBalance', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DecreasingBalanceV1 = function (parameter, success, error) {
            $http.post('/Depreciation/DecreasingBalanceV1', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DepreciationByProductionAmount = function (parameter, success, error) {
            $http.post('/Depreciation/DepreciationByProductionAmount', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);