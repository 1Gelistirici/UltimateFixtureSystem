MainApp.controller("ReportHistoryController", ["$scope", "ReportService", "toaster", "NgTableParams", "$confirm", "EnumService", "UserService",
    function ($scope, reportService, toaster, NgTableParams, $confirm, enumService, userService) {

        $scope.registerCount = 0;
        $scope.Pop = [];
        $scope.ItemTypesFilter = [];
        $scope.reportStatusFilter = [];

        $scope.TableCol = {
            UserId: "Responding User"
            , AssignmentId: "Assignment User"
            , ItemType: "Item Type"
            , ItemId: "Item Name"
            , Statu: "Statu"
            , ReportDetail: "Detail"
            , ReportSubject: "Subject"
            , InsertDate: "Processing Time"
            , Comment: "Answer"
        };

        $scope.GetReportsByUserRefId = function () {
            reportService.GetReportsByUserRefId(
                function success(result) {
                    if (result.IsSuccess) {
                        console.log("result.Data", result.Data);
                        $scope.reportedAssets = result.Data;

                        $.each($scope.reportedAssets, function (index, value) {

                            $scope.reportedAssets[index].InsertDate = formatDate(new Date($scope.reportedAssets[index].InsertDate));
                            $scope.reportedAssets[index].User = $scope.Users.find(x => x.Id === value.UserId);
                            $scope.reportedAssets[index].Assignment = $scope.Users.find(x => x.Id === value.AssignmentId);
                            $scope.reportedAssets[index].RecallDate = new Date($scope.reportedAssets[index].RecallDate).toLocaleString();
                            $scope.reportedAssets[index].ItemTypeTextValue = $scope.ItemTypes.find(x => x.Value === value.ItemType);
                            $scope.reportedAssets[index].ReportStatu = $scope.reportStatus.find(x => x.Value === value.Statu);

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
                        toaster.error("Başarısız", result.Message);
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

                        $scope.GetReportStatus();
                    } else {
                        toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetItemTypeTypes();

        $scope.GetReportStatus = function () {
            enumService.GetReportStatus(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.reportStatus = result.Data;

                        $.each($scope.reportStatus, function (index, value) {
                            var parameter = { id: value.Value, title: value.Text };
                            $scope.reportStatusFilter.push(parameter);
                        });

                        $scope.GetUsers();
                    } else {
                        toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetItemTypeTypes", "Item Type listeleme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.GetUsers = function () {
            userService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                        $scope.GetReportsByUserRefId();
                    } else {
                        toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetUsers", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }

    }]);
