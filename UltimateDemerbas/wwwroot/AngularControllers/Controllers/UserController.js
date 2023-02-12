MainApp.controller("UserController", ["$scope", "UserService", "EnumService", "MenuService", "NgTableParams", "toaster", "$sce",
    function ($scope, UserService, EnumService, MenuService, NgTableParams, toaster, $sce) {

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
            if (file.files != undefined && file.files.length > 0) {
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
                        console.log("$scope.Menus", $scope.Menus);
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

        $scope.DeleteUser = function (data) {
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


    }]);
