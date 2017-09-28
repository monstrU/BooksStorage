var  AuthorsModule = (function (module) {

    module.ModalContentUrl = '/AuthorEditor/Load';
    module.ModalDialogId = 'idAuthorBox';
    module.PersonItemIdPrefix = '';

    var formatErrorMessage = function (info, errorMessages) {
        var message = info;
        if (typeof (errorMessages) == 'object')
            message += '\n' + errorMessages.join('\n');
        return message;
    }

    module.InitEvents = function () {

        var dialog = $("#" + module.ModalDialogId);
        dialog.on('shown.bs.modal', module.InitContent);


        $("#idTabStorage").on('click', "tbody tr td .edit-button", module.ShowModal);

        $("#" + module.ModalDialogId + ' .btn-default').on('click', module.Save);

    }

    module.InitContent = function (event) {
        var personId = parseInt($(event.target).data('personId'));

        var url = module.ModalContentUrl;
        if (!isNaN(personId))
            url += '?personId=' + personId;
        $("#" + module.ModalDialogId + ' .modal-body').load(url, function () {
            $.validator.unobtrusive.parse($("#" + module.ModalDialogId + " form"));

           
            $("#" + module.ModalDialogId).modal('show');
        });


    }


    module.ShowModal = function () {
        var dialog = $("#" + module.ModalDialogId);
        var personId = parseInt($(event.currentTarget).data("personId"));
        dialog.data("personId", personId);
        dialog.modal('show');
    }

    module.Save = function (data) {
        $('#' + module.ModalDialogId + " form[id='idSavePerson']").submit();
    }

    module.SuccessSave = function (data) {
        if (typeof (data) == 'object') {
            if (data.IsSuccess) {
                var dialog = $("#" + module.ModalDialogId);

                dialog.data("personId", '');
                dialog.modal('hide');

                var personId = parseInt(data.DataResult.PersonId);
                var url = '/auhtor/personitem?personid=' + personId;


                $.ajax({
                    method: 'GET',
                    url: url,
                    cache: false,
                    contentType: 'html',
                    traditional: true
                })
                .done(function (data) {
                    $("#" + module.PersonItemIdPrefix + personId).replaceWith(data);
                })
                .fail(function (data) {
                    alert('Ошибка при загрузки писателя. ');
                });
            } else {
                alert(formatErrorMessage("Ошибка при обновлении писателя !", data.ErrorMessages));
            }
        }
    }
    module.FailSave = function (data) {
        if (typeof (data) == 'object') {
            alert(formatErrorMessage("Ошибка при обновлении писателя !", data.responseJSON.ErrorMessages));
        }
    }

    return module;
}(AuthorsModule || {}));