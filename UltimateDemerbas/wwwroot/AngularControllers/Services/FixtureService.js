MainApp.service("FixtureService", ["$http",
    function ($http) {

        this.GetFixtures = function (success, error) {
            $http.get("/Fixture/GetFixtures").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetFixture = function (parameter, success, error) {
            $http.post("/Fixture/GetFixture", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetFixtureByUser = function (Id, success, error) {
            $http.post("/Fixture/GetFixtureByUser", { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.AddFixture = function (parameter, success, error) {
            $http.post('/Fixture/AddFixture', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateFixture = function (parameter, success, error) {
            $http.post('/Fixture/UpdateFixture', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DeleteFixture = function (Id, success, error) {
            $http.post('/Fixture/DeleteFixture', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };
    }]);

