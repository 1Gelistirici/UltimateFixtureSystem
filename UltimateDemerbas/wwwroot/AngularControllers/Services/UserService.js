MainApp.service("UserService", ["$http",
    function ($http) {

        this.GetUser = function (success, error) {
            $http.get("/User/GetUser").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetUsers = function (success, error) {
            $http.get("/User/GetUsers").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.AddUser = function (parameter, files, success, error) {
            //$http.post("/User/AddUser", JSON.stringify(parameter)).then(
            //    function (response) {
            //        if (success)
            //            success(response.data);
            //    }, error);

            var fd = new FormData();

            fd.append(files.name, files);
            fd.append("parameter", JSON.stringify(parameter));

            var request = {
                method: 'POST',
                url: '/User/AddUser',
                data: fd,
                headers: {
                    'Content-Type': undefined
                }
            };

            $http(request).then(
                function (response) {
                    if (success) {
                        success(response.data);
                    }
                }, error);
        }


        this.UpdateUser = function (parameter, success, error) {
            //$http.post("/User/UpdateUser", JSON.stringify(parameter)).then(
            //    function (response) {
            //        if (success)
            //            success(response.data);
            //    }, error);

            var fd = new FormData();

            fd.append(parameter.file.name, parameter.file);
            fd.append("parameter", JSON.stringify(parameter));

            var request = {
                method: 'POST',
                url: '/User/UpdateUser',
                data: fd,
                headers: {
                    'Content-Type': undefined
                }
            };

            $http(request).then(
                function (response) {
                    if (success) {
                        success(response.data);
                    }
                }, error);
        }

        this.GetUserCompany = function (success, error) {
            $http.get("/User/GetUserCompany").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.ChangePassword = function (parameter, success, error) {
            $http.post("/User/ChangePassword", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.UpdateProfile = function (parameter, success, error) {
            $http.post("/User/UpdateProfile", JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteUser = function (Id, success, error) {
            $http.post("/User/DeleteUser", { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

    }]);

