MainApp.service("UsedTonerService", ["$http",
    function ($http) {

        this.GetUsedToners = function (success, error) {
            $http.get("/UsedToner/GetUsedToners").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetUsedTonerByCompanyRefId = function (success, error) {
            $http.get("/UsedToner/GetUsedTonerByCompanyRefId").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetUsedToner = function (success, error) {
            $http.get("/UsedToner/GetUsedToner").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteUsedToner = function (Id, success, error) {
            $http.post('/UsedToner/DeleteUsedToner', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateUsedToner = function (parameter, success, error) {
            $http.post('/UsedToner/UpdateUsedToner', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddUsedToner = function (parameter, success, error) {
            $http.post('/UsedToner/AddUsedToner', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

