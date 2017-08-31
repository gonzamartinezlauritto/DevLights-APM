(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ClientListCtrl",
                    ["clientResource",
                     ClientListCtrl]);

    function ClientListCtrl(clientResource) {
        var vm = this;

        vm.searchCriteria = "GDN";

        //clientResource.query({},function (data) {
        //    vm.clients = data;
        //});

        vm.refreshList = function () {
            clientResource.query({}, function (data) {
                vm.clients = data;
            });
        }

        vm.delete = function (client) {
            client.$delete({ id: client.clientId }).then(function () {
                vm.refreshList();
            });
        }

        vm.refreshList();

        vm.deleteConfirm = function (client) {
            var txt;
            var r = confirm("Do you want to delete client?");
            if (r === true) {
                txt = "You pressed OK!"; vm.delete(client);
            } else {
                txt = "You pressed Cancel!";
            }


        }

    }

   
}());
