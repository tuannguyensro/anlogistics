(function (app) {
    'use strict';
    app.service('authenticationService', ['$http', '$q', '$window', 'localStorageService', 'authData',
        function ($http, $q, $window, localStorageService, authData) {
            var tokenInfo;

            this.setTokenInfo = function (data) {
                tokenInfo = data;
                localStorageService.set("TokenInfo", JSON.stringify(tokenInfo));
            };

            this.getTokenInfo = function () {
                return tokenInfo;
            };

            this.removeToken = function () {
                tokenInfo = null;
                localStorageService.set("TokenInfo", null);
                localStorageService.remove("TokenInfo");
            };

            this.init = function () {
                var tokenInfo = localStorageService.get("TokenInfo");
                if (tokenInfo) {
                    tokenInfo = JSON.parse(tokenInfo);
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = tokenInfo.userName;
                    authData.authenticationData.image = tokenInfo.image;
                    authData.authenticationData.createdDate = tokenInfo.createdDate;
                    authData.authenticationData.accessToken = tokenInfo.accessToken;

                }
            };

            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];
                if ((authData.authenticationData != undefined) && (authData.authenticationData.accessToken != undefined) && (authData.authenticationData.accessToken != null) && (authData.authenticationData.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + authData.authenticationData.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded';
                }
            };

            this.init();
        }
    ]);
})(angular.module('TNS.common'));