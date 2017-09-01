(function () {
    "use strict";

    angular
        .module("productManagement")
        .controller("SaleCtrl",
        SaleCtrl);

    function SaleCtrl(saleResource, $stateParams) {
        var vm = this;
        vm.sale = {};
        vm.message = '';

        var saleId = $stateParams.saleId ? $stateParams.saleId : 0;

        saleResource.get({ id: saleId },
            function (data) {
                vm.sale = data;
                vm.originalSale = angular.copy(data);
            });

        if (vm.sale && vm.sale.saleId) {
            vm.title = "Edit: " + vm.sale.saleName;
        }
        else {
            vm.title = "New Client";
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.sale.saleId) {
                vm.sale.$update({ id: vm.sale.saleId },
                    function (data) {
                        vm.message = "... Save complete";
                    });
            }
            else {
                vm.sale.$save(
                    function (data) {
                        vm.originalSale = angular.copy(data);
                        vm.message = "... SAve Complete";
                    });
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.sale = angular.copy(vm.originalSale);
            vm.message = "";
        };


    }
}());
