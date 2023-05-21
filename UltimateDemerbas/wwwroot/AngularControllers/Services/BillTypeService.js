MainApp.service("BillTypeService", ["$http",
    function ($http) {

        this.GetBillTypes = function (success, error) {
            $http.get("/BillType/GetBillTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteBillType = function (Id, success, error) {
            $http.post('/BillType/DeleteBillType', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateBillType = function (data, success, error) {
            $http.post('/BillType/UpdateBillType', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddBillType = function (data, success, error) {
            $http.post('/BillType/AddBillType', JSON.stringify(data)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.GetBillTypeByCompanyRefId = function (success, error) {
            $http.post('/BillType/GetBillTypeByCompanyRefId').then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

