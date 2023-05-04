MainApp.service("CompanyService", ["$http",
    function ($http) {

        this.GetCompanies = function (success, error) {
            $http.get("/Company/GetCompanies").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetCompanyGroup = function (success, error) {
            $http.get('/Company/GetCompanyGroup').then(
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
            var fd = new FormData();

            fd.append(parameter.file.name, parameter.file);
            fd.append("parameter", JSON.stringify(parameter));

            var request = {
                method: 'POST',
                url: '/Comoany/UpdateCompany',
                data: fd,
                headers: {
                    'Content-Type': undefined
                }
            };

            $http(request).then(
                function (response) {
                    if (success) {
                        success(response.data);
                    }
                }, error);
        };

    }]);

