MainApp.service("BillService", ["$http",
    function ($http) {

        this.GetBills = function (success, error) {
            $http.get("/Bill/GetBills").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.DeleteBill = function (Id, success, error) {
            $http.post('/Bill/DeleteBill', { Id: Id }).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.UpdateBill = function (parameter, success, error) {
            $http.post('/Bill/UpdateBill', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddBill = function (parameter, success, error) {
            $http.post('/Bill/AddBill', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.DeleteBillItem = function (parameter, success, error) {
            $http.post('/Bill/DeleteBillItem', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

