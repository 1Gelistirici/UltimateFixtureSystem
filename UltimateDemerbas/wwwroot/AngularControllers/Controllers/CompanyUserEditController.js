MainApp.controller("CompanyUserEditController", ["$scope", "NgTableParams", "toaster", "UserRoleService",
    function ($scope, NgTableParams, toaster, userRoleService) {

        $scope.ClearCompanyUserInsertPopup = function () {

            $scope.CompanyName = null;
            $scope.FirstName = null;
            $scope.Title = null;
            $scope.MiddleName = null;
            $scope.LastName = null;
            $scope.BirthDate = null;
            $scope.CompanyGroupName = null;
            $scope.Gender = 0;

            $scope.firstNameSituation = false;
            $scope.lastNameSituation = false;
            $scope.birthDateSituation = false;
        };

        $('#companyUserInsertPopup').on('hidden.bs.modal', function (e) {
            if ($(e.target)[0].id !== "linkedCompanyGroupInsertPopup") {
                $scope.ClearCompanyUserInsertPopup();
                $(':input').val('');  //clearing the fields, not just resetting the form fields to inital value
            }
        });

        $scope.userMenuCancelPopup = function () {
            $("#userMenuUpdatePopup_").modal("hide");
        };

        $scope.userMenuApprove = function () {
            $("#userMenuUpdatePopup_").modal("hide");
        };

        $scope.Cancel = function () {
            $scope.ClearCompanyUserInsertPopup();
        };

        $scope.deselectAllUserMenuCheckbox = function () {
            $('#WebUserMenuUpdateTree').jstree(true).deselect_all();
        }

        $scope.selectAllUserMenuCheckbox = function () {
            $("#WebUserMenuUpdateTree").jstree(true).check_all();
        }

        $('.nav-tabs a').on('shown.bs.tab', function (event) {
            var tapHeaderName = $(event.target).text();         // active tab
            if (tapHeaderName === "Web") {
                document.getElementById("webUserDelete").style.visibility = "visible";
                document.getElementById("generalUserDelete").style.visibility = "hidden";
                document.getElementById("generalUserDelete").style.width = "0";
                document.getElementById("generalUserDelete").style.marginRight = "-40px";

            } else {
                document.getElementById("generalUserDelete").style.visibility = "visible";
                document.getElementById("webUserDelete").style.visibility = "hidden";
                document.getElementById("generalUserDelete").style.width = "120px";
                document.getElementById("generalUserDelete").style.marginRight = "0";
            }
        });

        /** Update Company User**/
        $scope.UpdateCompanyUser = function (companyUser) {

            $scope.Loading = true;
            $scope.companyUser = companyUser;
            $scope.generalValidation = true;


            //User Yetki Listesi
            var menuValueList = [], menuList = [];
            menuValueList = $("#menuValueList_").val().split(",");

            if (menuValueList[0] === "") {
                toaster.error("Yetkilendirme Hatası", "Herhangi bir yetki seçmediniz");
                return;
            }

            if (menuValueList.length > 0) {
                for (var i = 0; i < menuValueList.length; i++) {
                    var menuParam = { MenuRefId: parseInt(menuValueList[i]), UserRefId: $scope.companyUser.Id };
                    menuList.push(menuParam);
                }
            }

            userRoleService.AddRoleList(menuList,
                function success(response) {
                    if (response.IsSuccess) {
                        location.reload();
                        toaster.success("Başarılı", "Yatkilendirme işlemi başarıyla yapılmıştır.");
                    } else {
                        toaster.error("Güncelleme Hata ", response.Message);
                    }
                },
                function error(response) {
                    toaster.error("Başarısız", response.Message);
                });
        };

        $('#companyUserUpdatePopupGetir').on('hidden.bs.modal', function (e) {
            $scope.userMenuCancelPopup();
            $scope.generalValidation = false;
        });

    }]);
