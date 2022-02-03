MainApp.controller("BillController", ["$scope", "BillService", "BillTypeService", "NgTableParams", "toaster",
    function ($scope, BillService, BillTypeService, NgTableParams, toaster) {

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


        $scope.GetBillTypes = function () {
            BillTypeService.GetBillTypes(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.BillTypes = result.Data;
                    } else {
                        toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura tipi listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBillTypes();

        $scope.GetBills = function () {
            BillService.GetBills(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.Data = result.Data;

                        //$.each($scope.Data, function (index, value) {
                        //    $scope.Data[index].BillDate = new Date($scope.Data[index].BillDate);
                        //});

                        $scope.RegisterCount = $scope.Data.length;
                        $scope.TableParams = new NgTableParams({
                            sorting: { name: 'adc' },
                            count: 20
                        }, {
                            counts: [10, 20, 50],
                            dataset: $scope.Data
                        });
                    } else {
                        toaster.error("Başarısız", "Faturalisteleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Faturalisteleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetBills();

        $scope.DeleteBill = function (data) {
            BillService.DeleteBill(data.Id,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Fatura silindi.")
                    } else {
                        toaster.error("Başarısız", "Fatura silme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura silme işlemi yapılırken bir hata oluştu");
                });
        }

        $scope.UpdateBill = function (data) {
            BillService.UpdateBill(data,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Başarılı", "Fatura güncellendi.");
                    } else {
                        toaster.error("Başarısız", "Fatura güncelleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura güncelleme işlemi yapılırken bir hata oluştu");
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
                        toaster.success("Başarılı", "Fatura kaydedildi.");
                    } else {
                        toaster.error("Başarısız", "Fatura ekleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Başarısız", "Fatura ekleme işlemi yapılırken bir hata oluştu");
                });
        }




        //Popup

        //$scope.AddData = function () {

        //    var parameter = {


        //    };

        //    $scope.PopupData.push(parameter);


        //}

        $scope.PopupTableCol = {
            Name: "Name",
            Piece: "Piece",
            Price: "Price",
            ProductType: "ProductType",
            Model: "Model",
            Category: "Category",
        };


        var testData = [
            { name: "test" },
            { name: "test" },
            { name: "test" },
            { name: "test" },
            { name: "test" },
            { name: "test" },
            { name: "test" }
        ]

        $scope.PopupRegisterCount = testData.length;
        $scope.PopupTableParams = new NgTableParams({
            sorting: { name: 'adc' },
            count: 20
        }, {
            counts: [10, 20, 50],
            dataset: testData
        });



        //$(document).ready(function () {
        //    var table = $('#example').DataTable();

        //    $('#example tbody').on('click', 'tr', function () {
        //        var data = table.row(this).data();
        //        alert('You clicked on ' + data[0] + '\'s row');
        //    });
        //});

        //$scope.PopupForm = function () {
        //    if (IsOpen) {
        //        document.getElementById("myForm").style.display = "block";
        //        IsOpen = false;
        //    } else {
        //        document.getElementById("myForm").style.display = "none";
        //        IsOpen = true;
        //    }
        //}


        //$scope.tester = function () {

        //    $('#sample_editable_1 td').each(function () {
        //        if ($(this).data('original-value') !== $(this).text()) {
        //            //console.log("$(this).data('original-value')", $(this).data('original-value'));
        //            //console.log('original value was: ' + $(this).data('original-value'));
        //            console.log('new value is: ' + $(this).text());
        //            //console.log("$(this)", $(this));
        //        }
        //    });

        //}



    }]);




    //$(document).ready(function () {
    //    var table = $('#example').DataTable();

    //    $('#example tbody').on('click', 'tr', function () {
    //        var data = table.row(this).data();
    //        alert('You clicked on ' + data[0] + '\'s row');
    //    });
    //});


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

