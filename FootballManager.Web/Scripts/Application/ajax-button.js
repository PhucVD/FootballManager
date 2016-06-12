$(function() {
    $(".ajax-button").on("click", function () {
        var $this = $(this);
        $.ajax({
            url: $this.data("url"),
            method: $this.data("method"),
            data: ''
        }).done(function (response) {
            var targetId = '#' + $this.data("target-id");
            $(targetId).html(response);
        }).fail(function (jqXhr, textStatus) {
            Notification.showError("Request failed: " + textStatus);
        });
    });
});