﻿var teamManageModule = angular.module('teamManageModule', ['ngRoute', 'nationManageModule']);

var indexController = teamManageModule.controller('indexCtrl', ["$scope", "$http", "teamAjaxCallFactory", function ($scope, $http, teamAjaxCallFactory) {
    $scope.TeamList = [];
    teamAjaxCallFactory.getTeamList(function(response) {
        $scope.TeamList = response;
    });
}]);


var createController = teamManageModule.controller('createCtrl',
    ["$scope", "$http", "$routeParams", "teamAjaxCallFactory", "nationAjaxCallFactory", "$q",
    function ($scope, $http, $routeParams, teamAjaxCallFactory, nationAjaxCallFactory, $q) {
        $scope.Team = {};
        $scope.TeamTypeList = [];
        $scope.NationList = [];

        $scope.teamAjaxCall = teamAjaxCallFactory.getTeamById($routeParams.id, function (response) {
            $scope.Team = response;
        });

        teamAjaxCallFactory.getTeamType(function (data) {
            $scope.TeamTypeList = data;
        });

        nationAjaxCallFactory.getNationList(function (response) {
            $scope.NationList = response;
        });
    }]);


teamManageModule.factory('teamAjaxCallFactory', ["$http",
    function($http) {
        var methods = {};
        methods.getTeamList = function(callback) {
            return $http.get("api/Team").success(callback);
        };
        methods.getTeamById = function (id, callback) {
            if (typeof id != "undefined") {
                return $http.get("api/Team/" + id).success(callback);
            }
        };
        methods.getTeamType = function(callback) {
            return $http.get("api/Team/GetTeamType").success(callback);
        };
        return methods;
    }
]);

/* Routing */

teamManageModule.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/Team/Edit/:id?', {
            templateUrl: appUrl + encodeURI('/Team/Create.cshtml'),
            controller: 'createCtrl'
        }).
        when('/Team', {
            templateUrl: appUrl +  encodeURI('/Team/_TeamList.cshtml'),
            controller: 'indexCtrl'
        }).
        otherwise({
            redirectTo: '/Team'
        });
}])