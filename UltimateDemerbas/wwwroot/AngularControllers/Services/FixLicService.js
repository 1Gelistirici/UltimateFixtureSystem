MainApp.service("FixLicService", ["$http",
    function ($http) {

        this.AddFixLic = function (parameter, success, error) {
            $http.post('/FixLic/AddFixLic', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetFixLices = function (success, error) {
            $http.get('/FixLic/GetFixLices').then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DeleteFixLic = function (parameter, success, error) {
            $http.post('/FixLic/DeleteFixLic', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

