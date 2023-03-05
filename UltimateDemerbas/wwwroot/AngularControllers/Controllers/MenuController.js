MainApp.controller("MenuController", ["$scope", "MenuService", "toaster",
    function ($scope, menuService, toaster) {


        $scope.Menu = [];

        $scope.GetMenu = function () {
            menuService.GetMenu(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.menuItems = result.Data.filter(x => x.Dependency === 0);
                    } else {
                        toaster.error("Başarısız", "Menü listelenemedi.");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Menü listelenemedi.");
                });
        }
        $scope.GetMenu();


        $scope.DeleteMenu = function () {



        }


        $scope.btnMenuInsertPopUp = function (parentId) {
            $scope.insertMenuData = [];
            $scope.ParentId = parentId;
            //$scope.MenuOptions = parentId === 0 ? 1 : 0;
            $("#menuInsertPopup").modal("show");
        }

        $scope.btnMenuUpdatePopUp = function (menu) {
            $scope.updateMenuData = [];
            $("#menuUpdatePopup").modal("show");
            $scope.updateMenuData = menu;
        }

        $scope.updateMenu = function () {
            App.blockUI();

            //if (!validateSaveParameters()) {
            var parameters = {
                Id: $scope.updateMenuData.Id,
                Dependency: $scope.updateMenuData.Dependency,
                Name: $scope.updateMenuData.Name,
                Url: $scope.updateMenuData.Url,
                Icon: $scope.updateMenuData.Icon,
                Order: $scope.updateMenuData.Order,
                Order: $scope.updateMenuData.IsHaveProblem
            };

            menuService.UpdateMenu(parameters,
                function success(response) {
                    if (response.IsSuccess) {
                        location.replace("/Menu/Index");
                        toaster.success("Kaydetme", "Kaydetme işlemi başarılı");
                        App.unblockUI();
                    } else {
                        toaster.error("Kaydetme", "Kaydetme işlemi yapılırken bir hata oluştu");
                        App.unblockUI();
                    }

                },
                function error() {
                    toaster.error("Kaydetme", "Kaydetme işlemi yapılırken bir hata oluştu");
                    App.unblockUI();
                });
            //} else {
            //    toaster.error("Kaydetme", "Lütfen zorunlu alanları doldurunuz");
            //    App.unblockUI();
            //}
        };




        function validateSaveParameters() {

            var result = false;
            if (!$scope.Menu || !$scope.Menu.MenuName || $scope.Menu.MenuName === "") {
                $scope.menuNameSituation = true;
                generalValidation = true;
            }

            if (!$scope.Menu || !$scope.Menu.MenuLink || $scope.Menu.MenuLink === "") {
                $scope.menuLinkSituation = true;
                generalValidation = true;
            }

            if (!$scope.Menu || !$scope.Menu.MenuIcon || $scope.Menu.MenuIcon === "") {
                $scope.menuIconSituation = true;
                generalValidation = true;
            }

            return result;
        }

        $scope.SaveMenu = function () {
            App.blockUI();

            if (!validateSaveParameters()) {
                var parameters = {
                    Dependency: $scope.ParentId,
                    Name: $scope.Menu.MenuName,
                    Url: $scope.Menu.MenuLink,
                    Icon: $scope.Menu.MenuIcon,
                    Order: $scope.MenuOptions
                };

                menuService.AddMenu(parameters,
                    function success(response) {
                        if (response.IsSuccess) {
                            location.replace("/Menu/Index");
                            toaster.success("Kaydetme", "Kaydetme işlemi başarılı");
                            App.unblockUI();
                        } else {
                            toaster.error("Kaydetme", "Kaydetme işlemi yapılırken bir hata oluştu");
                            App.unblockUI();
                        }

                    },
                    function error() {
                        toaster.error("Kaydetme", "Kaydetme işlemi yapılırken bir hata oluştu");
                        App.unblockUI();
                    });
            } else {
                toaster.error("Kaydetme", "Lütfen zorunlu alanları doldurunuz");
                App.unblockUI();
            }
        };



        $scope.DeleteMenu = function (id) {

            if (!id) {
                toaster.error("Menü seçilmeli.");
                return;
            }

            App.blockUI();
            swal({
                title: "Emin misiniz?",
                text: "Bu menüyü silmek istediğinizden emin misiniz?, (Menüye bağlı alt menüler de silinecektir)",
                icon: "warning",
                buttons: true,
                dangerMode: true,
                buttons: ['İptal', 'Evet']

            })
                .then((willDelete) => {
                    if (willDelete) {

                        var parameter = {
                            Id: id
                        }

                        if (id) {
                            menuService.DeleteMenu(parameter,
                                function success(response) {
                                    if (response.IsSuccess) {
                                        location.replace("/Menu/Index");
                                        toaster.success("Silme", "Silme işlemi başarılı");
                                        App.unblockUI();
                                    } else {
                                        toaster.error("Silme", "Silme işlemi yapılırken bir hata oluştu");
                                        App.unblockUI();
                                    }
                                },
                                function error() {
                                    toaster.error("Silme", "Silme işlemi yapılırken bir hata oluştu");
                                    App.unblockUI();
                                });
                        }
                        else {
                            toaster.error("Silme", "Silme işlemi yapılırken bir hata oluştu");
                            App.unblockUI();
                        }

                    } else {
                        App.unblockUI();
                    }
                });
        };

    }]);



