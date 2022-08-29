MainApp.controller("UserController", ["$scope", "UserService", "EnumService", "NgTableParams", "toaster", "$sce",
    function ($scope, UserService, EnumService, NgTableParams, toaster, $sce) {

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
                            $scope.Data[index].Gender = $scope.Gender.find(x => x.Value == value.Gender);
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
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetGenders();

        $scope.AddUser = function () {
            if ($scope.Password != $scope.TryPassword) {
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
                PasswordTry: $scope.Pop.TryPassword,
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


        //toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");





        //$scope.AddLicense = function () {
        //    var data = {
        //        "Name": $scope.Pop.Name,
        //        "TypeNo": $scope.Pop.TypeNo,
        //        "Piece": $scope.Pop.Piece,
        //    }

        //    LicenseService.AddLicense(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //                $("#AddLicense").modal("hide");
        //                $scope.GetLicenses();
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });

        //}

        //$scope.GetLicensesTypes = function () {
        //    LicenseTypeService.GetLicensesTypes(
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                $scope.LicenseTypes = result.Data;
        //                $scope.TableParams = new NgTableParams({
        //                    sorting: { name: 'adc' },
        //                    count: 20
        //                }, {
        //                    counts: [10, 20, 50],
        //                    dataset: $scope.Data
        //                });
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}
        //$scope.GetLicensesTypes();

        //$scope.SetAssign = function (x) {
        //    $scope.Assign = x;
        //}

        //$scope.GetFixtures = function () {
        //    FixtureService.GetFixtures(
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                $scope.Fixtures = result.Data.filter(x => x.CategoryNo == 1);
        //                console.log($scope.Fixtures);
        //            } else {
        //                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
        //        });
        //}
        //$scope.GetFixtures();

        //$scope.AddFixLic = function () {
        //    var parameter = {
        //        LicanseId: parseInt($scope.Assign.Id),
        //        FixtureId: parseInt($scope.Assign.FixturId)
        //    }

        //    FixLicService.AddFixLic(parameter,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Başarılı", "Lisans atama işlemi yapılırken bir hata oluştu");
        //                $('#LicenseAssignmentPartial').modal('hide');
        //                $scope.Data.find(x => x.Id == $scope.Assign.Id).Piece = ($scope.Assign.Piece - 1)
        //            } else {
        //                toaster.error("Başarısız", "Lisans atama işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.error("Başarısız", "Lisans atama işlemi yapılırken bir hata oluştu");
        //        });
        //}





    }]);
