MainApp.service("ComponentModelService", ["$http",
    function ($http) {

        this.GetComponentModels = function (success, error) {
            $http.get("/ComponentModel/GetComponentModels").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteComponentModel = function (Id, success, error) {
            $http.post('/ComponentModel/DeleteComponentModel', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateComponentModel = function (data, success, error) {
            $http.post('/ComponentModel/UpdateComponentModel', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddComponentModel = function (data, success, error) {
            $http.post('/ComponentModel/AddComponentModel', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

