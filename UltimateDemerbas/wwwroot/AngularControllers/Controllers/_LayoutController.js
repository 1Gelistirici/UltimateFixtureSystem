﻿MainApp.controller("BodyController", ["$scope","$http","$window", function ($scope, $http, $window) {


    $scope.backgroundColor = 'background-color:#1b243b';
    $scope.sideMenu = 'background-color:#f35ad2eb';

    $scope.MenuTitle = [];
    $scope.MenuSub = [];
    $scope.Header = [];
    $scope.MainMenu = [];
    var Menus = null;

    $scope.Nav = function (x) {
        if (x=='') {
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
                console.log("Main Title",$scope.MenuTitle);
            }

            if (element.Area == "Main SubMenu") {
                $scope.MenuSub.push(element);
            }

        });
    });






















    }]);