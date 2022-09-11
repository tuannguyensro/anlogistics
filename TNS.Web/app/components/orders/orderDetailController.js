(function (app) {
    app.controller('orderDetailController', orderDetailController);
    orderDetailController.$inject = ['apiService', '$scope', '$stateParams', 'notificationService', '$state', '$ngBootbox','$window'];

    function orderDetailController(apiService, $scope, $stateParams, notificationService, $state, $ngBootbox, $window) {

        $scope.order = {};
        $scope.orderDetail = {};
        $scope.loading = true;
        $scope.getOrder = getOrder;
        $scope.getOrderDetail = getOrderDetail;
        $scope.UpdateOrder = UpdateOrder;
        $scope.getOrderPopup = getOrderPopup;
        $scope.getListOrderDetail = getListOrderDetail;

        $scope.UpdateOrderDetail = UpdateOrderDetail;
        $scope.paymentStatus = [{ value: 0, description: "Chờ xác nhận" },
        { value: 1, description: "Đã xác nhận" },
        { value: 2, description: "Đã đặt hàng" },
        { value: 3, description: "Nhập kho TQ" },
        { value: 4, description: "Xuất kho TQ" },
        { value: 5, description: "Nhập kho VN" },
        { value: 6, description: "Đang giao hàng" },
        { value: 7, description: "Đã giao hàng" },
        { value: 8, description: "Đã hủy" }
        ];

        $scope.orderFee = [{ value: 1, description: "1%" },
        { value: 2, description: "2%" },
        { value: 3, description: "3%" }
        ];



        $scope.deleteOrderDetail = deleteOrderDetail;

        function getOrder() {
            apiService.get('/api/order/getbyid/' + $stateParams.id, null,
                function (result) {
                    $scope.order = result.data;
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Load dữ liệu không thành công');
                });
        }
        $scope.total = 0;
        function getOrderDetail() {
            apiService.get('/api/order/getlistdetailbyid/' + $stateParams.id, null,
                function (result) {
                    $scope.orderDetail = result.data;
                    for (let i = 0; i <= result.data.length; i++) {
                        $scope.total += (result.data[i].CNPrice * result.data[i].Quantity);
                    }
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Load dữ liệu không thành công');
                });
        }

        function getOrderPopup() {
            apiService.get('/api/order/getbyid/' + $stateParams.id, null,
                function (result) {
                    $scope.orderpopup = result.data;
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Load dữ liệu không thành công');
                });
        }

        function UpdateOrder() {
            apiService.put('/api/order/update', $scope.orderpopup,
                function (result) {
                    notificationService.displaySuccess('Cập nhật thành công: ' + result.data.OrderCode);
                    $window.location.reload();
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Cập nhật không thành công');
            });
        }

        function getListOrderDetail() {
            apiService.get('/api/order/getlistdetailbyid/' + $stateParams.id, null,
                function (result) {
                    $scope.listorderDetail = result.data;
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Load dữ liệu không thành công');
                });
        }

        function UpdateOrderDetail() {
            var listOrderDetail = [];
            $.each($scope.listorderDetail, function (i, item) {
                listOrderDetail.push(item);
            });
            var config = {
                params: {
                    listorderdetails: JSON.stringify(listOrderDetail)
                }
            }
            apiService.get('/api/order/updateorderdetail', config, function (result) {
                notificationService.displaySuccess('Đã cập nhật thành công');
                $window.location.reload();
            }, function (error) {
                console.log(error);
                notificationService.displayError('Cập nhật không thành công');
            });
        }

        function deleteOrderDetail(id) {
            $ngBootbox.confirm('Bạn chắc chắn muốn xóa sản phẩm này không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/order/deletedetail', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công.');
                    resetOD();
                }, function () {
                    notificationService.displayWarning('Xóa không thành công!!!');
                })
            });
        }

        getOrder();
        getOrderDetail();
    }
})(angular.module('TNS.orders'));