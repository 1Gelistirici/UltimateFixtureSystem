MainApp.service("CodeService", ["$http",
    function ($http) {

        this.AddCode = function (parameter, success, error) {
            $http.post('/Code/AddCode', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetCode = function (parameter, success, error) {
            $http.post('/Code/GetCode', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetCodeV1 = function (parameter, success, error) {
            $http.post('/Code/GetCodeV1', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.IsValidateCode = function (parameter, success, error) {
            $http.post('/Code/IsValidateCode', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

