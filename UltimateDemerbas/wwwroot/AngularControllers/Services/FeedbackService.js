MainApp.service("FeedbackService", ["$http",
    function ($http) {

        this.GetFeedbackByUser = function (success, error) {
            $http.get('/Feedback/GetFeedbackByUser').then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

        this.AddFeedback = function (parameter, success, error) {
            $http.post('/Feedback/AddFeedback', JSON.stringify(parameter)).then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        };

    }]);

