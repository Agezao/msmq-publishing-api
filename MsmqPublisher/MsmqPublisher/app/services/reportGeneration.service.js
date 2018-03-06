(function () {
    'use strict';

    var serviceId = 'reportGenerationService';
    angular.module('app').factory(serviceId, ['common', '$http', reportGenerationService]);

    function reportGenerationService(common, $http) {

        var service = {
            postReports: postReports
        };

        return service;

        function postReports(data) {
            var req = {
                method: 'POST',
                url: '/api/reports',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: data
            }

            return $http(req);
        }
    }
})();