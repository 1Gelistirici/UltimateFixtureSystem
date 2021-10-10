MainApp.service("SituationService", ["$http",
    function ($http) {

        this.GetSituations = function (success, error) {
            $http.get("/Situation/GetSituations").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteSituation = function (Id, success, error) {
            $http.post('/Situation/DeleteSituation', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateSituation = function (data, success, error) {
            $http.post('/Situation/UpdateSituation', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddSituation = function (data, success, error) {
            $http.post('/Situation/AddSituation', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

