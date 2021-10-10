var LoginApp = angular.module('LoginApp', []);

LoginApp.service("LoginService", ["$http",
    function ($http) {

        this.CheckUser = function (parameter, success, error) {
            $http.post('/User/CheckUser/', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };






    }]);

