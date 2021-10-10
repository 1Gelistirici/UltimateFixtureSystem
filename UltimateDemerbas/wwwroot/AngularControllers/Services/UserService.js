MainApp.service("UserService", ["$http",
    function ($http) {

        this.GetUser = function (success, error) {
            $http.get("/User/GetUser").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        
        this.ChangePassword = function (parameter,success, error) {
            $http.post("/User/ChangePassword", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }





    }]);

