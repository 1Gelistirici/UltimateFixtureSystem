MainApp.service("AssignmentService", ["$http",
    function ($http) {

        this.GetAssignments = function (success, error) {
            $http.get("/Assignment/GetAssignments").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteAssignment = function (parameter, success, error) {
            $http.post('/Assignment/DeleteAssignment', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateAssignment = function (parameter, success, error) {
            $http.post('/Assignment/UpdateAssignment', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddAssignment = function (parameter, success, error) {
            $http.post('/Assignment/AddAssignment', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetAssignmentUser = function (success, error) {
            $http.get("/Assignment/GetAssignmentUser").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

    }]);