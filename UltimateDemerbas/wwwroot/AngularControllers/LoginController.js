LoginApp.controller("LoginController", ["$scope", "LoginService", "$window", "toaster",
    function ($scope, LoginService, $window, toaster) {

        $scope.LoginButton = false;
        $scope.forgetForm = true;
        $scope.resetPasswordForm = false;

        $scope.CheckUser = function () {
            $scope.LoginButton = true;
            var parameter = {
                UserName: $scope.User.Username,
                Password: $scope.User.Password,
                Company: $scope.User.Company,
                RememberMe: $scope.User.RememberMe
            }

            LoginService.CheckUser(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $window.location.href = '/Home/Index';
                    } else {
                        $scope.LoginButton = false;
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
                        //toaster.success("Başarılı", result.Message);
                        $scope.second = 60;
                        $scope.forgetForm = false;
                        $scope.resetPasswordForm = true;
                        toaster.success("Mail gönderilmiştir.", "Gönderilen kod 5 dakika içinde kullanılmalıdır.");

                        var forgetInterval = setInterval(function () {
                            $scope.second = $scope.second - 1;

                            if ($scope.second === 1) {
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

        $scope.ForgetPasswordChange = function () {
            $scope.resetSendButton = false;
            var parameter = {
                CodeString: $scope.code,
                Password: $scope.password,
                TryPassword: $scope.tryPassword
            }

            LoginService.ForgetPasswordChange(parameter,
                function success(result) {
                    $scope.resetSendButton = true;
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", result.Message);
                        location.reload();
                    } else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    $scope.resetSendButton = true;
                    toaster.error("Başarısız", "Sorgu esnasında bir hata ile karşılaşıldı");
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