$(function() {
    Modal.init();
    XEditable.init();

    $('[data-toggle=confirmation]').confirmation({
        rootSelector: '[data-toggle=confirmation]',
        // other options
    });
});

function onSuccessModal(jsonResult) {
    //Notification.showResult(jsonResult);
    //Modal.refreshData();
    Modal.close();
}

function onFailureModal(jsonResult) {
    Notification.showError(jsonResult.Message);
}