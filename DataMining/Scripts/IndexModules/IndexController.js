var indexApp = angular.module('indexApp', []);
indexApp.controller("UserController", [
    '$scope', '$http', function ($scope, $http) {
        $scope.list = [];
        $scope.GetResearches = function() {
            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'GetResearches',
                method: "POST",
                data: ""
            }).success(function(answ) {
                $scope.list = answ;
            });
        }

        $scope.SelectedResearch = {};
        $scope.GetResearchesById = function (id) {
            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'GetResearches',
                method: "POST",
                data: id
            }).success(function (answ) {
                $scope.GetResearchesById = answ;
            });
        }

        $scope.CreateResearch = function(name, description) {
            var obj = {
                "name": name,
                "description": description
            };

            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'CreateResearch',
                method: "POST",
                data: obj
            }).success(function(answ) {
            });
        }

        $scope.DeleteResearch = function (id) {

            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'DeleteResearch',
                method: "POST",
                data: id
            }).success(function (answ) {
            });
        }
    }
]);