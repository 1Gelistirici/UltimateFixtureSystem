MainApp.service("ItemHistoryService", ["$http",
    function ($http) {

        this.GetItemHistoryByCompany = function (success, error) {
            $http.get("/ItemHistory/GetItemHistoryByCompany").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.AddItemHistory = function (parameter, success, error) {
            $http.post('/ItemHistory/AddItemHistory', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

