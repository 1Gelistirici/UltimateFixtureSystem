MainApp.controller("ReportedAssetsController", ["$scope", "ReportService", "toaster", "NgTableParams", "$confirm", "EnumService", "UserService",
    function ($scope, reportService, toaster, NgTableParams, $confirm, enumService, userService) {

        $scope.registerCount = 0;
        $scope.Pop = [];
        $scope.ItemTypesFilter = [];

        $scope.TableCol = {
            ReportDetail: "Report Detail"
            , InsertDate: "Insert Date"
            , ItemType: "Item Type"
            , ReportSubject: "Report Subject"

            , AssignmentName: "Assignment Name"
            , ItemName: "Item Name"
            , UserName: "User Name"
        };

        $scope.GetReportedAssetsByCompany = function () {
            reportService.GetReportedAssetsByCompany(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.reportedAssets = result.Data;

                        $.each($scope.reportedAssets, function (index, value) {

                            $scope.reportedAssets[index].InsertDate = formatDate(new Date($scope.reportedAssets[index].InsertDate));
                            $scope.reportedAssets[index].User = $scope.Users.find(x => x.Id === value.UserId);
                            $scope.reportedAssets[index].Assignment = $scope.Users.find(x => x.Id === value.AssignmentId);
                            $scope.reportedAssets[index].RecallDate = new Date($scope.reportedAssets[index].RecallDate).toLocaleString();
                            $scope.reportedAssets[index].TypeItem = $scope.ItemTypes.find(x => x.Value === value.ItemType);

                            if ($scope.reportedAssets[index].ComponentItem !== null) {
                                $scope.reportedAssets[index].Item = $scope.reportedAssets[index].ComponentItem;
                            }
                            else if ($scope.reportedAssets[index].BillItem !== null) {
                                $scope.reportedAssets[index].Item = $scope.reportedAssets[index].BillItem;
                            }
                            else if ($scope.reportedAssets[index].LicenceItem !== null) {
                                $scope.reportedAssets[index].Item = $scope.reportedAssets[index].LicenceItem;
                            }
                            else if ($scope.reportedAssets[index].TonerItem !== null) {
                                $scope.reportedAssets[index].Item = $scope.reportedAssets[index].TonerItem;
                            }
                            else if ($scope.reportedAssets[index].FixtureItem !== null) {
                                $scope.reportedAssets[index].Item = $scope.reportedAssets[index].FixtureItem;
                            }
                            else if ($scope.reportedAssets[index].AccessoryItem !== null) {
                                $scope.reportedAssets[index].Item = $scope.reportedAssets[index].AccessoryItem
                            }
                        });

                        $scope.registerCount = $scope.reportedAssets.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.reportedAssets
                        });
                    }
                    else {
                        toaster.error("GetComponentModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetComponentModels", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.GetItemTypeTypes = function () {
            enumService.GetItemTypeTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.ItemTypes = result.Data;

                        $.each($scope.ItemTypes, function (index, value) {
                            var parameter = { id: value.Value, title: value.Text };
                            $scope.ItemTypesFilter.push(parameter);
                        });

                        $scope.GetUsers();
                    } else {
                        toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetItemTypeTypes();

        $scope.GetUsers = function () {
            userService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                        $scope.GetReportedAssetsByCompany();
                    } else {
                        toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);
