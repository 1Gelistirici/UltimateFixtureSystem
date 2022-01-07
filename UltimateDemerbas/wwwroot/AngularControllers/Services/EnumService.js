MainApp.service("EnumService", ["$http",
    function ($http) {

        this.GetIsActiveTypes = function (success, error) {
            $http.get("/Enum/GetIsActiveTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetItemStatuTypes = function (success, error) {
            $http.get("/Enum/GetItemStatuTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetItemTypeTypes = function (success, error) {
            $http.get("/Enum/GetItemTypeTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }


    }]);

