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
                        if (result.Data.length > 0) {
                            setCookie("id", result.Data[0].Id, 315);
                            //Cookies.set('id', result.Data[0].Id);
                            toaster.success("Başarılı", "Sisteme giriş yapıldı.");
                            $window.location.href = '/Home/Index';
                        } else {
                            toaster.error("Başarısız", "Kullanıcı adı veya şifre hatalıdır.");
                        }

                    } else {
                        toaster.error("Başarısız", "Sorgu esnasında bir hata ile karşılaşıldı");
                    }
                }, function error() {
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

//cookie ekler
function setCookie(cname, cvalue, exminutes) {
    var d = new Date();
    d.setTime(d.getTime() + (exminutes * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}