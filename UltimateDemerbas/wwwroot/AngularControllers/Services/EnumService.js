MainApp.service("EnumService", ["$http",
    function ($http) {

        this.GetIsActiveTypes = function (success, error) {
            $http.get("/Enum/GetIsActiveTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }


    }]);

