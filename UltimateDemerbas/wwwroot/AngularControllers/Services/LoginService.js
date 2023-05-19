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
        this.AddCompanyV1 = function (parameter, success, error) {
            $http.post("/Login/AddCompanyV1", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        this.SetEmailValidation = function (parameter, sessionId, success, error) {
            $http.post("/Login/SetEmailValidation?sessionId=" + sessionId, JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        this.IsValidateCode = function (parameter, success, error) {
            $http.post('/Login/IsValidateCode', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

