
var listPackage = {
    init: function () {

        listPackage.eventRegisters();
    },
    eventRegisters: function () {
        listPackage.loadPackageList();
    },
    loadPackageList: function () {
        $.ajax({
            url: '/Package/GetListPackage',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#templateListCart').html();
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        var a = moment(item.CreatedDate).format('DD/MM/YYYY HH:mm:ss');
                        html += Mustache.render(template, {
                            ID: item.ID,
                            CreatedDate: a,
                            PackageCode: item.PackageCode,
                            CustomerMessage: item.CustomerMessage,
                            PaymentMethod: item.PaymentMethod,
                            PaymentStatus: (item.PaymentStatus == 0 ? "Chờ xác nhận" : item.PaymentStatus == 1 ? "Đã xác nhận" : item.PaymentStatus == 2 ? "Đã đặt hàng" :
                                            item.PaymentStatus == 3 ? "Kho TQ nhận" : item.PaymentStatus == 4 ? "Xuất kho TQ" : item.PaymentStatus == 5 ? "Nhập kho VN" : item.PaymentStatus == 6 ? "Đang giao hàng" :
                                            item.PaymentStatus == 7 ? "Đã giao hàng" : "Đã hủy"),
                            PaymentTag: (item.PaymentStatus == 0 ? "badge badge-secondary" : item.PaymentStatus == 1 ? "badge badge-dark" : item.PaymentStatus == 2 ? "badge badge-primary" :
                                         item.PaymentStatus == 3 ? "badge badge-info" : item.PaymentStatus == 4 ? "badge badge-light" : item.PaymentStatus == 5 ? "badge badge-primary" : item.PaymentStatus == 6 ? "badge badge-warning" :
                                         item.PaymentStatus == 7 ? "badge badge-success" : "badge badge-danger"),
                        });
                        $('#listPackageBody').html(html);
                        if (html == '')
                            $('#listPackageBody').html('<tr class="odd"><td style="color:red" valign="top" colspan="9" class="dataTables_empty">Chưa có đơn hàng, vui lòng tạo đơn mới</td></tr>');
                    });

                }
            }
        });
    }
}
listPackage.init();

