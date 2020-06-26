
//PartialView Functions
function openModalCreateForm(modalId, loadDivId, controller, action) {
    $('#' + modalId).modal({
        backdrop: 'static',
        keyboard: false,
        show: true
    });
    $('#' + loadDivId).load("/"+controller+"/"+action); 
}
function closeModalCreateForm(modalId, loadDivId) {
    $('#' + modalId).modal('hide');
    $('#' + loadDivId).empty(); 

    var loading = '<div class="text-center"><img src="/ProjectImage/loading.gif" alt="Loading ..." /></div >';
    $('#' + loadDivId).prepend(loading);

}
function openModalUpdateForm(modalId, loadDivId, controller, action, queryString) {
    $('#' + modalId).modal({
        backdrop: 'static',
        keyboard: false,
        show: true
    });
    $('#' + loadDivId).load("/" + controller + "/" + action + queryString);
}
function closeModalUpdateForm(modalId, loadDivId) {
    $('#' + modalId).modal('hide');
    $('#' + loadDivId).empty(); 

    var loading = '<div class="text-center"><img src="/ProjectImage/loading.gif" alt="Loading ..." /></div >';
    $('#' + loadDivId).prepend(loading);
}
//~PartialView Functions

//UI operation functions
function addressDuplication(originSourceId, destinationSourceId, checkBoxId) {
    let checkState = $('#' + checkBoxId).is(":checked") ? "true" : "false";
    if (checkState === 'true') {
        $('#' + destinationSourceId).val($('#' + originSourceId).val());
    } else {
        $('#' + destinationSourceId).val("");
    }
}
function clearImagePreview(imagePreviewId, inputFileId) {
    $('#' + imagePreviewId).attr('src', '/images/DummyImage/dummy.png');
    $('#' + inputFileId).val('');
}
function checkDefaultImage(sourcePath) {
    var path = $(sourcePath).attr('src');
    if (path === '/images/DummyImage/dummy.png') {
        $('#btnImgRemove').hide();
        $('#btnImgClear').hide();
    } else {
        $('#btnImgRemove').show();
        $('#btnImgClear').show();
    }
}

function toggleBtnClearPreview(sourcePath, btnClearId) {
    
    var path = $(sourcePath).attr('src');
    if (path === '/ProjectImage/defaultImage.png') {
        $('#' + btnClearId).hide();
    } else {
        $('#' + btnClearId).show();
    }
}
function toggleBtnRemove(sourcePath, btnRemoveId) {
    var path = $(sourcePath).attr('src');
    if (path === '/images/DummyImage/dummy.png') {
        $('#' + btnRemoveId).hide();
    } else {
        $('#' + btnRemoveId).show();
    }
}
function toggleBtnClearBtnRemove(sourcePath, btnClearId, btnRemoveId) {
    toggleBtnClearPreview(sourcePath, btnClearId);
    toggleBtnRemove(sourcePath, btnRemoveId);
}
//UI operation functions

