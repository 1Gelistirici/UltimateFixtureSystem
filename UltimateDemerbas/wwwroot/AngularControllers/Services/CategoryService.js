MainApp.service("CategoryService", ["$http",
    function ($http) {

        this.GetCategories = function (success, error) {
            $http.get("/Category/GetCategories").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetCategoryByCompanyRefId = function (success, error) {
            $http.get("/Category/GetCategoryByCompanyRefId").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteCategory = function (Id, success, error) {
            $http.post('/Category/DeleteCategory', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateCategory = function (parameter, success, error) {
            $http.post('/Category/UpdateCategory', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddCategory = function (parameter, success, error) {
            $http.post('/Category/AddCategory', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

