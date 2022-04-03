LoginApp.controller("LoginController", ["$scope", "LoginService", "$window", "toaster",
    function ($scope, LoginService, $window, toaster) {

        $scope.LoginButton = false;

        $scope.CheckUser = function () {
            $scope.LoginButton = true;
            var parameter = {
                UserName: $scope.User.Username,
                Password: $scope.User.Password,
                Company: $scope.User.Company
            }

            LoginService.CheckUser(parameter,
                function success(result) {
                    $scope.LoginButton = false;
                    if (result.IsSuccess) {
                        var parameter = {
                            Id: result.Data.Id,
                            CompanyId: result.Data.CompanyId,
                            RememberMe: $scope.User.RememberMe
                        }
                        SetUserSession(parameter);

                        toaster.success("Başarılı", result.Message);
                        $window.location.href = '/Home/Index';
                    } else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    $scope.LoginButton = false;
                    toaster.error("Başarısız", "Sorgu esnasında bir hata ile karşılaşıldı");
                });
        }

        $scope.ForgetPassword = function () {
            $scope.forgetSendButton = true;

            var parameter = {
                Company: $scope.forgetCompany,
                UserName: $scope.forgetUsername
            }

            LoginService.ForgetPassword(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.forgetCompany = "";
                        $scope.forgetUsername = "";
                        toaster.success("Başarılı", result.Message);
                        $scope.second = 60;

                        var forgetInterval = setInterval(function () {
                            $scope.second = $scope.second - 1;

                            if ($scope.second === 0) {
                                $scope.forgetSendButton = false;
                                clearInterval(forgetInterval);
                            }
                        }, 1000);
                    } else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Sorgu esnasında bir hata ile karşılaşıldı");
                });
        }


        function SetUserSession(parameter) {
            LoginService.SetUserSession(parameter,
                function success(result) {
                });
        }


        //Enter'a basıldığında
        $(document).keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                $scope.CheckUser();
            }
        });

    }]);