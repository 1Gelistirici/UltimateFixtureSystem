var MainApp = angular.module('MainApp', ['ui.bootstrap', "toaster", 'ngTable','ngSanitize']);


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

MainApp.directive("timepicker", function () {

    function link(scope, element, attrs) {
        element.timepicker({
            autoclose: true,
            minuteStep: 5,
            showSeconds: false,
            showMeridian: false,
            defaultTime: null
        });
       
    }

    return {
        require: 'ngModel',
        link: link
    };
});

MainApp.directive('datepickerbanner', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attr, ctrl) {
              element.datepicker({
                  autoclose: true,
                  beforeShowDay: $.noop,
                  beforeShowMonth: $.noop,
                  beforeShowYear: $.noop,
                  calendarWeeks: false,
                  clearBtn: true,
                  toggleActive: false,
                  daysOfWeekDisabled: [],
                  daysOfWeekHighlighted: [],
                  datesDisabled: [],
                  endDate: Infinity,
                  forceParse: true,
                  format: 'dd.mm.yyyy',
                  keyboardNavigation: true,
                  language: 'tr',
                  minViewMode: 0,
                  maxViewMode: 2,
                  multidate: false,
                  multidateSeparator: ',',
                  orientation: "auto",
                  rtl: false,
                  startDate: -Infinity,
                  startView: 0,
                  todayBtn: "linked",
                  todayHighlight: false,
                  weekStart: 0,
                  disableTouchKeyboard: false,
                  enableOnReadonly: true,
                  showOnFocus: true,
                  zIndexOffset: 10,
                  container: 'body',
                  immediateUpdates: false,
                  title: ''
              });
        }
    };
});

//VPSApp.controller("ConfirmController", [
//function ($scope, $uibModalInstance, Header, Question) {
//    $scope.q = Question;
//    $scope.h = Header;

//    $scope.ok = function () {
//        $uibModalInstance.close("Ok");
//    };

//    $scope.cancel = function () {
//        $uibModalInstance.dismiss();
//    };
//}]);