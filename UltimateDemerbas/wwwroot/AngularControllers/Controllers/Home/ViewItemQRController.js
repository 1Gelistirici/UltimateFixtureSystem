MainApp.controller("ViewItemQRController", ["$scope", "toaster", "FixtureService", "UserService", "ItemHistoryService", "NgTableParams",
    function ($scope, toaster, fixtureService, userService, itemHistoryService, NgTableParams) {

        //#region Parameters
        $scope.Item = [];
        $scope.registerCount = 0;
        var routeId = 0;

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


        //#region GETS
        $scope.GetFixture = function () {
            var parameter = {
                Id: routeId
            };

            fixtureService.GetFixture(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Item = result.Data;
                        $scope.Item.LoginSystem = formatDate(new Date($scope.Item.LoginSystem));
                        $scope.Item.AsignedUser = $scope.Users.find(x => x.Id === $scope.Item.UserNo);
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmedik bir hata oluştu.");
                });
        }

        $scope.GetUsers = function () {
            userService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;

                        $scope.GetFixture();
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmedik bir hata oluştu.");
                });
        }

        $scope.GetItemHistoryByCompany = function () {
            itemHistoryService.GetItemHistoryByCompany(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.itemHistory = result.Data;

                        $.each($scope.itemHistory, function (index, value) {
                            value.InsertDate = formatDate(new Date(value.InsertDate));


                            if (value.Component !== null) {
                                value.Item = value.Component;
                            }
                            else if (value.Bill !== null) {
                                value.Item = value.Bill;
                            }
                            else if (value.Licence !== null) {
                                value.Item = value.Licence;
                            }
                            else if (value.Toner !== null) {
                                value.Item = value.Toner;
                            }
                            else if (value.Fixture !== null) {
                                value.Item = value.Fixture;
                            }
                            else if (value.Accessory !== null) {
                                value.Item = value.Accessory
                            }
                        });

                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.itemHistory
                        });
                        $scope.registerCount = $scope.itemHistory.length;
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmedik bir hata oluştu.");
                });
        }

        //#endregion

        $scope.generateQRCode = function () {
            downloadQRCode($scope.Item.SerialNumber, $scope.Item.Id, 4);
        }

        $(document).ready(function () {
            routeId = getParameterInUrlByName('id');
            if (routeId !== undefined || routeId !== null)
                routeId = parseInt(routeId);

            if (routeId > 0) {
                $scope.GetUsers();
                $scope.GetItemHistoryByCompany();
            }
        });

        //video-preview
        function onScanSuccess(decodedText, decodedResult) {
            // Handle on success condition with the decoded text or result.
            console.log(`Scan result: ${decodedText}`, decodedResult);
        }

        function onScanError(errorMessage) {
            // handle on error condition, with error message
        }

        var html5QrcodeScanner = new Html5QrcodeScanner(
            "video-preview", { fps: 10, qrbox: 250 });
    

        $scope.readerQrCode = function () {
            html5QrcodeScanner.render(onScanSuccess, onScanError);
            $("#video-preview__dashboard_section").addClass("hidden");
        }

        $scope.closeQRCodePopup = function () {
            console.log(html5QrcodeScanner);
            html5QrcodeScanner.pause();
            html5QrcodeScanner.clear();
        }






    }]);
