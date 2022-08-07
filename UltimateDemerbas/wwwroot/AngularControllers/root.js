
var MainApp = angular.module('MainApp', ['toaster','ngTable']);

MainApp.factory('$confirm', [
    function () {
        function show(header, question, ok, cancel) {
            window.swal({
                title: header,
                text: question,
                icon: "warning",
                buttons: ["Hayır", "Evet"],
                dangerMode: true
            })
                .then((willDelete) => {
                    if (willDelete) {
                        ok();
                    }
                });
        }

        return {
            Show: show
        }
    }]);