LoginApp.controller("LoginController", ["$scope", "LoginService", "$window", "toaster",
    function ($scope, LoginService, $window, toaster) {

        $scope.CheckUser = function () {
            var parameter = {
                UserName: $scope.User.Username,
                Password: $scope.User.Password,
                Company: $scope.User.Company
            }

            LoginService.CheckUser(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        var parameter = {
                            Id: result.Data[0].Id,
                            CompanyId: result.Data[0].CompanyId
                        }
                        SetUserSession(parameter);

                        toaster.success("Başarılı", "Sisteme giriş yapıldı.");
                        $window.location.href = '/Home/Index';
                    } else {
                        toaster.error("Başarısız", "Kullanıcı adı veya şifre hatalıdır.");
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