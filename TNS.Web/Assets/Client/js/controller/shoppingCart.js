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

        $('#btnCheckout').off('click').on('click', function (e) {
            e.preventDefault();        
            cart.createOrder();
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
        var orderArr = [];
        orderArr.length = 0;

        $($("#tblOrderDetail tbody tr").each(function () {
            var orderItem = {
                ProductLink: $(this).find('td:eq(0)').find('input[type="text"]').val(),
                ProductImage: $(this).find('td:eq(1)').find('input[type="text"]').val(),
                ProductDetail: $(this).find('td:eq(2)').find('input[type="text"]').val(),
                Quantity: $(this).find('td:eq(3)').find('input[type="number"]').val(),
                Description: $(this).find('td:eq(4)').find('input[type="text"]').val()
            }
            orderArr.push(orderItem);
        }));

        var order = {
            CustomerName: $('#fullname').val(),
            CustomerEmail: $('#email').val(),
            CustomerAddress: $('#address').val(),
            CustomerMobile: $('#phone').val(),
            CustomerMessage: $('#message').val(),
            PaymentStatus: 0,
            Status: true,
            OrderDetails : orderArr
        }
        $.ajax({
            url: '/Order/CreateOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (data) {
                if (data.status) {
                    alert('Thêm đơn hàng thành công');
                    window.location.href = "/orders";
                    cart.deleteAll("");
                }
                else
                {
                    alert('Có lỗi xảy ra. Vui lòng kiểm tra lại đơn hàng');
                }
            },
            error: function (error) {
                console.log(error);
            }
        })
    },
    loadData: function (isOrder) {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#templateCart').html();
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductId: item.ProductId,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            Price: (item.Product.PromotionPrice != 0 ? item.Product.PromotionPrice : item.Product.Price),
                            FPrice: numeral((item.Product.PromotionPrice != 0 ? item.Product.PromotionPrice : item.Product.Price)).format('0,0'),
                            Quantity: item.Quantity,
                            Alias: item.Product.Alias,
                            Amount: numeral(item.Quantity * (item.Product.PromotionPrice != 0 ? item.Product.PromotionPrice : item.Product.Price)).format('0,0'),
                        });
                    });
                    $('#cartBody').html(html);
                    if (html == '')
                        $('#tblCartTable').html('<h4 class="text-center text-danger">Không có sản phẩm nào trong giỏ hàng.</h4>');

                    $('#lblTotalOrder').text(numeral(cart.getTotalOrder().amount).format('0,0'));
                    $('#amount').text(numeral(cart.getTotalOrder().amount).format('0,0'));
                    $('span.product-count').text(cart.getTotalOrder().quantity);
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