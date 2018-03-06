(function () {
    'use strict';
    var controllerId = 'reports';
    angular.module('app').controller(controllerId, ['common', 'datacontext', 'reportGenerationService', reports]);

    function reports(common, datacontext, reportGenerationService) {
        var logSuccess = common.logger.getLogFn(controllerId, 'success');

        var vm = this;
        vm.title = 'Reports';
        vm.reportOptions = [
            { id: 1, description: "Exportação Marítimo", checked: true },
            { id: 2, description: "Importação Marítimo", checked: true },
            { id: 3, description: "Exportação Aérea", checked: true },
            { id: 4, description: "Importação Aérea", checked: true },
            { id: 5, description: "Desembaraço", checked: true }
        ];
        vm.people = [];

        //
        vm.requestReports = function () {
            var data = {reports: []};
            for (var i = 0; i < vm.reportOptions.length; i++) {
                if (vm.reportOptions[i].checked)
                    data.reports.push(vm.reportOptions[i].id);
            }

            reportGenerationService.postReports(data.reports)
                .then(function (response) {
                    logSuccess("Report's requested!", null, true);
                });
        }

        activate();
        function activate() {
            var promises = [getPeople()];
            common.activateController(promises, 'nice');
        }

        function getPeople() {
            return datacontext.getPeople().then(function (data) {
                return vm.people = data;
            });
        }
    }
})();