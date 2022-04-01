MainApp.controller("RelevantPersonnelController", ["$scope", "RelevantPersonnelService", "toaster", "NgTableParams",
    function ($scope, RelevantPersonnelService, toaster, NgTableParams) {
        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            UserName: "Name",
            Adress: "Adress"
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
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetRelevantPersonnels();

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

        //$scope.UpdateComponentModel = function (data) {
        //    ComponentModelService.UpdateComponentModel(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Başarılı", "Component model güncelleme işlemi başarılı");
        //            } else {
        //                toaster.success("Başarısız", "Component model güncelleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.success("Başarısız", "Component model güncelleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

        //$scope.AddComponentModel = function () {
        //    var data = {
        //        "Name": $scope.Pop.Name,
        //    }

        //    ComponentModelService.AddComponentModel(data,
        //        function success(result) {
        //            if (result.IsSuccess) {
        //                toaster.success("Başarılı", "Component model ekleme işlemi başarılı");
        //                $('#AddSituation').modal('hide');
        //                $scope.GetComponentModels();
        //                $scope.Pop = [];
        //            } else {
        //                toaster.success("Başarısız", "Component model ekleme işlemi yapılırken bir hata oluştu");
        //            }
        //        }, function error() {
        //            toaster.success("Başarısız", "Component model ekleme işlemi yapılırken bir hata oluştu");
        //        });
        //}

    }]);
