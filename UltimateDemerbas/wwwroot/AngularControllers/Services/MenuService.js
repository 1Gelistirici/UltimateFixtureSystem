MainApp.service("MenuService", ["$http",
    function ($http) {

        this.GetMenu = function (success, error) {
            $http.get("/Menu/GetMenu").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

    }]);

