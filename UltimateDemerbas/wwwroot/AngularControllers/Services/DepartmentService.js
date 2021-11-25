MainApp.service("DepartmentService", ["$http",
    function ($http) {

        this.GetDepartments = function (success, error) {
            $http.get("/Department/GetDepartments").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }


    }]);