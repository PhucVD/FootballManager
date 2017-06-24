var XEditable = (function() {
    var init = function() {
        $.fn.editable.defaults.mode = 'inline';
        $(".editable").editable();
    };

    return {
        init: init
    };
})();
