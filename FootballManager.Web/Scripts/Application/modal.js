var Modal = (function() {
    var init = function() {
        $(".modal").on("show.bs.modal", function() {
            // Load modal
            var url = $(".btn-modal").data("url");
            $(".modal-content").load(url);
        });
        $(".modal").on("shown.bs.modal", function() {
            // Enable modal validation
            $.validator.unobtrusive.parse($(this));

            //init select picker
            $('.selectpicker').selectpicker();

            // Init datetime picker
            if ($('.datetime-picker').length > 0) {
                $('.datetime-picker').datetimepicker({
                    format: 'DD/MM/YYYY'
                });
            }
            // year picker
            if ($('.year-picker').length > 0) {
                $('.year-picker').datetimepicker({
                    format: 'YYYY'
                });
            }
        });
    };

    var close = function() {
        $('.modal').modal('toggle');
    }

    var refreshData = function() {
        var $form = $(".modal form");
        var url = $form.data("refresh-url");
        var id = $form.data("refresh-id");
        $(id).load(url);
    };

    return {
        init: init,
        close: close,
        refreshData: refreshData
    };
})();