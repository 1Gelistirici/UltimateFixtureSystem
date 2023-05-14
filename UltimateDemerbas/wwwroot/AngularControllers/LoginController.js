LoginApp.controller("LoginController", ["$scope", "LoginService", "$window", "toaster",
    function ($scope, LoginService, $window, toaster) {

        $scope.LoginButton = false;
        $scope.forgetForm = true;
        $scope.resetPasswordForm = false;
        $scope.register = [];

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
                    }
                    else {
                        $scope.LoginButton = false;
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    $scope.LoginButton = false;
                    toaster.error("Başarısız", "Beklenmeyen bir hata ile karşılaşıldı");
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


        $scope.addCompany = function () {
            var parameter = {
                Name: $scope.register.CompanyName
            }

            //$.ajax({
            //    type: "POST",
            //    url: "/Company/AddCompany",
            //    contentType: "application/json; charset=utf-8",
            //    data: JSON.stringify(parameter),
            //    dataType: "json",
            //    async: false,
            //    success: function (data) {
            //        console.log("12", data);
            //    },
            //    error: function (ex) {
            //        console.log("Hata", ex);
            //    }
            //});

            LoginService.AddCompany(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        console.log("qwe", result);
                        //addUser(result.ResultId);
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmeyen bir hata ile karşılaşıldı");
                });
        }

        function addUser(companyRefId) {
            var parameter = {
                Name: $scope.register.Name,
                Surname: $scope.register.Surname,
                UserName: $scope.register.UserName,
                Password: $scope.register.Password,
                MailAdress: $scope.register.Email,
                CompanyId: companyRefId
            }

            LoginService.AddUser(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı");
                        location.reload();
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmeyen bir hata ile karşılaşıldı");
                });
        }




        //Enter'a basıldığında
        $(document).keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode === 13) //Enter
            {
                $scope.CheckUser();
            }
            //else if (keycode === 32) //Space
            //{
            //    $scope.User.RememberMe = !$scope.User.RememberMe;
            //}
        });

    }]);