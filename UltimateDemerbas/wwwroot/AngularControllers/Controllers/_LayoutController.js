var themplateMode = 0;

MainApp.controller("BodyController", ["$scope", "$http", "$window",
    function ($scope, $http, $window) {

        $scope.backgroundColor = 'background-color:#1b243b';
        $scope.sideMenu = 'background-color:#f35ad2eb';

        $(document).ready(function () {
            //themplateMode ==null db ye istek at

            if (themplateMode == 1) {
                $("body").css("background-color", "black");
                $("#pageSubContainer").css("filter", "invert(100%) hue-rotate(180deg) brightness(150%)");
            }
        });

        $scope.MenuTitle = [];
        $scope.MenuSub = [];
        $scope.Header = [];
        $scope.MainMenu = [];
        var Menus = null;

        $scope.Nav = function (x) {
            if (x == '') {
                return;
            }

            $window.location.href = x;
        }

        $http.get("/Layout/GetMenus").then(function (response) {
            Menus = response.data.Data;
            Menus.forEach(function (element) {

                if (element.Dependency == "Main") {
                    $scope.MainMenu.push(element);
                }


                if (element.Area == "Main Header") {
                    $scope.Header.push(element);
                }

                if (element.Area == "Main Title") {
                    $scope.MenuTitle.push(element);
                }

                if (element.Area == "Main SubMenu") {
                    $scope.MenuSub.push(element);
                }

            });
        });

        $scope.LogOut = function () {
            Cookies.remove("id");
        }

        $scope.Exit = function () {
            $http.get("/User/RemoveActiveUserSession").then(function (response) {

            });
        }

    }]);