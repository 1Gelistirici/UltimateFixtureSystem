MainApp.controller("BillController", ["$scope", "BillService", "BillTypeService", "$http", "NgTableParams", function ($scope, BillService, BillTypeService, $http, NgTableParams) {

    $scope.RegisterCount = 0;
    $scope.Pop = [];

    $scope.TableCol = {
        BillNo: "Bill No",
        BillDate: "Bill Date",
        Price: "Price",
        Comment: "Comment",
        Product: "Product",
        Piece: "Piece",
        TypeNo: "Bill Type",
        Items: "Items",
    };

    $scope.ttt = function () {
        return 1;
    }

    $scope.GetBillTypes = function () {
        BillTypeService.GetBillTypes(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.BillTypes = result.Data;
                    console.log("test");
                    console.log($scope.BillTypes);
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }
    $scope.GetBillTypes();

    $scope.GetBills = function () {
        BillService.GetBills(
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
    $scope.GetBills();

    $scope.DeleteBill = function (data) {
        BillService.DeleteBill(data.Id,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.UpdateBill = function (data) {
        BillService.UpdateBill(data,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });
    }

    $scope.AddBill = function () {

        var data = {
            "Name": $scope.Pop.Name,
            "Piece": $scope.Pop.Piece,
            "Boundary": $scope.Pop.Boundary,
            "Price": $scope.Pop.Price
        }

        BillService.AddBill(data,
            function success(result) {
                if (result.IsSuccess) {
                } else {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                }
            }, function error() {
                toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
            });

    }


    //$(document).ready(function () {
    //    var table = $('#example').DataTable();

    //    $('#example tbody').on('click', 'tr', function () {
    //        var data = table.row(this).data();
    //        alert('You clicked on ' + data[0] + '\'s row');
    //    });
    //});

    //console.log("sad");


    //$scope.PopupForm = function () {
    //    if (IsOpen) {
    //        document.getElementById("myForm").style.display = "block";
    //        IsOpen = false;
    //    } else {
    //        document.getElementById("myForm").style.display = "none";
    //        IsOpen = true;
    //    }
    //}

}]);




    //$(document).ready(function () {
    //    var table = $('#example').DataTable();

    //    $('#example tbody').on('click', 'tr', function () {
    //        var data = table.row(this).data();
    //        alert('You clicked on ' + data[0] + '\'s row');
    //    });
    //});

    //console.log("sad");


    //$scope.PopupForm = function () {
    //    if (IsOpen) {
    //        document.getElementById("myForm").style.display = "block";
    //        IsOpen = false;
    //    } else {
    //        document.getElementById("myForm").style.display = "none";
    //        IsOpen = true;
    //    }
    //}


    //$http.get("https://localhost:44331/api/Toners")
    //    .then(function (response) {
    //       var deneme = response.data.Data;
    //    });

