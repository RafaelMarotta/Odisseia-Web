function Request(type, url) {

    $.ajax({
        type: type,
        url: url,
        success: function (result) {
            return result;
        }
    });
}
