(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                    ["productResource",
                     ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        vm.searchCriteria = "GDN";

        //productResource.query({},function (data) {
        //    vm.products = data;
        //});

        vm.refreshList = function () {
            productResource.query({}, function (data) {
                vm.products = data;
            });
        }

        vm.delete = function (product) {
            product.$delete({ id: product.productId }).then(function () {
                vm.refreshList();
            });
        }

        vm.refreshList();

        vm.deleteConfirm = function (product) {
            var txt;
            var r = confirm("Do you want to delete product?");
            if (r === true) {
                txt = "You pressed OK!"; vm.delete(product);
            } else {
                txt = "You pressed Cancel!";
            }


        }

    }

   
}());
