var themplateMode = 0;

MainApp.controller("BodyController", ["$scope", "$http", "$window", "toaster", "FeedbackService",
    function ($scope, $http, $window, toaster, feedbackService) {

        $scope.layoutCompanyName = Cookies.get('companyName');
        $scope.layoutUserName = Cookies.get('userName');
        $scope.layoutImage = Cookies.get('userImage');
        $scope.menuType = { Main: 0, MainHeader: 1, MainTitle: 2, MainSubMenu: 3 };

        $scope.backgroundColor = 'background-color:#1b243b';
        $scope.sideMenu = 'background-color:#f35ad2eb';

        $(document).ready(function () {

            if (themplateMode === 1) {
                $("body").css("background-color", "black");
                $("#pageSubContainer").css("filter", "invert(100%) hue-rotate(180deg) brightness(150%)");
            }

            if ($scope.layoutImage) {
                $("#knownImage").removeClass("hide");
            }
            else {
                $("#unknownImage").removeClass("hide");
            }
        });

        $scope.MenuTitle = [];
        $scope.MenuSub = [];
        $scope.Header = [];
        $scope.MainMenu = [];

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

            $scope.Menus = response.data.Data;
        });

        $scope.LogOut = function () {
            Cookies.remove("id");
        }

        $scope.Exit = function () {
            $http.get("/User/RemoveActiveUserSession").then(function (response) {

            });
        }

        $scope.setLanguage = function (culture, returnUrl) {
            console.log(culture);
            console.log(returnUrl);

            $.ajax({
                url: "/Home/SetLanguage",
                method: "POST",
                data: { culture: culture, returnUrl: returnUrl },
                success: function (response) {
                    location.reload();
                },
                error: function (error) {
                    console.log("İstek sırasında hata oluştu");
                }
            });
        }

        $scope.feedBackSubmit = function () {
            var parameter = {
                Title: $scope.feedBackTitle,
                Comment: $scope.feedBackComment
            }

            feedbackService.AddFeedback(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $("#FeedBack").modal("hide");
                        $scope.feedBackTitle = "";
                        $scope.feedBackComment = "";
                        toaster.success("Thank You");
                    } else {
                        toaster.error("Feedback", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Feedback", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);