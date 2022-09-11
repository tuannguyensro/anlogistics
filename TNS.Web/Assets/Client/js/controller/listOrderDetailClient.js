
var listOrderDetail = {
    init: function () {

        listOrderDetail.eventRegisters();
    },
    eventRegisters: function () {
        $('#totalOrder').text('¥' + numeral(listOrderDetail.getTotalOrder()).format('0,0'));
        $('#TotalCNPrice').text('¥' + numeral(listOrderDetail.getTotalCNPrice()).format('0,0'));
        $('#TotalVNPrice').text(numeral(listOrderDetail.getTotalVNPrice()).format('0,0') + 'đ');
    },

    getTotalOrder: function () {
        var listdata = $('.Quantity');
        var total = 0;
        $.each(listdata, function (i, item) {
            total += parseFloat($(item).data('quantity')) * parseFloat($(item).data('price'));
        });
        return total;
    },

    getTotalCNPrice: function () {
        var TotalCN = $('#totalOrder');
        var totalOrder = listOrderDetail.getTotalOrder();
        var transportCNFree = parseFloat($('#TransportCNFree').data('transportcnfree'));
        var orderFee = parseFloat($('#OrderFee').data('orderfee'));
        var totalCNPrice = 0;
        $.each(TotalCN, function (i, item) {
            totalCNPrice += totalOrder + transportCNFree + ((orderFee * totalOrder)/100);
        });
        return totalCNPrice;
    },

    getTotalVNPrice: function () {
        var TotalVN = $('#TotalVNPrice');
        var totalCNPrice = listOrderDetail.getTotalCNPrice();
        var exchangeRate = parseFloat($('#ExchangeRate').data('exchangerate'));
        var totalVNPrice = 0;
        $.each(TotalVN, function (i, item) {
            totalVNPrice += totalCNPrice * exchangeRate;
        });
        return totalVNPrice;
    }
}
listOrderDetail.init();

