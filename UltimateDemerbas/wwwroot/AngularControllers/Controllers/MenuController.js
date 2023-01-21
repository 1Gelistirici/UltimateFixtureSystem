MainApp.controller("MenuController", ["$scope", "MenuService", "toaster",
    function ($scope, menuService, toaster) {




        $scope.GetMenu = function () {
            menuService.GetMenu(
                function success(result) {
                    if (result.IsSuccess) {

                        $scope.menuItems = result.Data.filter(x => x.Dependency === 0);

                        console.log("menu", result.Data);
                        console.log("$scope.menuItems", $scope.menuItems);
                    } else {
                        toaster.error("Başarısız", "Menü listelenemedi.");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Menü listelenemedi.");
                });
        }
        $scope.GetMenu();




    }]);



