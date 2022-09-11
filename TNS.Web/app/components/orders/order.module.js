(function () {
    angular.module('TNS.orders', ['TNS.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('orders', {
                url: "/orders",
                parent: 'base',
                templateUrl: "/app/components/orders/orderListView.html",
                controller: "orderListController"
            }).state('order_detail', {
                url: "/orders/:id",
                parent: 'base',
                templateUrl: "/app/components/orders/orderDetailView.html",
                controller: "orderDetailController"
            });
    }
})();