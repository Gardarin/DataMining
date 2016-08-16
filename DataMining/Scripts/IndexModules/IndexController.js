var indexApp = angular.module('indexApp', []);
indexApp.controller("UserController", ['$scope', '$http', function ($scope, $http) {

    $scope.Init = function () {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'Init',
            method: "POST",
            data: ""
        }).success(function (answ) {
        });
    }
    }
]);