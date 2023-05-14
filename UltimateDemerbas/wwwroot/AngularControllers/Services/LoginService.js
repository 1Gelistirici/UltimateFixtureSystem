var LoginApp = angular.module('LoginApp', ['toaster']);

LoginApp.service("LoginService", ["$http",
    function ($http) {

        this.CheckUser = function (parameter, success, error) {
            $http.post('/User/CheckUser/', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.ForgetPassword = function (parameter, success, error) {
            $http.post('/User/ForgetPassword/', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.ForgetPasswordChange = function (parameter, success, error) {
            $http.post('/User/ForgetPasswordChange/', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.RemoveActiveUserSession = function (success, error) {
            $http.get("/User/RemoveActiveUserSession").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        this.SetUserSession = function (parameter, success, error) {
            $http.post("/User/SetUserSession", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        this.AddCompany = function (parameter, success, error) {
            $http.post("/Company/AddCompany", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        this.AddUser = function (parameter, success, error) {
            $http.post("/Company/AddUser", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

    }]);

