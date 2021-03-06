MainApp.controller("CategoryController", ["$scope", "CategoryService", "$http", "NgTableParams", "toaster",
    function ($scope, CategoryService, $http, NgTableParams, toaster) {

        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Component Name",
        };

        $scope.GetCategories = function () {
            CategoryService.GetCategories(
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
        $scope.GetCategories();

        $scope.DeleteCategory = function (data) {
            CategoryService.DeleteCategory(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Kategori başarıyla silinmiştir.");
                        RefreshData();
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateCategory = function (data) {
            CategoryService.UpdateCategory(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Kategori başarıyla güncellenmiştir.");
                        RefreshData();
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.AddCategory = function () {
            var data = {
                "Name": $scope.Pop.Name,
            }

            CategoryService.AddCategory(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Kategori başarıyla eklenmiştir.");
                        $('#AddCategoryPopup').modal('hide');
                        RefreshData();
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        function RefreshData() {
            $scope.Pop = [];
            $scope.GetCategories();
        }

    }]);
