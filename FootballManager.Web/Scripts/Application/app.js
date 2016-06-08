$(function() {
    $(".modal").on("show.bs.modal", function () {
        // Load modal
        var url = $(".btn-modal").data("url");
        $(".modal-content").load(url);
    });
    $(".modal").on("shown.bs.modal", function () {
        // Enable modal validation
        $.validator.unobtrusive.parse($(this));

        // Init datetime picker
        if ($('.datetime-picker').length > 0) {
            $('.datetime-picker').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        }

        if ($('.year-picker').length > 0) {
            $('.year-picker').datetimepicker({
                format: 'YYYY'
            });
        }

    });

});

function onSuccessModal() {
    console.log("on success");
}

function onFailureModal() {
    console.log("on failure");

}