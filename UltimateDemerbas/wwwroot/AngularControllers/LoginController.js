
LoginApp.controller("LoginController", ["$scope", "$http", "LoginService", "$window", function ($scope, $http, LoginService, $window) {


    $scope.CheckUser = function () {

        var parameter = {
            UserName: $scope.User.Username,
            Password: $scope.User.Password,
            Company: $scope.User.Company
        }

        console.log($scope.User);

        LoginService.CheckUser(parameter,
            function success(result) {
                if (result.IsSuccess) {
                    if (result.Data.length > 0) {

                        console.log("Başarılı", result);

                        Cookies.set('id', result.Data[0].Id);

                        $window.location.href = '/Home/Index';
                    } else {
                        console.log("Başarısız", result);
                    }

                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }





}]);
