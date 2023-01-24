MainApp.service("MenuService", ["$http",
    function ($http) {

        this.GetMenu = function (success, error) {
            $http.get("/Menu/GetMenu").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.UpdateMenu = function (parameter, success, error) {
            $http.post('/Menu/UpdateMenu/', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddMenu = function (parameter, success, error) {
            $http.post('/Menu/AddMenu/', JSON.stringify(parameter)).then( 
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DeleteMenu = function (parameter, success, error) {
            $http.post('/Menu/DeleteMenu/', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

