MainApp.controller("UserController", ["$scope", "UserService", "EnumService", "MenuService", "NgTableParams", "toaster", "$sce", "$confirm", "UserRoleService",
    function ($scope, UserService, EnumService, MenuService, NgTableParams, toaster, $sce, $confirm, userRoleService) {

        //#region Parameters
        $scope.RegisterCount = 0;
        $scope.Pop = [];
        $scope.files = [];

        $scope.TableCol = {
            Name: "Name",
            Surname: "Surname",
            Gender: "Gender",
            Title: "Title",
            Telephone: "Telephone",
            MailAdress: "Mail",
            Lock: "Lock"
        };
        //#endregion

        $scope.TrustSrc = function (src) {
            return $sce.trustAsResourceUrl(src);
        }

        $scope.fileNameChanged = function (file) {
            if (file.files !== undefined && file.files.length > 0) {
                for (var i = 0; i < file.files.length; i++) {
                    $scope.files = file.files[0];
                }
            }
        };

        $scope.GetUserCompany = function () {
            UserService.GetUserCompany(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;

                        $.each($scope.Data, function (index, value) {
                            value.Gender = $scope.Gender.find(x => x.Value === (value.Gender ? 1 : 0));
                        });

                        $scope.RegisterCount = $scope.Data.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });
                    } else {
                        toaster.error("Başarısız", "GetUserCompany");
                    }
                }, function error() {
                    toaster.error("Başarısız", "GetUserCompany");
                });
        }


        $scope.GetMenu = function () {
            MenuService.GetMenu(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Menus = result.Data;
                    } else {
                        toaster.error("Başarısız", "GetUserCompany");
                    }
                }, function error() {
                    toaster.error("Başarısız", "GetUserCompany");
                });
        }
        $scope.GetMenu();

        $scope.GetDepartments = function () {
            EnumService.GetDepartments(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Departments = result.Data;
                    } else {
                        toaster.error("Başarısız", "GetDepartments");
                    }
                }, function error() {
                    toaster.error("Başarısız", "GetDepartments");
                });
        }
        $scope.GetDepartments();

        $scope.GetGenders = function () {
            EnumService.GetGenders(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Gender = result.Data;

                        $.each($scope.ItemStatus, function (index, value) {
                            var parameter = { id: value.Value, title: value.Text };
                            $scope.GenderFilter.push(parameter);
                        });

                        $scope.GetUserCompany();
                    } else {
                        toaster.error("GetGenders", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetGenders", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetGenders();

        $scope.AddUser = function () {
            if ($scope.Pop.Password !== $scope.Pop.TryPassword) {
                toaster.error("Başarısız", "Şifreler Uyuşmuyor.");
                return;
            }

            var parameter = {
                Name: $scope.Pop.Name,
                Surname: $scope.Pop.Surname,
                Username: $scope.Pop.Username,
                Gender: $('#checkbox2_8').is(':checked'),
                Password: $scope.Pop.Password,
                PasswordTry: $scope.Pop.TryPassword,
                Title: $scope.Pop.Title,
                Department: $scope.Pop.Department,
                Lock: $scope.Pop.Lock
            };

            UserService.AddUser(parameter, $scope.files,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Successful", "Lisans güncelleme işlemi başarılı");
                        $scope.Pop = [];
                        $("#AddUser").modal("hide");
                        $scope.GetUserCompany();
                    } else {
                        toaster.error("Unsuccessful", result.Message);
                    }
                }, function error() {
                    toaster.error("Unsuccessful", "Lisans güncelleme işlemi yapılırken bir hata oluştu");
                });
        }

        function deleteUser(data) {
            UserService.DeleteUser(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Kullanıcı silindi.");
                        $scope.GetUserCompany();
                    } else {
                        toaster.error("Başarısız", "Kullanıcı silme işlemi yapılırken bir hata oluştu.");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Kullanıcı silme işlemi yapılırken bir hata oluştu.");
                });
        }

        $scope.OpenPopup = function (data) {
            $scope.Pop = jQuery.extend(true, {}, data);
        }

        $scope.OpenAssignPopup = function (data) {
            $scope.AssignPopup = data;

            fillMenu(data);
        }


        function fillMenu(data) {
            var parameter = { UserRefId: data.Id }

            userRoleService.GetRole(parameter,
                function success(result) {
                    if (result.IsSuccess) {

                        var instance = $('#WebUserMenuUpdateTree').jstree(true);
                        instance.deselect_all();
                        //instance.select_node('2');

                        var menuNameListResult = "";
                        $("#WebUserMenuUpdateTree").jstree('open_all');
                        //Hepsnin önce açılması gerekir 
                        var menuValueList = [];
                        $(function () {
                            $.each($("#WebUserMenuUpdateTree").jstree('full').find("li"), function (index, element) {
                                var menuValue = parseInt(element.dataset.menuvalue);
                                var menuIsActive = result.Data.find(x => x.MenuRefId === menuValue)

                                var menuData = $scope.Menus.find(x => x.Id === menuValue);
                                if (!menuData) {
                                    for (var i = 0; i < $scope.Menus.length; i++) {
                                        if ($scope.Menus[i].Children && !menuData) {
                                            menuData = $scope.Menus[i].Children.find(x => x.Id === menuValue);
                                        }
                                    }
                                }

                                if (menuIsActive !== undefined) {
                                    if (menuData.Url !== "") {
                                        $('#WebUserMenuUpdateTree').jstree("select_node", element.id);

                                        menuNameListResult = menuNameListResult + "," + element.id;

                                        menuValueList.push(menuValue);
                                    }
                                }

                                $("#menuNameListResult").val(menuValueList);
                            });
                        });

                    } else {
                        toaster.error("UserRole", "Bir hata oluştu.");
                    }
                }, function error() {
                    toaster.error("UserRole", "Bir hata oluştu.");
                });
        }

        $scope.UpdateUser = function () {

            var parameter = {
                UserId: $scope.Pop.Id,
                Name: $scope.Pop.Name,
                Surname: $scope.Pop.Surname,
                UserName: $scope.Pop.UserName,
                MailAdress: $scope.Pop.MailAdress,
                Telephone: $scope.Pop.Telephone,
                Title: $scope.Pop.Title,
                Department: $scope.Pop.Department,
                Gender: $scope.Pop.Gender.Value === 1,
                Lock: $scope.Pop.Lock,
                file: $scope.files,
                ImageName: $scope.Pop.ImageName,
                ImageUrl: $scope.Pop.ImageUrl
            };

            UserService.UpdateUser(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Kullanıcı güncellendi.");
                        $scope.Pop = [];
                        $("#UpdateUser").modal("hide");
                        $scope.GetUserCompany();
                    } else {
                        toaster.error("Başarısız", "Kullanıcı güncellenirken bir hata oluştu.");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Kullanıcı güncellenirken bir hata oluştu.");
                });
        }

        $scope.deleteUserConfirm = function (parameter) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { deleteUser(parameter); });
        }
    }]);
