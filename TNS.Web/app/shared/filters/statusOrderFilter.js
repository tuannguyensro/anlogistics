(function (app) {
    app.filter('statusOrderFilter', function () {
        return function (input) {
            if (input == 0)
                return "Chờ xác nhận";
            else
                if (input == 1)
                    return "Đã xác nhận";
                else
                    if (input == 2)
                        return "Đã đặt hàng";
                    else
                        if (input == 3)
                            return "Kho TQ nhận";
                        else
                            if (input == 4)
                                return "Xuất kho TQ";
                            else
                                if (input == 5)
                                    return "Nhập kho VN";
                                else
                                    if (input == 6)
                                        return "Đang giao hàng";
                                    else
                                        if (input == 7)
                                            return "Đã giao hàng";
                                        else
                                            if (input == 8)
                                                return "Đã hủy";
        }
    })
})(angular.module('TNS.common'));