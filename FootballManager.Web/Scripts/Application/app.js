﻿$(function () {
    Modal.init();
    XEditable.init();
    DateTimePicker.init();
});

function onSuccessModal(jsonResult) {
    //Notification.showResult(jsonResult);
    //Modal.refreshData();
    Modal.close();
}

function onFailureModal(jsonResult) {
    Notification.showError(jsonResult.Message);
}