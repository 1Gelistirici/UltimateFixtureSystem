MainApp.service("LogService", ["$http",
    function ($http) {

        this.GetLogs = function (success, error) {
            $http.get("/Log/GetLogs").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteLog = function (Id, success, error) {
            $http.post('/Log/DeleteLog', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddLog = function (parameter, success, error) {
            $http.post('/Log/AddLog', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

