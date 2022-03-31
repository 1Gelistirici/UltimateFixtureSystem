MainApp.service("RelevantPersonnelService", ["$http",
    function ($http) {

        this.GetRelevantPersonnels = function (success, error) {
            $http.get("/RelevantPersonnel/GetRelevantPersonnels").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteRelevantPersonnel = function (Id, success, error) {
            $http.post('/RelevantPersonnel/DeleteRelevantPersonnel', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddRelevantPersonnel = function (parameter, success, error) {
            $http.post('/RelevantPersonnel/AddRelevantPersonnel', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

