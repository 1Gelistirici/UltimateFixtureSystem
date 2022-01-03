MainApp.service("DepartmentService", ["$http",
    function ($http) {

        this.GetDepartments = function (success, error) {
            $http.get("/Department/GetDepartments").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.AddDepartment = function (parameter, success, error) {
            $http.post('/Department/AddDepartment', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateDepartment = function (parameter, success, error) {
            $http.post('/Department/UpdateDepartment', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DeleteDepartment = function (Id, success, error) {
            $http.post('/Department/DeleteDepartment', { Id: Id}).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);