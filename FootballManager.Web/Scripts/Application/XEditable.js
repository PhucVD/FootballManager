var XEditable = (function() {
    var init = function() {
        $.fn.editable.defaults.mode = 'inline';
        $(".editable").editable({
            success: function (response, newValue) {
                if (response.Status == '1')
                    Notification.showSuccess(response.Message);
                else 
                    Notification.showError(response.Message);
            }
        });
    };

    return {
        init: init
    };
})();