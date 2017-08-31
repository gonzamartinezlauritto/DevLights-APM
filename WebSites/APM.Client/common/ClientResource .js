(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("clientResource",
        ["$resource",
            "appSettings",
            clientResource]);
        
    function clientResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/clients/:id", null,
            {
                'update': {method : 'PUT'}
            });
        }
}());
