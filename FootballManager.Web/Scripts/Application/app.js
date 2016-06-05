$(function() {
    $("body").on("show.bs.modal", "#standardModal", function () {
        var url = $(".btn-modal").data("url");
        $(".modal-content").load(url);
    });

    $("#standardModal").on("click", "#btnSave", function () {
        //console.log("save data");
        //$(".form-modal").submit();
    });
});

function onSuccessModal() {
    console.log("on success");
}

function onFailureModal() {
    console.log("on failure");

}