MainApp.controller("CompanyUserEditController", ["$scope", "NgTableParams", "toaster",
    function ($scope, NgTableParams, toaster) {


        //VPSApp.controller('CompanyUserEditController', ["$scope", "CompanyUserService", "WebUserService", "PositionBoxService", "ProgramingService", "toaster",
        //    function ($scope, CompanyUserService, WebUserService, PositionBoxService, ProgramingService, toaster) {
                var socketIsConnect = false;
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

                    GetPositionBoxes();

                    companyUser.BirthDate = new Date(getConvertDateHyphen(companyUser.BirthDate))


                    $scope.Loading = true;
                    $scope.companyUser = companyUser;
                    $scope.generalValidation = true;

                    var usertabIsActive = document.getElementById("usertab").getAttribute("aria-expanded");
                    var webusertabsIsActive = document.getElementById("webusertab").getAttribute("aria-expanded");
                    var userMenutabsIsActive = document.getElementById("userMenuTab").getAttribute("aria-expanded");

                    //Active Tab Genel
                    if (usertabIsActive === "true") {
                        $scope.GroupRefId = parseInt($("#companyUserUpdateGroupName").data("CompanyGroupId"));
                        $scope.CompanyRefId = parseInt($("#companyUserUpdateGroupName").data("CompanyRefId"));

                        var generalValidation = false;

                        if (!isNaN($scope.GroupRefId) && !isNaN($scope.CompanyRefId)) {
                            $scope.companyUser.GroupRefId = $scope.GroupRefId;
                            $scope.companyUser.CompanyRefId = $scope.CompanyRefId;
                            $scope.generalValidation = false;
                        }

                        if ($scope.companyUser.FirstName === null ||
                            $scope.companyUser.FirstName === undefined ||
                            $scope.companyUser.FirstName === "") {
                            $scope.firstNameSituation = true;
                            generalValidation = true;
                            $scope.generalValidation = false;
                        }

                        if ($scope.companyUser.Title === null ||
                            $scope.companyUser.Title === undefined ||
                            $scope.companyUser.Title === "") {
                            $scope.firstNameSituation = true;
                            generalValidation = true;
                            $scope.generalValidation = false;
                        }
                        if ($scope.companyUser.LastName == null ||
                            $scope.companyUser.LastName == undefined ||
                            $scope.companyUser.LastName === "") {
                            $scope.lastNameSituation = true;
                            generalValidation = true;
                            $scope.generalValidation = false;
                        }

                        if ($scope.companyUser.BuildZoneRefId == null || $scope.companyUser.BuildZoneRefId == undefined || $scope.companyUser.BuildZoneRefId === "") {
                            $scope.companyUser.BuildZoneRefId = 0;
                        }

                        if (!generalValidation) {

                            $scope.user = $scope.companyUser;
                            $scope.user.BuildZoneRefId = $scope.companyUser.BuildZoneRefId;

                            //Update
                            setTimeout(function () {
                                $scope.selectedTag = $scope.TagList.find(x => x.UserRefId === $scope.user.Id);
                                if ($scope.selectedTag) {
                                    GetLcdStaffInformation(); //Socket update
                                } else {
                                    if (socketIsConnect) {
                                        UpdateCompanyUserDB(); // Db update
                                    }
                                }
                            }, 1000);

                        }
                    }
                    else if (userMenutabsIsActive === "true") {

                        //User Yetki Listesi
                        var menuValueList = [], menuList = [];
                        menuValueList = $("#menuValueList_").val().split(",");

                        if (menuValueList[0] === "") {
                            toaster.error("Yetkilendirme Hatası", "Herhangi bir yetki seçmediniz");
                            return;
                        }

                        if (menuValueList.length > 0) {
                            for (var i = 0; i < menuValueList.length; i++) {
                                var menuParam = { MenuRefId: parseInt(menuValueList[i]) };
                                menuList.push(menuParam);
                            }
                        }





                        $scope.user = $scope.companyUser;
                        $scope.user.WebUser.Menu = menuList;


                        CompanyUserService.UpdateCompanyUser($scope.user,
                            $scope.files,
                            function success(response) {
                                if (response.IsSuccess) {
                                    location.replace("/CompanyUser/Index");
                                    toaster.success("Güncelleme", "Güncelleme işlemi yapılmıştır");
                                } else {
                                    toaster.error("Güncelleme Hata ", response.Message);
                                }
                            },
                            function error(response) {
                                toaster.error("Güncelleme Hata ", response.Message);
                            });


                        //$scope.UpdateWebUser($scope.companyUser.WebUser);
                        //alert(companyPermissions);
                    }
                    else {
                        $scope.passWordSituation = false;
                        if ($scope.companyUser.WebUser != null && $scope.companyUser.WebUser.UserRefId != undefined) {
                            //Update

                            if ($scope.companyUser.WebUser.UserName === undefined ||
                                $scope.companyUser.WebUser.UserName === "") {
                                $scope.userNameSituation = true;
                                $scope.webUserInsertValidation = true;
                            }

                            if ($scope.companyUser.WebUser.Password === undefined ||
                                $scope.companyUser.WebUser.Password === "") {

                                $scope.passWordSituation = true;
                                $scope.webUserInsertValidation = true;
                            }


                            if ($scope.companyUser.WebUser.PasswordRepeat === undefined ||
                                $scope.companyUser.WebUser.PasswordRepeat === "") {
                                $scope.passwordRepeatSituation = true;
                                $scope.webUserInsertValidation = true;
                            }

                            if ($scope.companyUser.WebUser.Password !== $scope.companyUser.WebUser.PasswordRepeat) {
                                $scope.passWordSituation = true;
                                $scope.passwordRepeatSituation = true;
                                $scope.passwordMatchValidation = true;
                            }

                            if (!$scope.webUserInsertValidation && !$scope.passwordMatchValidation) {
                                //Update
                                $scope.companyUser.WebUser.UserRefId = $scope.companyUser.Id;
                                $scope.companyUser.WebUser.CompanyRefId = $scope.companyUser.CompanyRefId;
                                $scope.UpdateWebUser($scope.companyUser.WebUser);

                            }

                        } else {
                            //Insert
                            $scope.webUserInsertValidation = false;
                            $scope.passwordMatchValidation = false;
                            $scope.passwordRepeatSituation = false;
                            $scope.userNameSituation = false;
                            $scope.passWordSituation = false;


                            if ($scope.companyUser.WebUser == undefined) {
                                $scope.webUserInsertValidation = true;
                                $scope.passwordRepeatSituation = true;
                                $scope.userNameSituation = true;
                                $scope.passWordSituation = true;

                            } else {

                                if ($scope.companyUser.WebUser.UserName == undefined ||
                                    $scope.companyUser.WebUser.UserName === "") {
                                    $scope.userNameSituation = true;
                                    $scope.webUserInsertValidation = true;
                                }

                                if ($scope.companyUser.WebUser.Password == undefined ||
                                    $scope.companyUser.WebUser.Password === "") {

                                    $scope.passWordSituation = true;
                                    $scope.webUserInsertValidation = true;
                                }


                                if ($scope.companyUser.WebUser.PasswordRepeat == undefined ||
                                    $scope.companyUser.WebUser.PasswordRepeat === "") {
                                    $scope.passwordRepeatSituation = true;
                                    $scope.webUserInsertValidation = true;
                                }

                                if ($scope.companyUser.WebUser.Password !== $scope.companyUser.WebUser.PasswordRepeat) {
                                    $scope.passWordSituation = true;
                                    $scope.passwordRepeatSituation = true;
                                    $scope.passwordMatchValidation = true;
                                }

                                if ($scope.companyUser.WebUser != null &&
                                    !$scope.webUserInsertValidation &&
                                    !$scope.passwordMatchValidation) {
                                    //Insert
                                    $scope.companyUser.WebUser.UserRefId = $scope.companyUser.Id;
                                    $scope.companyUser.WebUser.CompanyRefId = $scope.companyUser.CompanyRefId;
                                    $scope.SaveWebUser($scope.companyUser.WebUser);

                                }
                            }
                        }
                    }
                };

                function UpdateCompanyUserDB() {
                    CompanyUserService.UpdateCompanyUser($scope.user,
                        $scope.files,
                        function success(response) {
                            if (response.IsSuccess) {
                                location.replace("/CompanyUser/Index");
                                toaster.success("Güncelleme", "Güncelleme işlemi yapılmıştır");
                            } else {
                                toaster.error("Güncelleme Hata ", response.Message);
                            }
                        },
                        function error(response) {
                            toaster.error("Güncelleme Hata ", response.Message);
                        });
                }


                $scope.CloseCompanyUserDeletePopup = function () {
                    $("#companyUserDeletePopup").modal("hide");
                }
                $scope.DeleteCompanyUser = function (companyUser) {


                    swal({
                        title: "Emin misiniz?",
                        text: "Bu kullanıcıyı silmek istediğinizden emin misiniz?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                        buttons: ['İptal', 'Evet']

                    })
                        .then((willDelete) => {
                            if (willDelete) {


                                CompanyUserService.DeleteCompanyUser(companyUser,
                                    function success(response) {
                                        if (response.IsSuccess) {
                                            toaster.success("Silme", "Silme işlemi başarılı");
                                            location.replace("/CompanyUser/Index");
                                        } else {
                                            toaster.error("Silme", "Silme işlemi yapılırken hata oluştu");
                                        }

                                    },
                                    function error() {
                                        toaster.error("Silme", "Silme işlemi yapılırken hata oluştu");
                                    });


                            } else {

                            }


                        });


                };



                $scope.DeleteWebUserr = function (parameter) {
                    CompanyUserService.GetBuildZonesGlbFileTypeCompanyUser(parameter,
                        function success(response) {
                            if (response.IsSuccess) {
                                location.replace("/CompanyUser/Index");
                                toaster.success("Silme", "Silme işlemi başarılı");
                            } else {
                                toaster.error("Silme", "Silme işlemi yapılırken hata oluştu");
                            }

                        },
                        function error() {
                            toaster.error("Silme", "Silme işlemi yapılırken hata oluştu");
                        });
                };


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


                $scope.DeleteWebUser = function (webUser) {
                    WebUserService.DeleteWebUser(webUser.UserRefId,
                        function success(response) {
                            if (response.IsSuccess) {
                                location.replace("/CompanyUser/Index");
                                toaster.success("Silme", "Silme işlemi başarılı");
                            } else {
                                toaster.error("Silme", "Silme işlemi yapılırken hata oluştu");
                            }

                        },
                        function error() {
                            toaster.error("Silme", "Silme işlemi yapılırken hata oluştu");
                        });
                };



                $('#companyUserUpdatePopupGetir').on('hidden.bs.modal', function (e) {
                    $scope.userMenuCancelPopup();
                    $scope.generalValidation = false;
                });



                $scope.SetLcdStaffInformation = function () {
                    if (!$scope.staff || !$scope.user) {
                        toaster.warning("Güncellenemedi", "Bir şeyler yanlış gitti.");
                        return;
                    }

                    if (($scope.user.FirstName.length + $scope.user.LastName.length + 1) > 23) { //+1 veriyorum-Ad ve soyad arasına boşluk ekleniyor
                        toaster.warning("Güncellenemedi", "Ad ve Soyad toplam 23 karakter uzunluğunda olabilir.");
                        return;
                    }

                    $scope.parameter = {
                        PositionBoxRefId: $scope.PositionBoxes[0].Id,
                        TagId: parseInt($scope.selectedTag.TagId),
                        Name: $scope.user.FirstName + ' ' + $scope.user.LastName,
                        NameTextAlign: $scope.staff.NameTextAlign,
                        NameFont: $scope.staff.NameFont,
                        NameXStart: $scope.staff.NameXStart,
                        NameXEnd: $scope.staff.NameXEnd,
                        NameYStart: $scope.staff.NameYStart,
                        Department: $scope.staff.DepartmentName,
                        DepartmentTextAlign: $scope.staff.DepartmentTextAlign,
                        DepartmentFont: $scope.staff.DepartmentFont,
                        DepartmentXStart: $scope.staff.DepartmentXStart,
                        DepartmentXEnd: $scope.staff.DepartmentXEnd,
                        DepartmentYStart: $scope.staff.DepartmentYStart,
                        CardNumber: $scope.staff.CardNumber,
                        CardNumberTextAlign: $scope.staff.CardTextAlign,
                        CardNumberFont: $scope.staff.CardFont,
                        CardNumberXStart: $scope.staff.CardXStart,
                        CardNumberXEnd: $scope.staff.CardXEnd,
                        CardNumberYStart: $scope.staff.CardYStart
                    };

                    App.blockUI();
                    ProgramingService.SetLcdStaffInformation($scope.parameter, $scope.selectedTag.TagRefId,
                        function success(result) {
                            if (result.IsSuccess) {
                                if (!socketIsConnect) {
                                    ProgrammingDataStart();
                                }
                                socketIsConnect = false;
                            } else {
                                ProgrammingError();
                            }
                        },
                        function error() {
                            ProgrammingError();
                        });
                }

                function GetLcdStaffInformation() {
                    $scope.staff = [];
                    App.blockUI();
                    ProgramingService.GetLcdStaffInformation($scope.selectedTag.TagRefId,
                        function success(result) {
                            App.unblockUI();
                            if (result.IsSuccess) {
                                if (result.Data != null) {
                                    $scope.staff = result.Data;
                                    $scope.SetLcdStaffInformation();
                                }
                            } else {
                                toaster.error("Get Lcd Staff Information", "Başarısız... Bir sorun meydana geldi");
                            }
                        },
                        function error() {
                            App.unblockUI();
                            toaster.error("Get Lcd Staff Information", "Başarısız... Bir sorun meydana geldi");
                        });
                }

                $scope.GetTagList = function (positionBoxId) {
                    App.blockUI();
                    ProgramingService.GetTagList(positionBoxId,
                        function success(result) {
                            App.unblockUI();
                            if (result.IsSuccess) {
                                if (!socketIsConnect) {
                                    ProgrammingDataStart();
                                }
                                socketIsConnect = false;
                            } else {
                                ProgrammingError();
                            }
                        },
                        function error() {
                            ProgrammingError();
                        });
                };

                //PositionBox Listeleme
                var GetPositionBoxes = function () {
                    $scope.TagList = [];
                    App.blockUI();
                    PositionBoxService.GetPositionBoxes(
                        function success(result) {
                            if (result.IsSuccess) {
                                $scope.PositionBoxes = result.Data;
                                for (var i = 0; i < result.Data.length; i++) {
                                    $scope.GetTagList(result.Data[i].Id);
                                }
                                App.programmingOnlinec();
                            } else {
                                toaster.error("PositionBoxes listelenemedi", "Başarısız... Bir sorun meydana geldi");
                                App.unblockUI();
                            }
                        },
                        function error() {
                            App.unblockUI();
                            toaster.error("PositionBoxes listelenemedi", "Başarısız... Bir sorun meydana geldi");
                        });
                };



    }]);
