MainApp.service("FixtureService", ["$http",
    function ($http) {

        this.GetMenuCompany = function (success, error) {
            $http.get("/Menu/GetMenuCompany").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

    }]);

