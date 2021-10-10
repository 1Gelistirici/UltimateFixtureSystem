MainApp.controller("ComponentController", ["$scope", "CategoryService","ComponentModelService", "ComponentService", "$http", "NgTableParams", function ($scope, CategoryService,ComponentModelService,ComponentService, $http, NgTableParams) {

    $scope.RegisterCount = 0;
    $scope.Pop = [];

    $scope.TableCol = {
        Name: "Component Name",
        ModelNo: "Model",
        CategoryNo: "Category",
        Piece: "Piece",
        BillNo: "Bill",
    };

    $scope.GetCategorys = function () {
        CategoryService.GetCategories(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.Categorys = result.Data;
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetCategorys();

    $scope.GetComponentModels = function () {
        ComponentModelService.GetComponentModels(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.Models = result.Data;
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetComponentModels();

    $scope.GetComponents = function () {
        ComponentService.GetComponents(
            function success(result) {
                if (result.IsSuccess) {
                    console.log("result.Data");
                    console.log(result.Data);
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
    $scope.GetComponents();

    $scope.DeleteComponent = function (data) {
        ComponentService.DeleteComponent(data.Id,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.UpdateComponent = function (data) {
        ComponentService.UpdateComponent(data,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.AddComponent = function () {

        var data = {
            "Name": $scope.Pop.Name,
            "Piece": $scope.Pop.Piece,
            "BillNo": $scope.Pop.BillNo,
            "ModelNo": $scope.Pop.ModelNo,
            "CategoryNo": $scope.Pop.CategoryNo
        }

        ComponentService.AddComponent(data,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });

    }

}]);
