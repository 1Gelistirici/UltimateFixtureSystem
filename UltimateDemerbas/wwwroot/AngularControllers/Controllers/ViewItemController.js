MainApp.controller("ViewItemController", ["$scope", "toaster", "FixtureService", "UserService",
    function ($scope, toaster, fixtureService, userService) {

        //#region Parameters
        $scope.Item = [];

        //#endregion


        //#region GETS
        $scope.GetFixture = function () {
            var parameter = {
                Id: 37
            };

            fixtureService.GetFixture(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Item = result.Data;
                        $scope.Item.LoginSystem = formatDate(new Date($scope.Item.LoginSystem));
                        $scope.Item.AsignedUser = $scope.Users.find(x => x.Id === $scope.Item.UserNo);
                        console.log("result.Data", result.Data);


                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmedik bir hata oluştu.");
                });
        }

        $scope.GetUsers = function () {
            userService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                        console.log("Users", result.Data);

                        $scope.GetFixture();
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmedik bir hata oluştu.");
                });
        }
        $scope.GetUsers();

        //#endregion


    }]);
