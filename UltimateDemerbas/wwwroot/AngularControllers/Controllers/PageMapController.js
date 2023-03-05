MainApp.controller("PageMapController", ["$scope", "MenuService", "toaster", "$confirm",
    function ($scope, menuService, toaster, $confirm) {


        $scope.updateMenu = function (menuData) {
            menuService.UpdateMenu(menuData,
                function success(result) {
                    if (result.IsSuccess) {

                    }
                    else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }


        $scope.GetMenu = function () {
            menuService.GetMenu(
                function success(result) {
                    if (result.IsSuccess) {
                        $scope.menus = result.Data;
                        google.charts.load('current', { packages: ["orgchart"] });
                        google.charts.setOnLoadCallback(function () { drawChart($scope.menus) });
                    }
                    else {
                        toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("GetTasks", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
        $scope.GetMenu();

        var drawData, orgChart;
        function drawChart() {
            drawData = new google.visualization.DataTable();
            drawData.addColumn('string', 'Name');
            drawData.addColumn('string', 'Manager');
            drawData.addColumn('number', 'Id');

            drawData.addRows([
                [{ 'v': 'UFS' }, '', 0],
            ]);

            $.each($scope.menus, function (index, value) {

                if (value.Dependency === 0) {


                    if (value.IsHaveProblem) {
                        drawData.addRows([
                            [{ 'v': value.Name, f: null }, 'UFS', value.Id],
                        ]);
                    }
                    else {
                        drawData.addRows([
                            [{ 'v': value.Name, f: `${value.Name}<div style="color:red; font-style:italic">Error!!!</div>` }, 'UFS', value.Id],
                        ]);
                    }

                    $.each(value.Children, function (index, childValue) {

                        if (childValue.IsHaveProblem) {
                            drawData.addRows([
                                [{ 'v': childValue.Name, f: null }, value.Name, childValue.Id],
                            ]);
                        }
                        else {
                            drawData.addRows([
                                [{ 'v': childValue.Name, f: `${childValue.Name}<div style="color:red; font-style:italic">Error!!!</div>` }, value.Name, childValue.Id],
                            ]);
                        }

                    });
                }
            });

            orgChart = new google.visualization.OrgChart(document.getElementById('pageMap'));




            // Create the chart.
            // Draw the chart, setting the allowHtml option to true for the tooltips.
            orgChart.draw(drawData, { 'allowHtml': true, allowCollapse: false, size: 'small' });

            google.visualization.events.addListener(orgChart, 'select', $scope.selectMenuItemConfirm);

        }


        function selectMenuItem() {
            console.log(drawData.Wf);

            var row = orgChart.getSelection()[0].row;
            var id = drawData.Wf[row].c[2].v; //Id

            var menuData = getMenuById(id);
            if (!menuData) {
                return;
            }

            menuData.IsHaveProblem = !menuData.IsHaveProblem;
            if (menuData.IsHaveProblem) {
                drawData.Wf[row].c[0].f = null;
            }
            else {
                drawData.Wf[row].c[0].f = `${menuData.Name}<div style="color:red; font-style:italic">Error!!!</div>`;
            }

            refreshOrgChart();

            $scope.updateMenu(menuData);
        }

        jQuery(document).ready(function () {
            $(".sidebar-toggler").click();
        });


        function getMenuById(id) {
            var result;
            result = $scope.menus.find(x => x.Id === id);

            if (!result) {
                result = $scope.menus.find(x => x.Children && x.Children.find(x => x.Id === id));
                if (result) {
                    result = result.Children.find(x => x.Id === id);
                }
            }

            return result;
        }

        function refreshOrgChart() {
            orgChart.draw(drawData, { 'allowHtml': true, allowCollapse: false, size: 'small' });
        }

        $scope.selectMenuItemConfirm = function () {
            if (orgChart.getSelection().length === 0)
                return;

            $confirm.Show("Onay", "Menu durumunu değiştirmek istediğinize emin misiniz?", selectMenuItem);
        }

    }]);
