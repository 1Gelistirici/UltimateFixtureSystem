MainApp.service("LicenseService", ["$http",
    function ($http) {

        this.GetLicenses = function (success, error) {
            $http.get("/License/GetLicenses").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetLicenceByCompanyRefId = function (success, error) {
            $http.get("/License/GetLicenceByCompanyRefId").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteLicense = function (Id, success, error) {
            $http.post('/License/DeleteLicense', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateLicense = function (data, success, error) {
            $http.post('/License/UpdateLicense', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddLicense = function (data, success, error) {
            $http.post('/License/AddLicense', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

