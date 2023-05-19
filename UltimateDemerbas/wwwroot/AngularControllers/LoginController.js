LoginApp.controller("LoginController", ["$scope", "LoginService", "$window", "toaster",
    function ($scope, LoginService, $window, toaster) {

        $scope.LoginButton = false;
        $scope.forgetForm = true;
        $scope.resetPasswordForm = false;
        $scope.register = [];
        $scope.remainingTime = "5:00";
        var remainingTimeInterval = null;
        var sessionId = sessionStorage.getItem('sessionId');

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
            isValidateCode()
        }
        $scope.nextValidation = function () {
            sendEmailValidationMessage();
        }

        function addCompany() {
            var user = {
                Name: $scope.register.Name,
                Surname: $scope.register.Surname,
                UserName: $scope.register.UserName,
                Password: $scope.register.Password,
                MailAdress: $scope.register.Email
            }

            var parameter = {
                Name: $scope.register.CompanyName
                , User: user
            }

            LoginService.AddCompanyV1(parameter,
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
        function isValidateCode() {

            var parameter = {
                CodeString: $scope.register.EmailValidationCode,
                SessionId: sessionId
            };

            LoginService.IsValidateCode(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        addCompany();
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmeyen bir hata ile karşılaşıldı");
                });
        }
        function sendEmailValidationMessage() {

            var parameter = {
                MailAdress: $scope.register.Email
            };

            LoginService.SetEmailValidation(parameter, sessionId,
                function success(result) {
                    if (result.IsSuccess) {
                        startRemainingTimeInterval();
                        toaster.success("Kod gönderildi. 5 dakika içerimde kodu giriniz.");
                        $("#emailValidationPopup").modal("show");

                        if (!sessionId) {
                            sessionId = generateUUID();
                            sessionStorage.setItem('sessionId', sessionId);
                        }

                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmeyen bir hata ile karşılaşıldı");
                });

        }

        function startRemainingTimeInterval() {

            var remainingTimeSecond = 300;
            if (remainingTimeInterval) {
                clearInterval(remainingTimeInterval);
            }

            remainingTimeInterval = setInterval(function () {
                remainingTimeSecond--;
                $scope.safeApply(function () {
                    $scope.remainingTime = formatDateSecondV1(remainingTimeSecond);
                });
            }, 1000);

        }
        $scope.safeApply = function (fn) {
            var phase = this.$root.$$phase;
            if (phase === '$apply' || phase === '$digest') {
                if (fn && typeof fn === 'function') {
                    fn();
                }
            } else {
                this.$apply(fn);
            }
        };

        $scope.cancelEmailValidation = function () {
            var parameter = {
                MailAdress: $scope.register.Email
            };

            LoginService.Set(parameter, sessionId,
                function success(result) {
                    if (result.IsSuccess) {
                        startRemainingTimeInterval();
                        toaster.success("Kod gönderildi. 5 dakika içerimde kodu giriniz.");
                        $("#emailValidationPopup").modal("show");

                        if (!sessionId) {
                            sessionId = generateUUID();
                            sessionStorage.setItem('sessionId', sessionId);
                        }

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