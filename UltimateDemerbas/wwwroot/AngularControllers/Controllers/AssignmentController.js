MainApp.controller("AssignmentController", ["$scope", "AssignmentService", "toaster",
    function ($scope, AssignmentService, toaster,) {

        $scope.Assign = function () {

            if ($scope.Pop.checkRecallDate === undefined) {
                $scope.Pop.checkRecallDate = false;
            }

            var parameter = {
                UserId: parseInt($scope.Pop.user),
                RecallDate: $scope.Pop.recallDate,
                ItemType: $scope.Pop.ItemType,
                ItemId: $scope.Pop.Id,
                Piece: $scope.Pop.piece,
                IsRecall: $scope.Pop.checkRecallDate,
            }

            AssignmentService.AddAssignment(parameter,
                function success(result) {
                    if (result.IsSuccess) {
                        toaster.success("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                        $('#AddAssignment').modal('hide');
                        $scope.$parent.Refresh();
                    } else {
                        toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                    }
                }, function error() {
                    toaster.error("Kat listeleme", "Kat listeleme işlemi yapılırken bir hata oluştu");
                });
        }
    }]);
