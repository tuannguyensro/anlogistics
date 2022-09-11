var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvents();
    },
    registerEvents: function () {
        $('#btnRemoveItem').off('click').on('click', function (e) {
            e.preventDefault();
            var result = confirm("Bạn muốn xóa sản phẩm này?");
            if (result) {
                var productId = parseInt($(this).data('id'));
                cart.deleteItem(productId);
            }

        });
        $('.txtQuantity').off('keyup').on('keyup', function (e) {
            var quantity = parseInt($(this).val());
            var productId = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (!isNaN(quantity)) {
                var amount = quantity * price;
                $('#amount_' + productId).text(numeral(amount).format('0,0') + ' đ');
                $('span.product-count').text(cart.getTotalOrder().quantity);
                $('#lblTotalOrder').text(numeral(cart.getTotalOrder().amount).format('0,0'));
                $('#amount').text(numeral(cart.getTotalOrder().amount).format('0,0'));
            }
            else {
                $('#amount_' + productId).text(0);
                $('span.product-count').text(0);
                $('#lblTotalOrder').text(0);
                $('#amount').text(0);
            }
        });
        $('#btnContinute').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/shop.htm";
        });
        $('#btnUpdate').off('click').on('click', function (e) {
            e.preventDefault();
            var result = confirm("Bạn muốn cập nhật giỏ hàng?");
            if (result)
                cart.updateCart();
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
    getTotalOrder: function () {
        var listTextbox = $('.txtQuantity');
        var total = {
            amount: 0,
            quantity: 0
        };
        $.each(listTextbox, function (i, item) {
            total.amount += parseInt($(item).val()) * parseFloat($(item).data('price'));
            total.quantity += parseInt($(item).val());
        });
        return total;
    },
    getUserInfo: function () {
        $.ajax({
            url: '/Order/GetUserInfo',
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
    createOrder: function () {
        var order = {
            CustomerName: $('#fullname').val(),
            CustomerEmail: $('#email').val(),
            CustomerAddress: $('#address').val(),
            CustomerMobile: $('#phone').val(),
            PaymentMethod: $('select[name="paymentMethod"] option:selected').val(),
            BankCode: $('input[groupname="bankcode"]:checked').prop('id'),
            CustomerMessage: $('#message').val(),
            PaymentStatus: 0,
            Status: true
        }
        $.ajax({
            url: '/ShoppingCart/CreateOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (res) {
                if (res.status) {
                    if (res.urlCheckout != undefined && res.urlCheckout != '') {
                        window.location.href = res.urlCheckout;
                    }
                    else {
                        $('.bangthanhtoan').addClass('hide');
                        window.location.href = "/xem-trang-thai-mat-hang.htm";
                        cart.deleteAll("");
                    }
                }
            }
        })
    },
    loadData: function (isOrder) {
        $.ajax({
            url: '/Order/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#templateCart').html();
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductLink: item.ProductLink,
                            ProductImage: item.ProductImage,
                            ProductDetail: item.ProductDetail,
                            Quantity: item.Quantity,
                            Description: item.Description,
                        });
                    });
                    $('#tbody').html(html);
                    if (html == '')
                        $('#tblOrderDetail').html('<h4 class="text-center text-danger">Không có sản phẩm nào trong giỏ hàng.</h4>');
                    cart.registerEvents();
                }
            }
        })
    },
    updateCart: function () {
        var cartListModel = [];
        $.each($('.txtQuantity'), function (i, item) {
            cartListModel.push({
                ProductId: $(item).data('id'),
                Quantity: $(item).val()
            })
        });

        $.ajax({
            url: '/ShoppingCart/Update',
            dataType: 'json',
            type: 'POST',
            data: {
                cartData: JSON.stringify(cartListModel)
            },
            success: function (res) {
                if (res.status) {
                    cart.loadData("");
                    toastr.success('Cập nhật thành công');
                }
            }
        });
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
            url: '/ShoppingCart/DeleteAll',
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
    setProductCount: function (num) {
    }
}
cart.init();