var cart = {
    init: function () {
        //cart.loadData();
        cart.registerEvents();
    },
    registerEvents: function () {
       
        $('#btnCheckout').off('click').on('click', function (e) {
            e.preventDefault();
            cart.createPackage();
        });
        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            var result = confirm("Tất cả sản phẩm trong giỏ hàng sẽ được xóa?");
            if (result)
                cart.deleteAll("load");
        });
        $('#btnLoadUserInfo').off('click').on('click', function () {
            if ($(this).prop('checked')) {
                cart.getUserInfo();
            }
            else {
                cart.resetValue();
            }

        });
    },
    resetValue: function () {
        $('#fullname').val('');
        $('#email').val('');
        $('#phone').val('');
        $('#address').val('');
        $('#message').val('');
    },
    getUserInfo: function () {
        $.ajax({
            url: '/Package/GetUserInfo',
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var user = res.data;
                    $('#fullname').val(user.FullName);
                    $('#email').val(user.Email);
                    $('#phone').val(user.PhoneNumber);
                    $('#address').val(user.Address);
                }
                else {
                    toastr.warning(res.message);
                }
            }
        })
    },

    createPackage: function () {
        var packageArr = [];
        packageArr.length = 0;

        $($("#tblPackageDetail tbody tr").each(function () {
            var packageItem = {
                TrackingID: $(this).find('td:eq(0)').find('input[type="text"]').val(),
                Description: $(this).find('td:eq(1)').find('input[type="text"]').val()
            }
            packageArr.push(packageItem);
        }));

        var package = {
            "CustomerName": $('#fullname').val(),
            "CustomerEmail": $('#email').val(),
            "CustomerAddress": $('#address').val(),
            "CustomerMobile": $('#phone').val(),
            "CustomerMessage": $('#message').val(),
            PaymentStatus: 0,
            "PackageDetails": packageArr
        };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Package/CreatePackage',
            data: {
                packageViewModel: JSON.stringify(package)
            },
            success: function (data) {
                if (data.status) {
                    alert('Thêm đơn hàng thành công');
                    window.location.href = "/danh-sach-ky-gui.html";
                    cart.deleteAll("");
                }
                else {
                    alert('Có lỗi xảy ra. Vui lòng kiểm tra lại đơn hàng');
                }
            },
            error: function (data) {
                alert('Có lỗi xảy ra. Vui lòng kiểm tra lại đơn hàng');
            }
        })
    },
    deleteItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            type: 'POST',
            dataType: 'json',
            data: {
                productId: productId
            },
            success: function (res) {
                if (res.status) {
                    toastr.success('Sản phẩm được xóa khỏi giỏ hàng.');
                    cart.loadData("");
                }
            }
        })
    },
    deleteAll: function (load) {
        $.ajax({
            url: '/Order/DeleteAll',
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    if (load == "load") {
                        toastr.success('Giỏ hàng đã được làm mới.');
                    }
                    cart.loadData();
                }
            }
        })
    },
}
cart.init();