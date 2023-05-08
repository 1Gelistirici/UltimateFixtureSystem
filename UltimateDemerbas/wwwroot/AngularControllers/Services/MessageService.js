MainApp.service("MessageService", ["$http",
    function ($http) {

        this.GetMessages = function (success, error) {
            $http.get("/Message/GetMessages").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetMessageByCompanyRefId = function (success, error) {
            $http.get("/Message/GetMessageByCompanyRefId").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteMessage = function (Id, success, error) {
            $http.post('/Message/DeleteMessage', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddMessage = function (parameter, success, error) {
            $http.post('/Message/AddMessage', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

