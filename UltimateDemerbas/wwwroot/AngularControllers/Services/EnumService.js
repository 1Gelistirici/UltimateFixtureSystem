﻿MainApp.service("EnumService", ["$http",
    function ($http) {

        this.GetIsActiveTypes = function (success, error) {
            $http.get("/Enum/GetIsActiveTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetItemStatuTypes = function (success, error) {
            $http.get("/Enum/GetItemStatuTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetItemTypeTypes = function (success, error) {
            $http.get("/Enum/GetItemTypeTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetReportStatus = function (success, error) {
            $http.get("/Enum/GetReportStatus").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetProductTypes = function (success, error) {
            $http.get("/Enum/GetProductTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetDepartments = function (success, error) {
            $http.get("/Enum/GetDepartments").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetGenders = function (success, error) {
            $http.get("/Enum/GetGenders").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetImportanceLevels = function (success, error) {
            $http.get("/Enum/GetImportanceLevels").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetTaskActiveStatus = function (success, error) {
            $http.get("/Enum/GetTaskActiveStatus").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }

        this.GetLogTypes = function (success, error) {
            $http.get("/Enum/GetLogTypes").then(
                function (response) {
                    if (success)
                        success(response.data);
                }, error);
        }
    }]);