//Database operation functions
//This method doing insert and update process.
function insertRecord(controller, action, formId) {
    if ($('#' + formId).valid()) {
        var formData = new FormData($('#' + formId)[0]);
        $.ajax({
            type: 'POST',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            url: '/' + controller + '/' + action,
            success:
                function (data) {
                    if (data.success === true) {
                        if (data.redirectUrl.length)
                            window.location.href = data.redirectUrl;
                    }
                    if (data.success === false) {
                        swal("Failed to save data!", data.message, "error");
                    }
                },
            error: function (data) {
            },
            complete: function (data) {
            }
        });
    } else {
        swal("Failed to Save!", "Form is not valid", "error");
    }
}
function insertRecordWithoutForm(controller, action, modelObject) {

    console.log("insertRecordWithoutForm Values..");
    console.log(modelObject);
    postData = JSON.stringify( modelObject );
    console.log(postData);

    $.ajax({
        type: 'POST',
        url: '/' + controller + '/' + action,
        contentType: "application/json; charset=utf-8",
        dataType: 'JSON',
        data: {model: postData},
            cache: false,
            traditional: true,
            success:
                function (data) {
                    if (data.success === true) {
                        if (data.redirectUrl.length)
                            window.location.href = data.redirectUrl;
                    }
                    if (data.success === false) {
                        swal("Failed to save data!", data.message, "error");
                    }
                },
            error: function (data) {
            },
            complete: function (data) {
            }
        });
}
//These two methods not use anymore.
function deleteRecord(modelObject, deleteItemName, controller, action) {
    swal({
        title: "Would you like to delete " + deleteItemName + "?",
        text: "Warning: Remember once delete, couldn't be retrive.",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn btn-sm btn-outline-danger",
        confirmButtonText: "Yes, delete",
        cancelButtonText: "Cancel",
        cancelButtonClass: "btn btn-sm btn-outline-warning",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    type: 'POST',
                    data: { model: modelObject },
                    dataType: 'json',
                    cache: false,
                    //url: '@Url.Action("Delete", "Products")',
                    url: '/' + controller + '/' + action,
                    success:
                        function (data) {
                            if (data.success === true) {

                                swal({
                                    title: deleteItemName + data.message,
                                    type: "success",
                                    confirmButtonClass: "btn btn-sm btn-outline-success",
                                    confirmButtonText: "Okey"
                                }, () => {
                                    if (data.redirectUrl.length)
                                        window.location.href = data.redirectUrl;
                                });
                            }
                            if (data.success === false) {
                                swal({
                                    title: "Failed to delete.",
                                    text: data.message,
                                    type: "warning",
                                    confirmButtonClass: "btn btn-sm btn-outline-warning",
                                    confirmButtonText: "Okey"
                                }, () => {
                                    if (data.redirectUrl.length)
                                        window.location.href = data.redirectUrl;
                                });
                            }
                        },
                    error: function (data) {
                    },
                    complete: function (data) {
                    }
                });

            } else {
                swal.close();
            }
        });
}
function deleteFile(modelObject, controller, action) {
    swal({
        title: "Are you sure to remove?",
        text: "Warning: Once delete, can't be retrive.",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn btn-sm btn-outline-danger",
        confirmButtonText: "Yes, delete",
        cancelButtonText: "Cancel",
        cancelButtonClass: "btn btn-sm btn-outline-warning",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    type: 'POST',
                    data: { model: modelObject },
                    dataType: 'json',
                    cache: false,
                    url: '/' + controller + '/' + action,
                    success:
                        function (data) {
                            if (data.success === true) {
                                swal({
                                    title: "Successfully deleted.",
                                    type: "success",
                                    confirmButtonClass: "btn btn-sm btn-outline-success",
                                    confirmButtonText: "Okey"
                                }, () => {
                                    if (data.redirectUrl.length)
                                        window.location.href = data.redirectUrl;
                                });

                            }
                            if (data.success === false) {
                                swal({
                                    title: "Failed to delete.",
                                    text: data.message,
                                    type: "warning",
                                    confirmButtonClass: "btn btn-sm btn-outline-warning",
                                    confirmButtonText: "Okey"
                                }, () => {
                                    if (data.redirectUrl.length)
                                        window.location.href = data.redirectUrl;
                                });
                            }
                        },
                    error: function (data) {
                    },
                    complete: function (data) {
                    }
                });

            } else {
                swal.close();
            }
        });
}

//
function ddlFilterRecord(controller, action, queryString, selectId) {
    var value = $("#" + selectId).val();
    window.location.href = "/" + controller + "/" + action + queryString + value;
}
function deleteConfirmation(modelObject, itemName, controller, action) {
    swal({
        title: "Are you sure to delete " + itemName + "?",
        text: "Once deleted, can't be retrive.",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-sm btn-outline-danger",
        confirmButtonText: "Delete Confirm",
        cancelButtonClass: "btn-sm btn-fill-default",
        cancelButtonText: "Cancel",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {

                $.ajax({
                    type: 'POST',
                    data: { model: modelObject },
                    dataType: 'json',
                    cache: false,
                    url: '/' + controller + '/' + action,
                    success:
                        function (data) {
                            if (data.success === true) {
                                if (data.redirectUrl.length)
                                    window.location.href = data.redirectUrl;
                            }
                            if (data.success === false) {
                                swal("Failed to delete!", data.message, "error");
                            }
                        },
                    error: function (data) {
                    },
                    complete: function (data) {
                    }
                });
            } else {
                swal.close();
            }
        });
}
//~Database operation functions
