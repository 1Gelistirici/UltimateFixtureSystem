MainApp.controller("RelevantPersonnelController", ["$scope", "RelevantPersonnelService", "UserService", "toaster", "NgTableParams",
    function ($scope, RelevantPersonnelService, UserService, toaster, NgTableParams) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            UserName: "Name",
            MailAdress: "Adress"
        };

        $scope.GetRelevantPersonnels = function () {
            RelevantPersonnelService.GetRelevantPersonnels(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;
                        $scope.RegisterCount = $scope.Data.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });

                        $scope.GetUserCompany();
                    } else {
                        toaster.error("GetRelevantPersonnels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetRelevantPersonnels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetRelevantPersonnels();

        $scope.GetUserCompany = function () {
            UserService.GetUserCompany(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;

                        $scope.Users = result.Data.filter(x => undefined === $scope.Data.find(y => y.User.Id === x.Id))

                        $scope.User = $scope.Users[0].Id;
                    } else {
                        toaster.error("GetUserCompany", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUserCompany", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.DeleteRelevantPersonnel = function (data) {
            RelevantPersonnelService.DeleteRelevantPersonnel(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Component model silme işlemi başarılı");
                        $scope.GetRelevantPersonnels();
                    } else {
                        toaster.success("Başarısız", "Component model silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Component model silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddRelevantPersonnel = function () {
            var data = {
                UserRefId: $scope.User,
            }

            RelevantPersonnelService.AddRelevantPersonnel(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Component model ekleme işlemi başarılı");
                        $('#AddRelevantPersonnel').modal('hide');
                        $scope.GetRelevantPersonnels();
                    } else {
                        toaster.success("Başarısız", "Component model ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.success("Başarısız", "Component model ekleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);
