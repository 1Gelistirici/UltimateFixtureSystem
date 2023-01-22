var SetFuncReport;

MainApp.controller('MenuInsertController', ["$scope", "MenuService", "toaster", function ($scope, MenuService, toaster) {

    $scope.OriginalData = [];
    $scope.UpdatedData = [];
    $scope.IsMenuOrderChanged = false;
    $scope.IsMenuChildOrderChanged = false;

    $("#sortable").sortable({
        change: function (event, ui) {
            //console.log(ui.item.context.dataset.id);
            $scope.IsMenuOrderChanged = true;
            document.getElementById("btnUpdateMenuOrder").style.display = "block";
        }
    });





    $scope.menues = [];
    $scope.UpdatedChildData = [];

    $(".sub-menu").sortable({
        update: function (event, ui) {

            App.blockUI();
            $scope.IsMenuChildOrderChanged = true;
            $scope.UpdatedChildData = $("#childrenMenu" + ui.item.context.dataset.parentid).sortable("toArray");

            if ($scope.UpdatedChildData && $scope.UpdatedChildData.length > 0) {
                for (var i = 0; i < $scope.UpdatedChildData.length; i++) {
                    var parameters = {
                        Id: $scope.UpdatedChildData[i].split(',')[0],
                        ParentId: $scope.UpdatedChildData[i].split(',')[1],
                        MenuName: $scope.UpdatedChildData[i].split(',')[2],
                        MenuLink: $scope.UpdatedChildData[i].split(',')[3],
                        MenuIcon: $scope.UpdatedChildData[i].split(',')[4],
                        MenuOptions: $scope.UpdatedChildData[i].split(',')[5],
                        Order: 1000 + i
                    };
                    $scope.menues.push(parameters);
                }
                if ($scope.menues.length > 0) {
                    $scope.UpdateMenuForMenuOrder($scope.menues);
                } else {
                    toaster.warning("Menü", "Menü Sıralamasında değişiklik yapmadan güncelleme işlemi yapılamaz");
                    document.getElementById("btnUpdateMenuOrder").style.display = "none";
                }
            }

        }
    });



    $(".sub-menu").sortable({
        start: function (event, ui) {
            $scope.OriginalChildData = $("#childrenMenu" + ui.item.context.dataset.parentid).sortable("toArray");
        }
    });


    $scope.GetOriginalData = function () {
        var itemOrder = $('#sortable').sortable("toArray");
        $scope.OriginalData = itemOrder;
    };
    $scope.GetOriginalData();

    $scope.UpdateOrder = function () {
        var itemOrder = $('#sortable').sortable("toArray");
        $scope.UpdatedData = itemOrder;
        for (var i = 0; i < itemOrder.length; i++) {
            if ($scope.OriginalData[i] !== $scope.UpdatedData[i]) {
                var parameters = {
                    Id: $scope.UpdatedData[i].split(',')[0],
                    ParentId: $scope.UpdatedData[i].split(',')[1],
                    MenuName: $scope.UpdatedData[i].split(',')[2],
                    MenuLink: $scope.UpdatedData[i].split(',')[3],
                    MenuIcon: $scope.UpdatedData[i].split(',')[4],
                    MenuOptions: $scope.UpdatedData[i].split(',')[5],
                    Order: i + 1
                };
                $scope.menues.push(parameters);
            }
        }
        if ($scope.menues.length > 0) {
            $scope.UpdateMenuForMenuOrder($scope.menues);
        } else {
            toaster.warning("Menü", "Menü Sıralamasında değişiklik yapmadan güncelleme işlemi yapılamaz");
            document.getElementById("btnUpdateMenuOrder").style.display = "none";
        }
    };



    $scope.UpdateMenuForMenuOrder = function (menues) {
        App.blockUI();
        MenuService.UpdateMenues(menues,
            function success(response) {
                if (response.IsSuccess) {
                    location.replace("/Menu/Index");
                    toaster.success("Güncelleme", "Güncelleme işlemi başarılı");
                    App.unblockUI();
                } else {
                    toaster.error("Güncelleme", "Güncelleme işlemi yapılırken bir hata oluştu");
                    App.unblockUI();
                }
            },
            function error() {
                toaster.error("Güncelleme", "Güncelleme işlemi yapılırken bir hata oluştu");
                App.unblockUI();
            });
    };


    $scope.checkMenuName = function () {
        $scope.menuNameSituation = false;
    };

    $scope.checkMenuLink = function () {
        $scope.menuLinkSituation = false;
    };

    $scope.checkMenuIcon = function () {
        $scope.menuIconSituation = false;
    };


    $scope.selectionmesEdit = [];

    $scope.toggleSelectionMessageEdit = function toggleSelection(levelNumber) {
        var idx = $scope.selectionmesEdit.indexOf(levelNumber);
        if (idx > -1) {
            $scope.selectionmesEdit.splice(idx, 1);
        }
        else {
            $scope.selectionmesEdit.push(levelNumber);

        }
    };



    $scope.btnMenuInsertPopUp = function (parentId) {
        $scope.ParentId = parentId;
        $scope.MenuOptions = parentId === 0 ? 1 : 0;
        $("#menuInsertPopup").modal("show");
    };


    $scope.btnMenuUpdatePopUp = function (id, parentId, name, link, ikon, order) {

        var mainResultData = $scope.getAllMenus.find(x => x.Id === id);
        $scope.getMainResultData = mainResultData;

        if (mainResultData !== undefined) {
            $scope.setMenuRefId = mainResultData.Id;
            document.getElementById("reportCategoryHidden").style.visibility = "hidden";
            if (mainResultData.Id === 7 || mainResultData.Id === 60 || mainResultData.Id === 12) {
                document.getElementById("reportCategoryHidden").style.visibility = "visible";
            }

        } else {
            document.getElementById("reportCategoryHidden").style.visibility = "hidden";

        }



        var mergeChildrenData = [];
        for (var i = 0; i < $scope.getAllMenus.length; i++) {
            var resultData = $scope.getAllMenus[i];
            if (resultData.Children.length !== 0) {

                mergeChildrenData = mergeChildrenData.concat(resultData.Children);

            }

        }
        $scope.getChildUpdate = mergeChildrenData.find(x => x.Id === id && x.ParentId === parentId);

        if ($scope.getChildUpdate !== undefined) {
            $scope.setMenuRefId = $scope.getChildUpdate.Id;

            document.getElementById("reportCategoryHidden").style.visibility = "hidden";
            if ($scope.getChildUpdate.ParentId === 7 || $scope.getChildUpdate.ParentId === 60 || $scope.getChildUpdate.ParentId === 12) {
                document.getElementById("reportCategoryHidden").style.visibility = "visible";
            }
        }


        var parameter = {
            MenuRefId: $scope.setMenuRefId
        };

        MenuService.GetCategoryMenusByMenuRefId(parameter,
            function success(response) {
                if (response.IsSuccess) {

                    if (response.Data.length <= 0) {
                        $scope.selectionmesEdit = [];
                    } else {
                        var setData = [];
                        for (var i = 0; i < response.Data.length; i++) {
                            var resultData = response.Data[i];
                            setData.push(resultData.ReportCategoryRefId);
                        }

                        $scope.selectionmesEdit = setData;
                    }

                    App.unblockUI();
                } else {

                    App.unblockUI();
                }

            },
            function error() {

                App.unblockUI();
            });






        //if (mainResultData != undefined) {
        //    $scope.ReportCategoryRefId = mainResultData.ReportCategoryRefId
        //    if (mainResultData.ReportCategoryRefId == 0) {
        //        document.getElementById("reportCategoryHidden").style.visibility = "hidden";
        //    }
        //    if (mainResultData.ReportCategoryRefId != 0 || mainResultData.Id == 7 || mainResultData.Id == 60 || mainResultData.Id == 12) {

        //        if (mainResultData.ReportCategoryRefId !=0) {
        //            var mainReportCategoryEx = $scope.reportCategory.find(x => x.Id == mainResultData.ReportCategoryRefId)


        //            if (mainReportCategoryEx != undefined) {
        //                document.getElementById(mainReportCategoryEx.ReportName).selected = "true";
        //            } else {
        //                document.getElementById("nullValue").selected = "false";
        //            }


        //        } else {
        //            document.getElementById("nullValue").selected = "false";
        //        }




        //        document.getElementById("reportCategoryHidden").style.visibility = "visible";
        //    }
        //} else {
        //    document.getElementById("reportCategoryHidden").style.visibility = "hidden";
        //}



        //if ($scope.getChildUpdate !== undefined) {
        //    if ($scope.getChildUpdate.ParentId == 7 || $scope.getChildUpdate.ParentId == 60 || $scope.getChildUpdate.ParentId == 12) {



        //        var mainReportCategoryEx = $scope.reportCategory.find(x => x.Id == $scope.getChildUpdate.ReportCategoryRefId)

        //        if (mainReportCategoryEx !== undefined) {
        //            document.getElementById(mainReportCategoryEx.ReportName).selected = "true";
        //        }

        //        document.getElementById("reportCategoryHidden").style.visibility = "visible";
        //    }
        //}


        $scope.Id = id;
        $("#menuUpdatePopup").modal("show");
        $("#txtMenuNameSearch").val(name);
        $("#txtSelectedcompanyGroupUpdatePopup").val(name);
        $("#MenuTree_div").jstree(true).search(name);
        $scope.MenuName = name;
        $scope.MenuLink = link;
        $scope.MenuIcon = ikon;
        $scope.ParentId = parentId;
        $scope.Order = order;
        var resultData = [];

        SetFuncReport = function (id) {
            $scope.Id = id;
            if (id != 0) {
                resultData = $scope.getAllMenus.find(x => x.Id === $scope.Id);


                if (resultData !== undefined) {
                    $scope.setMenuRefId = resultData.Id;
                    document.getElementById("reportCategoryHidden").style.visibility = "hidden";
                    if (resultData.Id === 7 || resultData.Id === 60 || resultData.Id === 12) {
                        document.getElementById("reportCategoryHidden").style.visibility = "visible";
                    }

                } else {
                    document.getElementById("reportCategoryHidden").style.visibility = "hidden";

                }


                var parameter = {
                    MenuRefId: $scope.setMenuRefId
                };

                MenuService.GetCategoryMenusByMenuRefId(parameter,
                    function success(response) {
                        if (response.IsSuccess) {

                            if (response.Data.length <= 0) {
                                $scope.selectionmesEdit = [];
                            } else {
                                var setData = [];
                                for (var i = 0; i < response.Data.length; i++) {
                                    var resultData = response.Data[i];
                                    setData.push(resultData.ReportCategoryRefId);
                                }

                                $scope.selectionmesEdit = setData;
                            }

                            App.unblockUI();
                        } else {

                            App.unblockUI();
                        }

                    },
                    function error() {

                        App.unblockUI();
                    });



                $scope.toggleSelectionMessageEdit = function toggleSelection(levelNumber) {
                    var idx = $scope.selectionmesEdit.indexOf(levelNumber);
                    if (idx > -1) {
                        $scope.selectionmesEdit.splice(idx, 1);
                    }
                    else {
                        $scope.selectionmesEdit.push(levelNumber);

                    }

                };

                $("#menuUpdatePopup").modal("show");
                $("#txtMenuNameSearch").val(resultData.MenuName);
                $("#txtSelectedcompanyGroupUpdatePopup").val(resultData.MenuName);
                $("#MenuTree_div").jstree(true).search(resultData.MenuName);
                document.getElementById("inputMenuNameUpdateError").value = resultData.MenuName;
                $scope.MenuName = document.getElementById("inputMenuNameUpdateError").value;
                document.getElementById("inputMenuLinkUpdateError").value = resultData.MenuLink;
                $scope.MenuLink = document.getElementById("inputMenuLinkUpdateError").value;
                document.getElementById("MenuIconUpdate").value = resultData.MenuIcon;
                $scope.MenuIcon = document.getElementById("MenuIconUpdate").value;
                $scope.Order = resultData.Order;
                $scope.ParentId = resultData.ParentId;
                $scope.ReportCategoryRefId = resultData.ReportCategoryRefId;

                $scope.editCategoryReportId = $scope.ReportCategoryRefId;

                //if (reportCategoryEx == undefined) {
                //    document.getElementById("nullValue").selected = "false";

                //}

                //if ($scope.editCategoryReportId !== 0) {
                //    document.getElementById(reportCategoryEx.ReportName).selected = "true";
                //}



                //if (resultData.ReportCategoryRefId == 0) {
                //    document.getElementById("reportCategoryHidden").style.visibility = "hidden"
                //}
                //if (resultData.ReportCategoryRefId != 0 || resultData.Id == 7 || resultData.Id == 60 || resultData.Id == 12) {
                //    document.getElementById("reportCategoryHidden").style.visibility = "visible"
                //}



            }
        };

        var global = [];

        function added(exData) {

            for (var i = 0; i < exData.length; i++) {
                global.push(exData[i]);
                if (exData[i].Children && exData[i].Children.length > 0) {
                    added(exData[i].Children);
                }
            }


        }
        added($scope.getAllMenus);



        for (var i = 0; i < global.length; i++) {
            if ($scope.Id == global[i].Id) {
                $scope.chooseMenu = global[i];
            }

        }
        $scope.editCategoryReportName = "";
        $scope.editCategoryReportId = 0;
        if (!$scope.chooseMenu.ReportCategory) {
            $scope.editCategoryReportName = "Seçiniz";
            $scope.editCategoryReportId = 0;
        } else {
            $scope.editCategoryReportName = $scope.chooseMenu.ReportCategory.ReportName;
            $scope.editCategoryReportId = $scope.chooseMenu.ReportCategory.Id;
        }

    };

    $scope.UpdateMenu = function (category) {
        App.blockUI();
        var generalValidation = false;
        var kokValidation = false;



        //var sel = document.getElementById("selectcategory");
        //var text = sel.options[sel.selectedIndex].value;


        //$scope.setCategoryReportId = parseInt(text);
        var parentId = $("#selectedMenuParentId").val();
        if (parentId !== undefined && parentId !== "") {
            parentId = parseInt(parentId);
            if (parentId === 0 && parentId === $scope.ParentId) {
                generalValidation = true;
                kokValidation = true;
                toaster.error("Güncelleme", "Kök dizinde bulunan bir menüyü kök dizine ekleyemezsiniz");
                App.unblockUI();
            }
            else if ($scope.Id === parentId) // kendini nseçemez parent olarak 
            {
                $scope.ParentId = 0;
            }
            else {
                $scope.ParentId = parseInt(parentId);
            }

        }

        $scope.MenuOptions = $scope.ParentId === 0 ? 1 : 0;
        if (!$scope.MenuName || $scope.MenuName === "") {
            $scope.menuNameSituation = true;
            generalValidation = true;
        }

        if (!$scope.MenuLink || $scope.MenuLink === "") {
            $scope.menuLinkSituation = true;
            generalValidation = true;
        }

        if (!$scope.MenuIcon || $scope.MenuIcon === "") {
            $scope.menuIconSituation = true;
            generalValidation = true;
        }




        if (!generalValidation) {
            var parameters = {
                Id: $scope.Id,
                ParentId: $scope.ParentId,
                MenuName: $scope.MenuName,
                MenuLink: $scope.MenuLink,
                MenuIcon: $scope.MenuIcon,
                MenuOptions: $scope.MenuOptions,
                Order: $scope.Order,
                ReportCategoryRefId: $scope.setCategoryReportId
            };

            $scope.menues[0] = parameters;

            var categoryRefId = $scope.selectionmesEdit;

            MenuService.UpdateMenues($scope.menues, categoryRefId,
                function success(response) {
                    if (response.IsSuccess) {
                        location.replace("/Menu/Index");
                        toaster.success("Güncelleme", "Güncelleme işlemi başarılı");
                        App.unblockUI();
                    } else {
                        toaster.error("Güncelleme", "Güncelleme işlemi yapılırken bir hata oluştu");
                        App.unblockUI();
                    }

                },
                function error() {
                    toaster.error("Güncelleme", "Güncelleme işlemi yapılırken bir hata oluştu");
                    App.unblockUI();
                });
        } else {
            if (!kokValidation)
                toaster.error("Güncelleme", "Lütfen zorunlu alanları doldurunuz");
            App.unblockUI();
        }
    };


    $scope.GetMenus = function () {
        App.blockUI();
        MenuService.GetAllMenus(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.getAllMenus = result.Data;


                    App.unblockUI();
                } else {
                    toaster.error("Rapor Kategori Listeleme", "Rapor Kategori Listeleme işlemi yapılırken hata oluştu");
                    App.unblockUI();
                }
            }, function error() {
                App.unblockUI();
                toaster.error("Rapor Kategori Listeleme", "Rapor Kategori Listeleme işlemi yapılırken hata oluştu");
            });
    };

    $scope.GetMenus();

    $scope.GetReportCategory = function () {
        App.blockUI();
        MenuService.GetReportCategories(
            function success(result) {
                if (result.IsSuccess) {
                    $scope.reportCategory = result.Data;

                    App.unblockUI();
                } else {
                    toaster.error("Rapor Kategori Listeleme", "Rapor Kategori Listeleme işlemi yapılırken hata oluştu");
                    App.unblockUI();
                }
            }, function error() {
                App.unblockUI();
                toaster.error("Rapor Kategori Listeleme", "Rapor Kategori Listeleme işlemi yapılırken hata oluştu");
            });
    };

    $scope.GetReportCategory();



    $scope.selectionmesInsert = [];

    $scope.toggleSelectionMessageInsert = function toggleSelection(levelNumber) {
        var idx = $scope.selectionmesInsert.indexOf(levelNumber);
        if (idx > -1) {
            $scope.selectionmesInsert.splice(idx, 1);
        }
        else {
            $scope.selectionmesInsert.push(levelNumber);
        }

    };


    $scope.SaveMenu = function () {
        App.blockUI();
        var generalValidation = false;
        if (!$scope.Menu || !$scope.Menu.MenuName || $scope.Menu.MenuName === "") {
            $scope.menuNameSituation = true;
            generalValidation = true;
        }

        if (!$scope.Menu || !$scope.Menu.MenuLink || $scope.Menu.MenuLink === "") {
            $scope.menuLinkSituation = true;
            generalValidation = true;
        }

        if (!$scope.Menu || !$scope.Menu.MenuIcon || $scope.Menu.MenuIcon === "") {
            $scope.menuIconSituation = true;
            generalValidation = true;
        }


        if (!generalValidation) {
            var parameters = {
                ParentId: $scope.ParentId,
                MenuName: $scope.Menu.MenuName,
                MenuLink: $scope.Menu.MenuLink,
                MenuIcon: $scope.Menu.MenuIcon,
                MenuOptions: $scope.MenuOptions
            };
            $scope.menu = parameters;
            var reportCategoryId = $scope.selectionmesInsert;
            MenuService.SaveMenu($scope.menu, reportCategoryId,
                function success(response) {
                    if (response.IsSuccess) {
                        location.replace("/Menu/Index");
                        toaster.success("Kaydetme", "Kaydetme işlemi başarılı");
                        App.unblockUI();
                    } else {
                        toaster.error("Kaydetme", "Kaydetme işlemi yapılırken bir hata oluştu");
                        App.unblockUI();
                    }

                },
                function error() {
                    toaster.error("Kaydetme", "Kaydetme işlemi yapılırken bir hata oluştu");
                    App.unblockUI();
                });
        } else {
            toaster.error("Kaydetme", "Lütfen zorunlu alanları doldurunuz");
            App.unblockUI();
        }
    };

    $scope.DeleteMenu = function (id) {

        $scope.id = id;
        App.blockUI();
        swal({
            title: "Emin misiniz?",
            text: "Bu menüyü silmek istediğinizden emin misiniz?, (Menüye bağlı alt menüler de silinecektir)",
            icon: "warning",
            buttons: true,
            dangerMode: true,
            buttons: ['İptal', 'Evet']

        })
            .then((willDelete) => {
                if (willDelete) {



                    if ($scope.id != undefined && $scope.id > 0) {
                        MenuService.DeleteMenu($scope.id,
                            function success(response) {
                                if (response.IsSuccess) {
                                    location.replace("/Menu/Index");
                                    toaster.success("Silme", "Silme işlemi başarılı");
                                    App.unblockUI();
                                } else {
                                    toaster.error("Silme", "Silme işlemi yapılırken bir hata oluştu");
                                    App.unblockUI();
                                }
                            },
                            function error() {
                                toaster.error("Silme", "Silme işlemi yapılırken bir hata oluştu");
                                App.unblockUI();
                            });
                    }
                    else {
                        toaster.error("Silme", "Silme işlemi yapılırken bir hata oluştu");
                        App.unblockUI();
                    }


                } else {
                    App.unblockUI();
                }


            });



    };


}]);
