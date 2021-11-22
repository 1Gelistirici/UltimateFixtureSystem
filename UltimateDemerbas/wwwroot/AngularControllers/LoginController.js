
LoginApp.controller("LoginController", ["$scope", "$http", "LoginService", "$window", function ($scope, $http, LoginService, $window) {


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
                        $window.location.href = '/Home/Index';
                    } else {
                    }

                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
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