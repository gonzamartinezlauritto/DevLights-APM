(function () {
    "use strict";

    var app = angular.module("productManagement",
                            ["common.services","ui.router"]);

    app.config(function ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("list", {
                url: "/productListView",
                templateUrl: "app/products/productListView.html"
            })

            
            .state("modify", {
                url: "/producModifyView",
                templateUrl: "app/products/productModifyView.html",
                params: { productId: null },
            })



            .state("edit", {
                url: "/productEditView",
                templateUrl: "app/products/productEditView.html",

            })

            //---------------Client----------------------

            .state("client-list", {
                url: "/clientListView",
                templateUrl: "app/client/clientListView.html",
            })


            .state("client-modify", {
                url: "/clientModifyView",
                templateUrl: "app/client/clientModifyView.html",
                params: { clientId: null },
            })

            .state("client-edit", {
                url: "/clientEditView",
                templateUrl: "app/client/clientEditView.html",
            });


          $urlRouterProvider.otherwise("/productListView");
    });
}());