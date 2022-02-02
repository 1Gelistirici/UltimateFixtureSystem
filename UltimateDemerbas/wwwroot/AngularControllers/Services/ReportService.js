MainApp.service("ReportService", ["$http",
    function ($http) {

        this.GetReports = function (success, error) {
            $http.get("/Report/GetReports").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        
        this.GetPassiveReports = function (success, error) {
            $http.get("/Report/GetPassiveReports").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.AddReport = function (parameter, success, error) {
            $http.post('/Report/AddReport', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateReportStatu = function (parameter, success, error) {
            $http.post('/Report/UpdateReportStatu', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

