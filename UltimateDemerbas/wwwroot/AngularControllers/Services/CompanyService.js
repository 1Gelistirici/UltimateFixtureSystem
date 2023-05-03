MainApp.service("CompanyService", ["$http",
    function ($http) {

        this.GetComponents = function (success, error) {
            $http.get("/Company/GetComponents").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetCompanyGroup = function (parameter, success, error) {
            $http.post('/Company/GetCompanyGroup', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetCompany = function (parameter, success, error) {
            $http.post('/Company/GetCompany', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DeleteCompany = function (parameter, success, error) {
            $http.post('/Company/DeleteCompany', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddCompany = function (parameter, success, error) {
            $http.post('/Company/AddCompany', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateComponent = function (parameter, success, error) {
            $http.post('/Company/UpdateComponent', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

