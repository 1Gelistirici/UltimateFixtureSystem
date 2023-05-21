MainApp.service("AccessoryModelService", ["$http",
    function ($http) {

        this.GetAccessoryModels = function (success, error) {
            $http.get("/AccessoryModel/GetAccessoryModels").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteAccessoryModel = function (Id, success, error) {
            $http.post('/AccessoryModel/DeleteAccessoryModel', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetAccessoryModelByCompanyRefId = function (success, error) {
            $http.get('/AccessoryModel/GetAccessoryModelByCompanyRefId').then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateAccessoryModel = function (data, success, error) {
            $http.post('/AccessoryModel/UpdateAccessoryModel', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddAccessoryModel = function (data, success, error) {
            $http.post('/AccessoryModel/AddAccessoryModel', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

