MainApp.controller("CompanyUserEditController", ["$scope", "NgTableParams", "toaster", "UserRoleService",
    function ($scope, NgTableParams, toaster, userRoleService) {


        //VPSApp.controller('CompanyUserEditController', ["$scope", "CompanyUserService", "WebUserService", "PositionBoxService", "ProgramingService", "toaster",
        //    function ($scope, CompanyUserService, WebUserService, PositionBoxService, ProgramingService, toaster) {
        $scope.files = [];

        $scope.fileNameChanged = function (file) {
            if (file.files != undefined && file.files.length > 0) {
                for (var i = 0; i < file.files.length; i++) {
                    $scope.files = file.files[0];
                }
            }
        };

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
        $scope.checkFirstName = function () {

            $scope.firstNameSituation = false;
        };

        $scope.checkTitle = function () {

            $scope.titleSituation = false;
        };

        $scope.checkLastName = function () {
            $scope.lastNameSituation = false;
        };

        /** SAVING COMPANY USER**/
        $scope.SaveCompanyUser = function (buildZoneRef) {
            $scope.Loading = true;


            $scope.GroupRefId = parseInt($("#linkedCompanyGroupName").data("CompanyGroupId"));
            $scope.CompanyRefId = parseInt($("#linkedCompanyGroupName").data("CompanyRefId"));

            var generalValidation = false;;


            if (isNaN($scope.GroupRefId) ||
                $scope.GroupRefId == undefined ||
                $scope.GroupRefId < 0 ||
                isNaN($scope.CompanyRefId) ||
                $scope.CompanyRefId == undefined ||
                $scope.CompanyRefId < 0) {
                $scope.groupSituation = true;
                generalValidation = true;
            }

            if ($scope.FirstName == null || $scope.FirstName == undefined || $scope.FirstName === "") {
                $scope.firstNameSituation = true;
                generalValidation = true;
            }
            if ($scope.Title == null || $scope.Title == undefined || $scope.Title === "") {
                $scope.titleSituation = true;
                generalValidation = true;
            }


            if ($scope.LastName == null || $scope.LastName == undefined || $scope.LastName === "") {
                $scope.lastNameSituation = true;
                generalValidation = true;
            }

            if (buildZoneRef == null || buildZoneRef == undefined || buildZoneRef === "") {
                buildZoneRef = 0;
            }



            if ($scope.Gender != undefined) {

                if ($scope.Gender === "1") {
                    $scope.Gender = 1;
                } else {
                    $scope.Gender = 0;
                }
            } else {
                $scope.Gender = 0;
            }
            $scope.convertBirthDay = new Date(getConvertDateHyphen($scope.BirthDate));


            if (!generalValidation) {

                var parameters = {
                    CompanyRefId: $scope.CompanyRefId,
                    GroupRefId: $scope.GroupRefId,
                    TitleOptions: 0,
                    FirstName: $scope.FirstName,
                    Title: $scope.Title,
                    BuildZoneRefId: buildZoneRef.Id == undefined ? 0 : buildZoneRef.Id,
                    LastName: $scope.LastName,
                    MiddleName: $scope.MiddleName,
                    BirthDate: $scope.convertBirthDay,
                    CompanyUserPermissions: 0,
                    CompanyUserOptions: 0,
                    Gender: $scope.Gender
                };

                $scope.user = parameters;


                CompanyUserService.SaveCompanyUser($scope.user,
                    $scope.files,
                    function success(response) {
                        if (response.IsSuccess) {
                            location.replace("/CompanyUser/Index");
                            toaster.success("Kaydetme", "Kaydetme işlemi başarılı");
                        } else {
                            toaster.error("Kaydetme", "İşlem yapılırken hata oluştu");
                        }
                    },
                    function error() {
                        toaster.error("Kaydetme", "İşlem yapılırken hata oluştu");
                    });

                //$scope.ClearCompanyInsertPopup();
            }
        };

        $scope.checkPasswordRepeat = function (passwordRepeat) {
            if (passwordRepeat == undefined || passwordRepeat === "" || passwordRepeat.length === 0) {
                $scope.passwordRepeatSituation = true;
                $scope.webUserInsertValidation = true;
            } else {

                $scope.passwordRepeatSituation = false;
                $scope.webUserInsertValidation = false;
            }

        };

        $scope.checkPassword = function (password) {
            if (password == undefined || password === "" || password.length === 0) {
                $scope.passWordSituation = true;
                $scope.webUserInsertValidation = true;
            } else {
                $scope.passWordSituation = false;
                $scope.webUserInsertValidation = false;

            }
            $scope.passwordMatchValidation = false;
        };


        $scope.checkUserName = function (userName) {
            if (userName == undefined || userName === "" || userName.length === 0) {
                $scope.userNameSituation = true;
                $scope.webUserInsertValidation = true;
            } else {
                $scope.userNameSituation = false;
                $scope.webUserInsertValidation = false;
            }
            $scope.passwordMatchValidation = false;
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

        $scope.webUserInsertValidation = false;

        /** Update Company User**/
        $scope.UpdateCompanyUser = function (companyUser) {

            //GetPositionBoxes();

            //companyUser.BirthDate = new Date(getConvertDateHyphen(companyUser.BirthDate))


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

        $scope.CloseCompanyUserDeletePopup = function () {
            $("#companyUserDeletePopup").modal("hide");
        }

        /** UPDATING WEB USER**/
        $scope.UpdateWebUser = function (webUser) {
            $scope.webUser = webUser;
            WebUserService.UpdateWebUser($scope.webUser,
                function success(response) {
                    if (response.IsSuccess) {
                        location.replace("/CompanyUser/Index");
                        toaster.success("Güncelleme", "Güncelleme işlemi başarılı");
                    } else {
                        toaster.error("Güncelleme", "Güncelleme işlemi yapılırken hata oluştu");
                    }

                },
                function error() {
                    toaster.error("Güncelleme", "Güncelleme işlemi yapılırken hata oluştu");
                });
        };


        /** SAVING WEB USER**/
        $scope.SaveWebUser = function (webUser) {
            $scope.webUser = webUser;
            WebUserService.SaveWebUser($scope.webUser,
                function success(response) {
                    if (response.IsSuccess) {
                        if (response.Data.ResultId === -1) {
                            $('#companyUserUpdatePopupGetir').modal('hide');
                            toaster.error("WebUser Oluşturma", "Bu kullanıcı adı kullanılmıştır. Lütfen farklı bir kullanıcı adı deneyiniz.");
                            return;
                        }
                        location.replace("/CompanyUser/Index");
                        toaster.success("Kaydetme", "Kaydetme işlemi başarılı");
                    } else {
                        toaster.error("Kaydetme", "Kaydetme işlemi yapılırken hata oluştu");
                    }

                },
                function error() {
                    toaster.error("Kaydetme", "Kaydetme işlemi yapılırken hata oluştu");
                });
        };


        $scope.CloseWebUserDeletePopup = function () {
            $("#webUserDeletePopup").modal("hide");
        };



        $('#companyUserUpdatePopupGetir').on('hidden.bs.modal', function (e) {
            $scope.userMenuCancelPopup();
            $scope.generalValidation = false;
        });

    }]);
