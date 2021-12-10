var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $('#btnLogOut').off('click').on('click', function (e) {
            e.preventDefault();
            $('#frmLogOut').submit();
        });
    }
}
common.init();