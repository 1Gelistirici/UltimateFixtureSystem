MainApp.service("ComponentService", ["$http",
    function ($http) {

        this.GetComponents = function (success, error) {
            $http.get("/Component/GetComponents").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteComponent = function (Id, success, error) {
            $http.post('/Component/DeleteComponent', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateComponent = function (parameter, success, error) {
            $http.post('/Component/UpdateComponent', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddComponent = function (parameter, success, error) {
            $http.post('/Component/AddComponent', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

