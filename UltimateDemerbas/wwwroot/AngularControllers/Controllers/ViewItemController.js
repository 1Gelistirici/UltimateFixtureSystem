MainApp.controller("ViewItemController", ["$scope", "toaster", "FixtureService", "UserService", "ItemHistoryService", "NgTableParams",
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

        $(document).ready(function () {
            routeId = getParameterInUrlByName('id');
            if (routeId !== undefined || routeId !== null)
                routeId = parseInt(routeId);

            if (routeId > 0) {
                $scope.GetUsers();
                $scope.GetItemHistoryByCompany();
            }
        });



        $scope.generateQRCode = function () {
            var qrcode = new QRCode("qrcode",
                `serialNumber:${$scope.Item.SerialNumber}-id:${$scope.Item.Id}-itemType:4`);

            downloadQRCode();
        }

        function downloadQRCode() {
            var qrCodeImage = document.querySelector("#qrcode img");

            qrCodeImage.onload = function () {
                var qrcodeDiv = document.getElementById('qrcode');
                var linkElement = qrcodeDiv.querySelector('img');
                var srcValue = linkElement.getAttribute('src');

                var img = new Image();
                img.src = srcValue;

                img.onload = function () {
                    var canvas = document.createElement("canvas");
                    canvas.width = img.width;
                    canvas.height = img.height;
                    var ctx = canvas.getContext("2d");
                    ctx.drawImage(img, 0, 0);

                    var dataURL = canvas.toDataURL("image/png");

                    var link = document.createElement("a");
                    link.href = dataURL;
                    link.download = `${$scope.Item.Name}-qrcode.png`;
                    link.click();

                    $("#qrcode").empty();
                };
            };
        }


    }]);
