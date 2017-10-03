var  AuthorsModule = (function (module) {

    module.ModalContentUrl = '/AuthorEditor/Load';
    module.ModalDialogId = 'idAuthorBox';
    module.BookManagerUrl = '/api/PersonsStorageManager';
    module.PersonIdPrefix = '';

    var formatErrorMessage = function (info, errorMessages) {
        var message = info;
        if (typeof (errorMessages) == 'object')
            message += '\n' + errorMessages.join('\n');
        return message;
    }

    module.InitEvents = function () {

        var dialog = $("#" + module.ModalDialogId);
        dialog.on('shown.bs.modal', module.InitContent);
        
        $("#idAuthorStorage").on('click', "tbody tr td .edit-button", module.ShowModal);
        
        $("#" + module.ModalDialogId + ' .btn-default').on('click', module.Save);

        $("#idAuthorStorage").on('click', "tbody tr td .glyphicon-remove", module.DeletePerson);

        $("#idAuthorStorage").on('click', "thead  .glyphicon-plus", module.AddPerson);

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


    module.ShowModal = function (event) {
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
                var url = '/authors/personitem?personid=' + personId;


                $.ajax({
                    method: 'GET',
                    url: url,
                    cache: false,
                    contentType: 'html',
                    traditional: true
                })
                .done(function (data) {
                    $("#" + module.PersonIdPrefix + personId).replaceWith(data);
                })
                .fail(function (data) {
                    alert('Ошибка при загрузки писателя. ');
                });
            } else {
                alert(formatErrorMessage("Ошибка при обновлении писателя !", data.ErrorMessages));
            }
        }
    }

    module.SuccessSaveAddNewPerson = function (data) {
        if (typeof (data) == 'object') {
            if (data.IsSuccess) {
                var dialog = $("#" + module.ModalDialogId);

                dialog.data("personId", '');
                dialog.modal('hide');

                var personId = parseInt(data.DataResult.PersonId);
                var url = '/authors/personitem?personid=' + personId;


                $.ajax({
                    method: 'GET',
                    url: url,
                    cache: false,
                    contentType: 'html',
                    traditional: true
                })
                .done(function (data) {
                    $("#idAuthorStorage tbody").append(data);
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

    module.DeletePerson = function (event) {
        var personId = parseInt($(event.currentTarget).data("personId"));

        var url = '/api/personsStorageManager/deleteperson?personid=' + personId;
        $.ajax({
            method: 'GET',
            url: url,
            cache: false,
            contentType: 'html',
            traditional: true
        })
          .done(function (data) {
              $("#" + module.PersonIdPrefix + personId).remove();
          })
          .fail(function (data) {
                var errors = '';
                if (typeof(data.responseJSON) == 'object')
                    errors = formatErrorMessage("Ошибка при удалении писателя.", data.responseJSON.ErrorMessages);
                else
                    errors = "Ошибка при удалении писателя.";
              alert(errors);
          });
    }

    module.AddPerson = function (event) {
        var dialog = $("#" + module.ModalDialogId);
        dialog.data("personId", '');
        dialog.modal('show');
    }
    return module;
}(AuthorsModule || {}));