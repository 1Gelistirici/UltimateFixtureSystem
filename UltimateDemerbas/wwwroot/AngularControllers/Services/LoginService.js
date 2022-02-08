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



        this.RemoveActiveUserSession = function (success, error) {
            $http.get("/User/RemoveActiveUserSession").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        this.SetActiveUserSession = function (id, success, error) {
            $http.post("/User/SetActiveUserSession", JSON.stringify(id)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        this.SetActiveCompanySession = function (companyId, success, error) {
            $http.post("/User/SetActiveCompanySession", JSON.stringify(companyId)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }





    }]);

