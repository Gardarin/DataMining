indexApp.controller("ResearchController", ['$scope', '$http', function ($scope, $http) {
    $scope.listResearch = [];
    $scope.SelectedResearch = {};

    $scope.GetResearches = function () {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'GetResearches',
            method: "POST",
            data: ""
        }).success(function (answ) {
            $scope.listResearch = answ;
        });
    }
    
    $scope.GetResearchesById = function (id) {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'GetResearchesById',
            method: "POST",
            data: id
        }).success(function (answ) {
            $scope.GetResearchesById = answ;
        });
    }

    $scope.CreateResearch = function (name, description) {
        var obj = {
            "name": name,
            "description": description
        };

        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'CreateResearch',
            method: "POST",
            data: obj
        }).success(function (answ) {
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