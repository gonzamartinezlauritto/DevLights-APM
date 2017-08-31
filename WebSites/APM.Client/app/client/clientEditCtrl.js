(function () {
    "use strict";

    angular
        .module("productManagement")
        .controller("ClientEditCtrl",
                     ClientEditCtrl);

    function ClientEditCtrl(clientResource,$stateParams) {
        var vm = this;
        vm.client = {};
        vm.message = '';

        var clientId = $stateParams.clientId ? $stateParams.clientId : 0;

        clientResource.get({ id: clientId },
            function (data) {
                vm.client = data;
                vm.originalClient = angular.copy(data);
            });

        if (vm.client && vm.client.clientId) {
            vm.title = "Edit: " + vm.client.clientName;
        }
        else {
            vm.title = "New Client";
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.client.clientId) {
                vm.client.$update({ id: vm.client.clientId },
                    function (data) {
                        vm.message = "... Save complete";
                    });
            }
            else {
                vm.client.$save(
                    function (data) {
                        vm.originalClient = angular.copy(data);
                        vm.message = "... SAve Complete";
                    });
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.client = angular.copy(vm.originalClient);
            vm.message = "";
        };

       
    }
}());
