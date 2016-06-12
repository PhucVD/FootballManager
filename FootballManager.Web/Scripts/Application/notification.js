var Notification = (function () {
    var growl = function (message, type) {
        var option = { type: type, delay: 2000 };
        $.bootstrapGrowl(message, option);
    };
    var info = function (message) {
        growl(message, 'info');
    };

    var success = function (message) {
        growl(message, 'success');
    };

    var error = function(message) {
        growl(message, 'danger');
    };

    var result = function (jsonResult) {
        if (jsonResult.Status == 1) {
            success(jsonResult.Message);
        } else {
            error(jsonResult.Message);
        }
    }

    return {
        showResult: result,
        showInfo: info,
        showSuccess: success,
        showError: error
    };
})();   