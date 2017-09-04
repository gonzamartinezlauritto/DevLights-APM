(function () {
    "use strict";

    angular
        .module("productManagement")
        .controller("SaleCtrl",
        SaleCtrl);

    function SaleCtrl(clientResource, productResource, $stateParams, saleResource) {
        var vm = this;

        saleResource.get({ id: 0 },
            function (data) {
                vm.sale = data;
                vm.originalSale = angular.copy(data);
            });

        vm.refreshClient = function () {
            clientResource.query({}, function (data) {
                vm.clients = data;
            });
        }
        vm.refreshClient();

        vm.refreshProduct = function () {
            productResource.query({}, function (data) {
                vm.products = data;
            });
        }

        vm.refreshProduct();

        vm.addSaleProduct = function (product) {
            var saleProduct = {
                productName: product.productName,
                quantity: 1,
                productPrice: product.price,
            }

            vm.sale.salesProducts.push(saleProduct)
        }
        
    }
}());