MainApp.service("TonerService", ["$http",
    function ($http) {

        this.GetToners = function (success, error) {
            $http.get("/Toner/GetToners").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetTonerByCompanyRefId = function (success, error) {
            $http.get("/Toner/GetTonerByCompanyRefId").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteToner = function (Id, success, error) {
            $http.post('/Toner/DeleteToner', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateToner = function (parameter, success, error) {
            $http.post('/Toner/UpdateToner', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddToner = function (parameter, success, error) {
            $http.post('/Toner/AddToner', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

