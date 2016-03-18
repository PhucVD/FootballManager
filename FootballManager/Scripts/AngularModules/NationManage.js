var nationManageModule = angular.module('nationManageModule', []);

nationManageModule.factory('nationAjaxCallFactory', ["$http",
    function ($http) {
        var methods = {};
        methods.getNationList = function (callback) {
            return $http.get("api/Nation").success(callback);
        };
        return methods;
    }
]);
