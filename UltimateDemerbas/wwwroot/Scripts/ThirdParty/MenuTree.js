$(document).ready(function () {

    var to = false;
    $(function () {
        $('#MenuTree_div').jstree();
    });


    $('#MenuTree_div').on("changed.jstree", function (e, data) {

        $("#MenuTree_div").jstree(true).search(data.node.data.name);
        $("#txtMenuNameSearch").val(data.node.data.name);
        $("#selectedMenuParentId").val(data.node.data.id);
        
    });


    $('#MenuTree_div').jstree({
        "core": {
            "themes": {
                "name": "proton",
                "variant": "large",
                "icons": false
            }
        },
        "checkbox": {
            "keep_selected_style": true
        },

        "types": {
            "default": {
                "icon": "fa fa-folder icon-state-warning icon-lg"
            },
            "file": {
                "icon": "fa fa-file icon-state-warning icon-lg"
            }
        },
        "plugins": ["wholerow", "types", "search"]
    });


    $("#txtMenuNameSearch").keyup(function () {
        if (to) {
            clearTimeout(to);
        }
        to = setTimeout(function () {
            var v = $("#txtMenuNameSearch").val();
            $("#MenuTree_div").jstree(true).search(v);
        }, 250);

    });

});