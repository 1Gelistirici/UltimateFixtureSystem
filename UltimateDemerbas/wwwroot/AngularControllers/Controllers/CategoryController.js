MainApp.controller("CategoryController", ["$scope", "CategoryService", "NgTableParams", "toaster", "$confirm",
    function ($scope, CategoryService, NgTableParams, toaster, $confirm) {

        $scope.RegisterCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            Name: "Component Name",
        };

        $scope.GetCategoryByCompanyRefId = function () {
            CategoryService.GetCategoryByCompanyRefId(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;
                        $scope.RegisterCount = $scope.Data.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 5
                        }, {
                            counts: [5, 10, 50],
                            dataset: $scope.Data
                        });
                    } else {
                        toaster.error("GetCategories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetCategories", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetCategoryByCompanyRefId();

        $scope.DeleteCategory = function (data) {
            CategoryService.DeleteCategory(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Kategori başarıyla silinmiştir.");
                        RefreshData();
                    } else {
                        toaster.error("DeleteCategory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("DeleteCategory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateCategory = function (data) {
            CategoryService.UpdateCategory(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Kategori başarıyla güncellenmiştir.");
                        RefreshData();
                    } else {
                        toaster.error("UpdateCategory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("UpdateCategory", "Kat listeleme işlemi yapılırken bir hata oluştu");
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
                        toaster.error("AddCategory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("AddCategory", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        function RefreshData() {
            $scope.Pop = [];
            $scope.GetCategories();
        }


        $(document).ready(function () {

        });

        $("#btnAddCategoryPopup").click(function () {
            setTimeout(function () {
                $("#categoryName").focus();
            }, 500);
        });

        $scope.UpdateCategoryConfirm = function (x) {
            $confirm.Show("Onay", "Güncellemek istediğinize emin misiniz?", function () { $scope.UpdateCategory(x); });
        }
        $scope.DeleteCategoryConfirm = function (x) {
            $confirm.Show("Onay", "Silmek istediğinize emin misiniz?", function () { $scope.DeleteCategory(x); });
        }

    }]);
