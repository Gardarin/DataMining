indexApp.controller("DataController", ['$scope', '$http', function ($scope, $http) {
    $scope.listResearch = [];
    $scope.SelectedInputDatas = {};

    $scope.GetInputDatas = function (researchId, inputDataId) {
        var obj = {
            "reserchId": researchId,
            "inputDataId": inputDataId
        };

        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'GetInputDatas',
            method: "POST",
            data: obj
        }).success(function (answ) {
            $scope.SelectedInputDatas = answ;
        });
    }

    $scope.SetInputData = function (researchId, inputDataId) {
        var obj = {
            "reserchId": researchId,
            "inputDataId": inputDataId
        };

        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'SetInputData',
            method: "POST",
            data: obj
        }).success(function (answ) {
        });
    }

    $scope.UploadInputData = function (name, inputData) {
        var obj = {
            "name": name,
            "data": inputData
        };

        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'UploadInputData',
            method: "POST",
            data: obj
        }).success(function (answ) {
        });
    }

    $scope.DeleteInputData = function (researchId, inputDataId) {
        var obj = {
            "reserchId": researchId,
            "inputDataId": inputDataId
        };

        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'DeleteInputData',
            method: "POST",
            data: obj
        }).success(function (answ) {
        });
    }
}
]);