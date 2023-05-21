MainApp.service("LicenseTypeService", ["$http",
    function ($http) {

        this.GetLicensesTypes = function (success, error) {
            $http.get("/LicensesTypes/GetLicensesTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteLicensesTypes = function (id, success, error) {
            $http.post('/LicensesTypes/DeleteLicensesTypes', { id: id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateLicensesTypes = function (data, success, error) {
            $http.post('/LicensesTypes/UpdateLicenseType', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddLicenseType = function (data, success, error) {
            $http.post('/LicensesTypes/AddLicenseType', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetLicenseTypeByCompanyRefId = function (success, error) {
            $http.post('/LicensesTypes/GetLicenseTypeByCompanyRefId').then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

