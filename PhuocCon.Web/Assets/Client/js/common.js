var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $("#txtkeyword").autocomplete({
            minLength: 1,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/GetListProductByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (res) {
                        response(res);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtkeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtkeyword").val(ui.item.label);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
            .append("<a>" + item.label + "</a>")
            .append(ul);
        };
        $('#btnLogOut').off('click').on('click', function (e) {
            e.preventDefault();
            $('#frmLogOut').submit();
        });
    }
}
common.init();