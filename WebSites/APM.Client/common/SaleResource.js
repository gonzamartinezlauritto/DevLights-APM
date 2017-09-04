(function () {
    "use string";

    angular
        .module("common.services")
        .factory("saleResource", ["$resource", "appSettings", saleResource])

    function saleResource($resource, appSetting) {
        return $resource(appSetting.serverPath + "api/sales/:id", null,
            {
                'update': { method: 'PUT' },
                'delete': { method: 'DELETE', url: appSetting.serverPath + "api/sales/:saleId" }
            });
    }

}());