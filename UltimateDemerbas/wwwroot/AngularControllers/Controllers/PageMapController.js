MainApp.controller("PageMapController", ["$scope", "MenuService", "toaster",
    function ($scope, menuService, toaster) {



        $scope.GetMenu = function () {
            menuService.GetMenu(
                function success(result) {
                    if (result.IsSuccess) {
                        console.log(result.Data);






                        google.charts.load('current', { packages: ["orgchart"] });
                        google.charts.setOnLoadCallback(function () { drawChart(result.Data) });
                    }
                    else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetMenu();


        function drawChart(menus) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Name');
            data.addColumn('string', 'Manager');


            data.addRows([
                [{ 'v': 'UFS' }, ''],
            ]);

            $.each(menus, function (index, value) {

                if (value.Dependency === 0) {
                    data.addRows([
                        [{ 'v': value.Name }, 'UFS'],
                    ]);

                    $.each(value.Children, function (index, childValue) {
                        data.addRows([
                            [{ 'v': childValue.Name }, value.Name],
                        ]);
                    });
                }
            });


            // Create the chart.
            var chart = new google.visualization.OrgChart(document.getElementById('pageMap'));
            // Draw the chart, setting the allowHtml option to true for the tooltips.
            chart.draw(data, { 'allowHtml': true, allowCollapse: false, size: 'small' });
        }


    }]);
