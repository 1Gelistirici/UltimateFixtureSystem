MainApp.service("FixLicService", ["$http",
    function ($http) {

        this.AddFixLic = function (parameter, success, error) {
            $http.post('/FixLic/AddFixLic', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

