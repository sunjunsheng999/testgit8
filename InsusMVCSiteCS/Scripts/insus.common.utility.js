
$.extend({
    RadioBind: function (obj, data, option) {
        $.each(data, function (i, item) {
            $('<input />', {
                type: "radio",
                name: "df",
                val: item.Format
            }).appendTo(obj);
            $('<label>', {
                text: item.Format,
            }).appendTo(obj);
        });
    }
});



$.extend({
    DdlInitBind: function (obj) {
        obj.append($('<option/>', {
            value: 0,
            text: "选择..."
        }));
    }
});

$.extend({
    DdlBind: function (obj, data, selVal) {
        obj.empty();
        $.DdlInitBind(obj);
        $.each(data, function (i, item) {
            obj.append($('<option/>', {
                value: item.Value,
                text: item.Text
            }));
        });

        obj.val(selVal == null ? 0 : selVal);
    }
});

$.extend({
    AlertException: function (XMLHttpRequest, errorThrown) {
        var responseTitle = $(XMLHttpRequest.responseText).filter('title').get(0);
        alert($(responseTitle).text() + "\n\r" + $.OutputException(XMLHttpRequest, errorThrown));
    }
});


$.extend({
    OutputException: function (jqXHR, exception) {
        if (jqXHR.status === 0) {
            return ('未连接，请检查您的网络连接。');
        } else if (jqXHR.status == 404) {
            return ('未找到所请求的页面[404]。');
        } else if (jqXHR.status == 500) {
            return ('内部服务器错误[500]。');
        } else if (exception === 'parsererror') {
            return ('请求的JSON解析失败。');
        } else if (exception === 'timeout') {
            return ('超时错误。');
        } else if (exception === 'abort') {
            return ('Ajax请求中止。');
        } else {
            return (jqXHR.responseText);
        }
    }
})
