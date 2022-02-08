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
                        SetActiveUserSession(54);
                        SetActiveCompanySession(51);
                        toaster.success("Başarılı", "Sisteme giriş yapıldı.");

                        return;
                        $window.location.href = '/Home/Index';
                    } else {
                        toaster.error("Başarısız", "Kullanıcı adı veya şifre hatalıdır.");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Sorgu esnasında bir hata ile karşılaşıldı");
                });
        }


        function SetActiveUserSession(id) {
            LoginService.SetActiveUserSession(id,
                function success(result) {
                });
        }

        function SetActiveCompanySession(companyId) {
            LoginService.SetActiveCompanySession(companyId,
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