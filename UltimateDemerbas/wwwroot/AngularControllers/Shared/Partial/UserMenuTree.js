$(document).ready(function () {

    var to = false;
    $(function () {
        $('#WebUserMenuUpdateTree').jstree();
    });

    $('#WebUserMenuUpdateTree').jstree({
        "core": {
            "themes": {
                "name": "proton",
                "variant": "large",
                "icons": false

            }
        },
        "checkbox": {
            "keep_selected_style": false
            //"three_state": false



        },

        "types": {
            "default": {
                "icon": "fa fa-folder icon-state-warning icon-lg"
            },
            "file": {
                "icon": "fa fa-file icon-state-warning icon-lg"
            }
        },
        "plugins": ["wholerow", "types", "search", "checkbox"]
    });



    $('#WebUserMenuUpdateTree').on("changed.jstree", function (e, data) {



        var i, j, menuList = [], menuNameList = []; menuValueList = [];

        var nodesOnSelectedPath = [...data.selected.reduce(function (acc, nodeId) {
            var node = data.instance.get_node(nodeId);

            return new Set([...acc, ...node.parents, node.id]);
        }, new Set)];

        var dataSelectedWithParent = nodesOnSelectedPath.filter(id => id !== '#');

        for (i = 0, j = dataSelectedWithParent.length; i < j; i++) {

            menuNameList.push(data.instance.get_node(dataSelectedWithParent[i]).data.name);
            menuValueList.push(data.instance.get_node(dataSelectedWithParent[i]).data.menuvalue);
            //alert(data.instance.get_node(data.selected[i]).data.name);
        };
        $("#menuValueList_").val(menuValueList);
        $('#menuUserUpdateNameList_').html(menuNameList.join(', '));
    }).jstree();


    $("#txtUserMenue").keyup(function () {
        if (to) {
            clearTimeout(to);
        }
        to = setTimeout(function () {
            var v = $("#txtUserMenue").val();
            $("#WebUserMenuUpdateTree").jstree(true).search(v);
        }, 250);

    });



});