indexApp.controller("AlgorithmController", ['$scope', '$http', function ($scope, $http) {
    $scope.listAlgorithm = [];
    $scope.SelectedAlgorithm = {};

    $scope.GetAlgorithms = function () {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'GetAlgorithms',
            method: "POST",
            data: ""
        }).success(function (answ) {
            $scope.listAlgorithm = answ;
        });
    }

    $scope.GetAlgorithmById = function (researchId) {
        var obj = {
            "researchId": researchId,
        };
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'GetAlgorithmById',
            method: "POST",
            data: obj
        }).success(function (answ) {
            $scope.SelectedAlgorithm = answ;
        });
    }
    
    $scope.SetAlgorithm = function (researchId, algorithmId) {
        var obj = {
            "reserchId": researchId,
            "algorithmId": algorithmId
        };

        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'SetAlgorithm',
            method: "POST",
            data: obj
        }).success(function (answ) {
            
        });
    }

    $scope.DeleteAlgorithm = function (id) {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'DeleteAlgorithm',
            method: "POST",
            data: id
        }).success(function (answ) {
        });
    }
}
]);