MainApp.service("FixtureModelService", ["$http",
    function ($http) {

        this.GetFixtureModels = function (success, error) {
            $http.get("/FixtureModel/GetFixtureModels").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteFixtureModel = function (Id, success, error) {
            $http.post('/FixtureModel/DeleteFixtureModel', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateFixtureModel = function (data, success, error) {
            $http.post('/FixtureModel/UpdateFixtureModel', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddFixtureModel = function (data, success, error) {
            $http.post('/FixtureModel/AddFixtureModel', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetFixtureModelByCompanyRefId = function (success, error) {
            $http.post('/FixtureModel/GetFixtureModelByCompanyRefId').then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

