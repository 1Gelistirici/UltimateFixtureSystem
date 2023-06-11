MainApp.controller("ViewItemQRController", ["$scope", "toaster", "FixtureService", "UserService", "ComponentService", "AccessoryService", "ItemHistoryService", "NgTableParams",
    function ($scope, toaster, fixtureService, userService, componentService, accessoryService, itemHistoryService, NgTableParams) {

        //#region Parameters
        $scope.Item = [];
        $scope.registerCount = 0;

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
        function getComponent(id) {
            componentService.getComponent(id,
                function success(result) {
                    if (result.IsSuccess) {
                        console.log(result);
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmedik bir hata oluştu.");
                });
        }

        function getAccessoryById(id) {
            accessoryService.getAccessoryById(id,
                function success(result) {
                    if (result.IsSuccess) {
                        console.log(result);
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmedik bir hata oluştu.");
                });
        }

        function getFixture(id) {
            var parameter = {
                Id: id
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
        function getUsers() {
            userService.GetUsers(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Users = result.Data;
                    }
                    else {
                        toaster.error("Başarısız", result.Message);
                    }
                }, function error() {
                    toaster.error("Başarısız", "Beklenmedik bir hata oluştu.");
                });
        }
        function getItemHistoryByCompany() {
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
            getUsers();
            //getItemHistoryByCompany();
        });

        //video-preview
        function onScanSuccess(decodedText, decodedResult) {
            // Handle on success condition with the decoded text or result.
            console.log(`Scan result: ${decodedText}`, decodedResult);

            //var parameter = {
            //    SerialNumber: serialNumber,
            //    ItemId: itemId,
            //    ItemType: itemType
            //}

            //getProductInfo(parameter);
            //$("#qrCodePopup").model("hide");
            //$scope.closeQRCodePopup();

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

        function getProductInfo(parameter) {

            if (parater.ItemType === 2) {
                getAccessoryById(parameter.Id);
            }
            else if (parater.ItemType === 3) {
                getComponent(parameter.Id);
            }
            else if (parater.ItemType === 4) {
                getFixture(parameter.Id);
            }
            else {
                toaster.error("Tanımsız");
            }


        }




    }]);
