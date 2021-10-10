MainApp.controller("BillTypesController", function ($scope) {

    $scope.TableColor = TableColor;
    var IsOpen = false;





    $(document).ready(function () {
        var table = $('#example').DataTable();

        $('#example tbody').on('click', 'tr', function () {
            var data = table.row(this).data();
            alert('You clicked on ' + data[0] + '\'s row');
        });
    });

    console.log("sad");


    $scope.PopupForm = function () {
        if (IsOpen) {
            document.getElementById("myForm").style.display = "block";
            IsOpen = false;
        } else {
            document.getElementById("myForm").style.display = "none";
            IsOpen = true;
        }
    }


});