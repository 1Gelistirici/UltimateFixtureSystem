MainApp.service("UserRoleService", ["$http",
    function ($http) {

        this.GetRole = function (parameter,success, error) {
            $http.post("/UserRole/GetRole", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteRole = function (Id, success, error) {
            $http.post('/UserRole/DeleteRole', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddRole = function (parameter, success, error) {
            $http.post('/UserRole/AddRole', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddRoleList = function (parameter, success, error) {
            $http.post('/UserRole/AddRoleList', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

