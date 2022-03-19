MainApp.service("TaskService", ["$http",
    function ($http) {

        this.GetTasks = function (success, error) {
            $http.get("/Task/GetTasks").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
        
        this.GetTask = function (Id,success, error) {
            $http.post("/Task/GetTask", { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteTask = function (Id, success, error) {
            $http.post('/Task/DeleteTask', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };
        
        this.UpdateTask = function (parameter, success, error) {
            $http.post('/Task/UpdateTask', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddTask = function (parameter, success, error) {
            $http.post('/Task/AddTask', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddStatu = function (parameter, success, error) {
            $http.post('/Task/AddStatu', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

