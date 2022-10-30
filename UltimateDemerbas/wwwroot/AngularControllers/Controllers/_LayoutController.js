var themplateMode = 0;

MainApp.controller("BodyController", ["$scope", "$http", "$window", "toaster",
    function ($scope, $http, $window, toaster) {

        $scope.menuType = { Main: 0, MainHeader: 1, MainTitle: 2, MainSubMenu: 3 };

        $scope.backgroundColor = 'background-color:#1b243b';
        $scope.sideMenu = 'background-color:#f35ad2eb';

        $(document).ready(function () {
            //themplateMode == null db ye istek at

            if (themplateMode === 1) {
                $("body").css("background-color", "black");
                $("#pageSubContainer").css("filter", "invert(100%) hue-rotate(180deg) brightness(150%)");
            }
        });

        $scope.MenuTitle = [];
        $scope.MenuSub = [];
        $scope.Header = [];
        $scope.MainMenu = [];
        var Menus = null;

        $scope.Nav = function (url) {
            if (!url) {
                return;
            }

            $window.location.href = url;
        }

        $http.get("/Layout/GetMenus").then(function (response) {
            if (!response.data || !response.data.IsSuccess) {
                toaster.error("Başarısız", "Menü yüklenemedi.");
                return;
            }

            Menus = response.data.Data;
            $scope.Menus = response.data.Data;

            console.log($scope.Menus);

            //var menuType = { Main: 0, MainHeader: 1, MainTitle: 2, MainSubMenu: 3 };

            //$scope.MainMenu = Menu.filter(x => x.Dependency === menuType.Main);
            //$scope.Header = Menu.filter(x => x.Area === menuType.MainHeader);
            //$scope.MenuTitle = Menu.filter(x => x.Area === menuType.MainTitle);
            //$scope.MenuSub = Menu.filter(x => x.Area === menuType.MainSubMenu);

            Menus.forEach(function (element) {

                //if (element.Dependency === menuType.Main) {
                //    $scope.MainMenu.push(element);
                //}

                //if (element.Area === menuType.MainHeader) {
                //    $scope.Header.push(element);
                //}

                //if (element.Area === menuType.MainTitle) {
                //    $scope.MenuTitle.push(element);
                //}

                //if (element.Area === menuType.MainSubMenu) {
                //    $scope.MenuSub.push(element);
                //}



                //if (element.Dependency == "Main") {
                //    $scope.MainMenu.push(element);
                //}


                //if (element.Area == "Main Header") {
                //    $scope.Header.push(element);
                //}

                //if (element.Area == "Main Title") {
                //    $scope.MenuTitle.push(element);
                //}

                //if (element.Area == "Main SubMenu") {
                //    $scope.MenuSub.push(element);
                //}

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