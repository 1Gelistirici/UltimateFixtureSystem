MainApp.service("UserService", ["$http",
    function ($http) {

        this.GetUser = function (id, success, error) {
            $http.get("/User/GetUser", { id: id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetUsers = function (success, error) {
            $http.get("/User/GetUsers").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        
        this.AddUser = function (success, error) {
            $http.post("/User/AddUser").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetUserCompany = function (success, error) {
            $http.get("/User/GetUserCompany").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.ChangePassword = function (parameter, success, error) {
            $http.post("/User/ChangePassword", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.UpdateProfile = function (parameter, success, error) {
            $http.post("/User/UpdateProfile", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

    }]);

