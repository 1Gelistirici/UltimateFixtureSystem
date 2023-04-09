MainApp.service("AccessoryService", ["$http",
    function ($http) {

        this.GetAccessories = function (success, error) {
            $http.get("/Accessory/GetAccessories").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetAccessory = function (success, error) {
            $http.post("/Accessory/GetAccessory").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetAccessoryByUser = function (success, error) {
            $http.post("/Accessory/GetAccessoryByUser").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DeleteAccessory = function (Id, success, error) {
            $http.post('/Accessory/DeleteAccessory', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateAccessory = function (parameter, success, error) {
            $http.post('/Accessory/UpdateAccessory', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddAccessory = function (parameter, success, error) {
            $http.post('/Accessory/AddAccessory', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

