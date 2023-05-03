MainApp.controller("CompanyController", ["$scope", "CompanyService", "$http", "NgTableParams", "toaster", "$confirm",
    function ($scope, companyService, $http, NgTableParams, toaster, $confirm) {

        $scope.registerCount = 0;
        $scope.Pop = [];

        $scope.TableCol = {
            EstablishmentDate: "Establishment Date",
            InsertDate: "Insert Date",
            LogoUrl: "Logo",
            Name: "Name",
        };

        $scope.GetCompanyGroup = function () {
            companyService.GetCompanyGroup(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.companyGroup = result.Data;
                        console.log("$scope.companyGroup", $scope.companyGroup);

                        $.each($scope.companyGroup, function (index, value) {
                            value.InsertDate = formatDate(new Date(value.InsertDate));

                            //var establishmentDate = new Date(value.InsertDate)
                            //value.EstablishmentDate = formatDate();
                        });

                        refreshtable();
                    }
                    else {
                        toaster.error("GetCategorys", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetCategorys", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetCompanyGroup();

        function refreshtable() {
            $scope.TableParams = new NgTableParams({
                sorting: { name: 'adc' },
                count: 20
            }, {
                counts: [10, 20, 50],
                dataset: $scope.companyGroup
            });
            $scope.registerCount = $scope.companyGroup.length;
        }


    }]);
